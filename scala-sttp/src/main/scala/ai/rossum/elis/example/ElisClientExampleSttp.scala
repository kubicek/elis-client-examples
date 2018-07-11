package ai.rossum.elis.example

import java.io.File

import com.softwaremill.sttp._
import com.softwaremill.sttp.json4s._
import org.json4s.native.Serialization.writePretty

object ElisClientExampleSttp {
  //noinspection TypeAnnotation
  implicit val backend = HttpURLConnectionBackend()

  //noinspection TypeAnnotation
  implicit val formats = org.json4s.DefaultFormats

  val api_key = "xxxxxxxxxxxxxxxxxxxxxx_YOUR_ELIS_API_KEY_xxxxxxxxxxxxxxxxxxxxxxx"
  val endpoint = "https://all.rir.rossum.ai"

  def main(args: Array[String]): Unit = {
     val filePath = "../data/invoice.pdf"
//    val filePath = "../data/invoice.png"
    sendDocument(filePath).flatMap(getDocumentPolling(_)) match {
      case Right(invoice) =>
        println(s"Processed invoice:\n${writePretty(invoice)}")
      case Left(error) =>
        println(s"Error while processing invoice:\n$error")
    }
  }

  def sendDocument(filePath: String): Either[String, String] = {
    println("Submitting the invoice...")
    val file = new File(filePath)
    val contentType = documentType(filePath)

    val response = sttp
      .post(uri"$endpoint/document")
      .header("Authorization", s"secret_key $api_key")
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
      .get(uri"$endpoint/document/$docId")
      .header("Authorization", s"secret_key $api_key")
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
