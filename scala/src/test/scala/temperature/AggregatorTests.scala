package temperature

import org.joda.time.DateTime
import org.scalatest.{Matchers, FlatSpecLike}

import scala.concurrent.duration._

class AggregatorTests extends FlatSpecLike with Matchers {

  behavior of "Aggregator.constructor"

  it should "create empty instance" in {
    //act
    val aggregator = Aggregator(threshold = 15.0, averageActualPeriod = 3.seconds)
    //assert
    aggregator.values.isEmpty should be (true)
  }

  behavior of "Aggregator.add"

  it should "add new device" in {
    //arrange
    val timestamp = DateTime.now
    val aggregator = Aggregator(threshold = 15.0, averageActualPeriod = 3.seconds)
    //act
    val result = aggregator.add(deviceId = 1, value = 42.0, timestamp)(_ => { })
    //assert
    result.values should be (Map(1 -> (42.0, timestamp)))
  }

  it should "update existing device" in {
    //arrange
    val timestamp = DateTime.now
    val aggregator = Aggregator(threshold = 15.0, averageActualPeriod = 3.seconds)
      .add(deviceId = 1, value = 42.0, DateTime.now.minusSeconds(1))(_ => {})
    //act
    val result = aggregator.add(deviceId = 1, value = 43.0, timestamp)(_ => {})
    //assert
    result.values should be (Map(1 -> (43.0, timestamp)))
  }

  it should "not generate any event if temperature stay normalized" in {
    var generatedEvent: Option[TemperatureStatusChanged] = None
    val aggregator = Aggregator(threshold = 15.0, averageActualPeriod = 3.seconds)
      .add(deviceId = 1, value = 10.0, DateTime.now)(_ => {})
    //act
    aggregator.add(deviceId = 1, value = 11.0, DateTime.now) { event => generatedEvent = Some(event) }
    //assert
    generatedEvent should be (None)
  }

  it should "not generate any event if temperature stay exceeded" in {
    var generatedEvent: Option[TemperatureStatusChanged] = None
    val aggregator = Aggregator(threshold = 15.0, averageActualPeriod = 3.seconds)
      .add(deviceId = 1, value = 20.0, DateTime.now)(_ => {})
    //act
    aggregator.add(deviceId = 1, value = 19.0, DateTime.now) { event => generatedEvent = Some(event) }
    //assert
    generatedEvent should be (None)
  }

  it should "generate event ThresholdExceeded if temperature exceed treshold" in {
    //arrange
    var generatedEvent: Option[TemperatureStatusChanged] = None
    val aggregator = Aggregator(threshold = 15.0, averageActualPeriod = 3.seconds)
      .add(deviceId = 1, value = 10.0, DateTime.now)(_ => {})
    //act
    aggregator.add(deviceId = 1, value = 20.0, DateTime.now) { event => generatedEvent = Some(event) }
    //assert
    generatedEvent should be (Some(ThresholdExceeded(deviceId = 1)))
  }

  it should "generate event ValueNormalized if temperature is normalized" in {
    //arrange
    var generatedEvent: Option[TemperatureStatusChanged] = None
    val aggregator = Aggregator(threshold = 15.0, averageActualPeriod = 3.seconds)
      .add(deviceId = 1, value = 20.0, DateTime.now)(_ => {})
    //act
    aggregator.add(deviceId = 1, value = 10.0, DateTime.now) { event => generatedEvent = Some(event) }
    //assert
    generatedEvent should be (Some(ValueNormalized(deviceId = 1)))
  }

  behavior of "Aggregator.average"

  it should "return None if average temperature is unknown" in {
    //arrange
    val aggregator = Aggregator(threshold = 15.0, averageActualPeriod = 3.seconds)
    //act
    val result = aggregator.average
    //assert
    result should be (None)
  }

  it should "return average value for average actual period only" in {
    //arrange
    val aggregator = Aggregator(threshold = 15.0, averageActualPeriod = 3.seconds)
      .add(1, 100.0, DateTime.now.minusSeconds(5))(_ => {})
      .add(2, 50.0, DateTime.now.minusSeconds(2))(_ => {})
      .add(3, 30.0, DateTime.now.minusSeconds(1))(_ => {})
    //act
    val result = aggregator.average
    //assert
    result should be (Some((50.0 + 30.0) / 2))
  }
}
