name := "elis-client-scala"

version := "0.1"

scalaVersion := "2.12.6"

libraryDependencies ++= Seq(
  // https://softwaremill.com/introducing-sttp-the-scala-http-client/
  "com.softwaremill.sttp" %% "core" % "1.0.5",
  "com.softwaremill.sttp" %% "json4s" % "1.2.2",
  "org.json4s" %% "json4s-jackson" % "3.5.4",
  "com.github.scopt" %% "scopt" % "3.7.0"
)
