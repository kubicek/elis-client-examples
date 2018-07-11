package ai.rossum.elis.example

import java.io.File

import com.softwaremill.sttp._
import com.softwaremill.sttp.json4s._
import org.json4s.native.Serialization.writePretty

object ElisClientExampleSttpApp {

  def main(args: Array[String]): Unit = {
    val parser = new scopt.OptionParser[Config]("elis-example") {
      head("elis-example", "1.0")
      opt[String]("filePath").required().action((x, c) =>
        c.copy(filePath = x)).text("path to document (PDF/PNG)")
      opt[String]("secretKey").required().action((x, c) =>
        c.copy(secretKey = x)).text("secret API key")
      opt[String]("host").action((x, c) =>
        c.copy(host = x)).text("API host base URL")

      override def showUsageOnError = true
    }

    parser.parse(args, Config()) match {
      case Some(config) =>
        val client = new ElisClientExampleSttp(config.secretKey, config.host)
        client.sendDocumentAndWaitForResult(config.filePath)
      case None =>
    }
  }
}

case class Config(filePath: String = "", secretKey: String = "", host: String = "https://all.rir.rossum.ai")

class ElisClientExampleSttp(secretKey: String, host: String) {

  //noinspection TypeAnnotation
  implicit val backend = HttpURLConnectionBackend()

  //noinspection TypeAnnotation
  implicit val formats = org.json4s.DefaultFormats

  def sendDocumentAndWaitForResult(filePath: String): Unit = {
    sendDocument(filePath).flatMap(getDocumentPolling(_)) match {
      case Right(invoice) =>
        println(s"Processed invoice:\n${writePretty(invoice)}")
        // --> here we can process the extracted invoice in JSON format <--
      case Left(error) =>
        println(s"Error while processing invoice:\n$error")
    }
  }

  def sendDocument(filePath: String): Either[String, String] = {
    println("Submitting the invoice...")
    val file = new File(filePath)
    val contentType = documentType(filePath)

    val response = sttp
      .post(uri"$host/document")
      .header("Authorization", s"secret_key $secretKey")
      .multipartBody(multipartFile("file", file).contentType(contentType))
      .response(asJson[Map[String, Any]])
      .send()

    response.body.flatMap(r =>
      r("status") match {
        case "error" => Left(s"Error: ${r("message")}")
        // "processing" -> extract document id
        case _ => Right(r("id").asInstanceOf[String])
      }
    )
  }

  def getDocument(docId: String): Either[String, Map[String, Any]] = {
    val response = sttp
      .get(uri"$host/document/$docId")
      .header("Authorization", s"secret_key $secretKey")
      .response(asJson[Map[String, Any]])
      .send()
    response.body.flatMap(r =>
      r("status") match {
        case "error" => Left(s"Service error: ${r("message").asInstanceOf[String]}")
        case _ => Right(r)
      }
    )
  }

  def getDocumentPolling(docId: String, retries: Int = 30, sleepMillis: Int = 2000): Either[String, Map[String, Any]] = {
    println("Waiting for the invoice being processed...")
    for (retry <- 1 to retries) {
      getDocument(docId) match {
        case Right(result) if result("status") != "processing" => return Right(result)
        case Left(error) => return Left(error)
        case _ =>
          // waiting
          println(s"Polling... ${retry * sleepMillis * 1e-3} / ${retries * sleepMillis * 1e-3} s")
      }
      Thread.sleep(sleepMillis)
    }
    Left("Time out")
  }

  def documentType(filePath: String): String = {
    if (filePath.toString.toLowerCase.endsWith(".png"))
      "image/png"
    else
      "application/pdf"
  }
}
