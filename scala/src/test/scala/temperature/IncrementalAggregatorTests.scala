package temperature

import org.joda.time.DateTime
import org.scalatest.{Matchers, FlatSpecLike}

import scala.concurrent.duration._

class IncrementalAggregatorTests extends FlatSpecLike with Matchers {

  behavior of "Aggregator.constructor"

  it should "create empty instance" in {
    //act
    val aggregator = createAggregator(threshold = 15.0, averageActualPeriod = 3.seconds)
    //assert
    aggregator.values.isEmpty should be (true)
  }

  behavior of "Aggregator.add"

  it should "add new device" in {
    //arrange
    val timestamp = DateTime.now
    val aggregator = createAggregator(threshold = 15.0, averageActualPeriod = 3.seconds)
    //act
    aggregator.add(deviceId = 1, value = 42.0, timestamp)
    //assert
    aggregator.values should be (Map(1 -> (42.0, timestamp)))
  }

  it should "update existing device" in {
    //arrange
    val timestamp = DateTime.now
    val aggregator = createAggregator(threshold = 15.0, averageActualPeriod = 3.seconds)
    aggregator.add(deviceId = 1, value = 42.0, DateTime.now.minusSeconds(1))
    //act
    aggregator.add(deviceId = 1, value = 43.0, timestamp)
    //assert
    aggregator.values should be (Map(1 -> (43.0, timestamp)))
  }

  it should "not generate any event if temperature stay normalized" in {
    val aggregator = createAggregator(threshold = 15.0, averageActualPeriod = 3.seconds)
    aggregator.add(deviceId = 1, value = 10.0, DateTime.now)
    //act
    val event = aggregator.add(deviceId = 1, value = 11.0, DateTime.now)
    //assert
    event should be (None)
  }

  it should "not generate any event if temperature stay exceeded" in {
    val aggregator = createAggregator(threshold = 15.0, averageActualPeriod = 3.seconds)
    aggregator.add(deviceId = 1, value = 20.0, DateTime.now)
    //act
    val event = aggregator.add(deviceId = 1, value = 19.0, DateTime.now)
    //assert
    event should be (None)
  }

  it should "generate event ThresholdExceeded if temperature exceed treshold" in {
    //arrange
    val aggregator = createAggregator(threshold = 15.0, averageActualPeriod = 3.seconds)
    aggregator.add(deviceId = 1, value = 10.0, DateTime.now)
    //act
    val event = aggregator.add(deviceId = 1, value = 20.0, DateTime.now)
    //assert
    event should be (Some(ThresholdExceeded(deviceId = 1)))
  }

  it should "generate event ValueNormalized if temperature is normalized" in {
    //arrange
    val aggregator = createAggregator(threshold = 15.0, averageActualPeriod = 3.seconds)
    aggregator.add(deviceId = 1, value = 20.0, DateTime.now)
    //act
    val event = aggregator.add(deviceId = 1, value = 10.0, DateTime.now)
    //assert
    event should be (Some(ValueNormalized(deviceId = 1)))
  }

  behavior of "Aggregator.average"

  it should "return None if average temperature is unknown" in {
    //arrange
    val aggregator = createAggregator(threshold = 15.0, averageActualPeriod = 3.seconds)
    //act
    val result = aggregator.average
    //assert
    result should be (None)
  }

  it should "return average value for average actual period only" in {
    //arrange
    val aggregator = createAggregator(threshold = 15.0, averageActualPeriod = 3.seconds)
    aggregator.add(1, 100.0, DateTime.now.minusSeconds(5))
    aggregator.add(2, 40.0, DateTime.now.minusSeconds(2))
    aggregator.add(3, 70.0, DateTime.now.minusSeconds(1))
    aggregator.add(3, 50.0, DateTime.now.minusSeconds(0))
    aggregator.add(5, 30.0, DateTime.now.minusSeconds(0))
    //act
    val result = aggregator.average
    //assert
    result should be (Some((40.0 + 50.0 + 30.0) / 3))
  }

  def createAggregator(threshold: Temperature, averageActualPeriod: FiniteDuration) =
    new IncrementalAggregator(threshold, averageActualPeriod, samplingInterval = 1.second)
}
