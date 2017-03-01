//	FILE: SKDHT11.h
//	VERSION: 0.0.1
//	PURPOSE: DHT11 Temperature & Humidity Sensor library for Arduino header file
//	AUTHOR: Sead Kulenoviæ

#ifndef skdht11_h
#define skdht11_h

#if defined(ARDUINO) && ARDUINO >= 100
	#include "arduino.h"
#else
	#include "WProgram.h"
#endif

class SKDHT11
{
	public:
		// sensor read status enumeration
		enum SensorState
		{
			SSRD_OK,			//	OK
			SSRD_ERR_CHKSM,		//	Checksum error
			SSRD_ERR_TOUT,		//	Timeout error
		};
	private:
		// communication pin (uC)<-->(DHT11)
		uint8_t _comm_pin;
		// last read humidity value
		uint8_t _humidity;
		// last read temperature value
		uint8_t _temperature;
		
		// helper method - waits for digital pin to change from oldState in delay_us microseconds
		SensorState getPinFlipFrom(const int oldState, const uint8_t delay_us);
	
	public:
		//
		// 	DHT11 Constructor:
		//	Creates SKDHT11 object that uses provided comm_pin for communication
		//	with the DHT11 sensor and initiates _humidity and _temperature to 
		//	invalid values to indicate they are not read from the sensor yet
		// 
		SKDHT11(uint8_t comm_pin) : _comm_pin(comm_pin), _humidity(-1), _temperature(-1) {}
		
		//	Reads data from DHT11 sensor and if successful saves it to memory, returns SensorState
		SensorState begin();

		//	Gets a temperature data
		uint8_t Temperature()
		{
			return _temperature;
		}

		//	Gets a humidity data
		uint8_t Humidity()
		{
			return _humidity;
		}
	
};

#endif