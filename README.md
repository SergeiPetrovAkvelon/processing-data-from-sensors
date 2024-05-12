# Processing data from sensors

1. There are a bunch of sensors that periodically send such data: (latitude, longitude, value) - all doubles.
1. The sensors are constructed so that the coordinates are determined with an accuracy of 0.001 degrees, and each time the value "wanders" within these limits.
1. The sensors are geographically scattered, no closer than 0.01 degrees from each other.
1. The task is to collect 100 values from all sensors, and calculate (min, max, avg, std) for each.