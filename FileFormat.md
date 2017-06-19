LogFile starts with a LogStart:

MicroSeconds	UInt32	# Arduino internal timestamp

TimeStamp		UInt32	# GPS timestamp (ticks since 1970...)

ValueCount		UInt16	# Number of datavalues per entry



Each Entry looks like this:

MicroSeconds		UInt32	# Arduino internal timestamp

Speed				UInt16	# Horizontal speed in mm/s. multiply with 0.0036 to get km/h

SpeedAccuracy		UInt16	# Speed accuracy in mm/s. multiply with 0.01 to get m/s

Longitude			Int32	# Scaling is 1e-7

Latitude			Int32	# Scaling is 1e-7

Altitude			Int32	# Unsure of scaling

HorizontalAccuracy	UInt32	# Unsure of scaling

VerticalAccuracy	UInt32	# Unsure of scaling

FixType				UInt8	# 3 = Full 3D-Fix

Value[0-ValueCount]	UInt16	# Value 0, scale 0-1024