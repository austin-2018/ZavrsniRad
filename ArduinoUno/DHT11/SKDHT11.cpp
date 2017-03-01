//	FILE: SKDHT11.cpp
//	VERSION: 0.0.1
//	PURPOSE: DHT11 Temperature & Humidity Sensor library for Arduino
//	DATASHEET: http://www.micropik.com/PDF/dht11.pdf
//	AUTHOR: Sead Kulenoviæ

#include "SKDHT11.h"

enum
{
	// 	Bits per byte
	BYTE_BITS = 8,

	// 	DHT11 sensor responds with 5 bytes of data:
	DATA_BYTES = 5,

	//	1.byte index - humidity: integral part
	HUMBYTE_IDX = 0,

	//	2.byte - humidity: fractional part - not used
	//	3.byte index - temperature: integral part
	TMPBYTE_IDX = 2,

	//	4.byte - temperature: fractional part - not used
	//	5.byte index - checksum: 1.byte + 3.byte
	CHKBYTE_IDX = 4,

	//	Most Significant Bit index in a byte
	BYTE_MSB = 7,
	
	//	Number of bits in data array = DATA_BYTES * 8 => 40
	DATA_BITS = 8 * DATA_BYTES,

	// 	Start request delay in ms (18) LOW
	START_DELAY_MS = 20,

	// 	Wait after Start request in us (20-40) HIGH
	START_WAIT_US = 50,

	//	Acknowledge response wait in us (80) LOW
	ACKRSP_WAIT_US = 100,

	// 	Ready response delay in us (80) HIGH
	READY_WAIT_US = 100,

	// 	Bit start delay in us (50) LOW
	BITSTART_DELAY_US = 50,

	// 	Logical "0" time delay treshold in us (28 = "0", 70 = "1")
	ZERO_DELAY_US = 40,

	// 	Logical "0" time delay treshold in us (70)
	ONE_DELAY_US = 80
};
SKDHT11::SensorState SKDHT11::begin()
{
	uint8_t data_buffer[DATA_BYTES] = {0};
	uint8_t bit_idx = BYTE_MSB;
	SensorState state = SSRD_OK;
	unsigned long high_mark = 0;
	
	//	Data line should be HIGH
	if (digitalRead(this->_comm_pin) != HIGH) return SSRD_ERR_TOUT;

	//	send start request
	pinMode(this->_comm_pin, OUTPUT);
	digitalWrite(this->_comm_pin, LOW);
	delay(START_DELAY_MS);

	//	wait for acknowlege sequence
	digitalWrite(this->_comm_pin, HIGH);
	delayMicroseconds(START_WAIT_US);
	pinMode(this->_comm_pin, INPUT);

	//	check acknowlege sequence
	if ((state = this->getPinFlipFrom(LOW, ACKRSP_WAIT_US)) == SSRD_OK)
	{
		if ((state = this->getPinFlipFrom(HIGH, READY_WAIT_US)) == SSRD_OK)
		{
			//	State obviously returned SSRD_OK so proceed to reading 5 bytes of data+checksum
			for (uint8_t i = 0; i < DATA_BITS; ++i, high_mark = 0)
			{
				//	wait for flip from LOW to HIGH for 50 us
				if ((state = this->getPinFlipFrom(LOW, BITSTART_DELAY_US)) != SSRD_OK)	return state;

				//	pin flipped to HIGH in time so mark current time in us
				high_mark = micros();

				//	now wait for pin flip from HIGH to LOW for longer than 70us to catch logical "1" flip
				if ((state = this->getPinFlipFrom(HIGH, ONE_DELAY_US)) != SSRD_OK)	return state;

				//	we are here so we got something:
				//	if longer than ZERO_DELAY it's "1" so LEFT-SHIFT it msb_idx bits then OR it with 
				//	the data_buffer bit (it's "0"), else leave it "0"
				if ((micros() - high_mark) > ZERO_DELAY_US)
					data_buffer[i / BYTE_BITS] |= (1 << bit_idx);

				//	Decrement the bit_idx or reset it
				bit_idx = (bit_idx > 0) ? bit_idx - 1 : BYTE_MSB;
			}

			//	we got 5 bytes of data+checksum, let's check 'em
			if (data_buffer[CHKBYTE_IDX] == (data_buffer[HUMBYTE_IDX] + data_buffer[TMPBYTE_IDX]))
			{
				// bytes check OK so write them as last valid values and return SSRD_OK state
				this->_humidity = data_buffer[HUMBYTE_IDX];
				this->_temperature = data_buffer[TMPBYTE_IDX];
				return state = SSRD_OK;
			}

			//	if we ever end up here means checksum test failed, return SSRD_ERR_CHKSM state
			return SSRD_ERR_CHKSM;
		}
	}
	return state;
}

SKDHT11::SensorState SKDHT11::getPinFlipFrom(const int oldState,uint8_t delay_us)
{
	if (delay_us < 10) return SSRD_ERR_TOUT;

	unsigned long mark = micros();

	while ((digitalRead(this->_comm_pin) == oldState))
	{
		if (micros() - mark > delay_us)
		{
			return SSRD_ERR_TOUT;
		}
	}

	return SSRD_OK;
}
