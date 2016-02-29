name := "temperature"
 
version := "1.0-SNAPSHOT"
 
organization := "com.name"
 
scalaVersion := "2.11.6"

resolvers ++= Seq(
  //"Sonatype Snapshots" at "http://oss.sonatype.org/content/repositories/snapshots",
  //"Sonatype Releases" at "http://oss.sonatype.org/content/repositories/releases",
  "Typesafe Repository" at "http://repo.typesafe.com/typesafe/releases/"
)

libraryDependencies ++= Seq(
  "com.typesafe.akka" %% "akka-actor" % "2.3.9",
  "org.joda" % "joda-convert" % "1.6",
  "joda-time" % "joda-time" % "2.6",
  "org.scalatest" %% "scalatest" % "2.2.0"
)
