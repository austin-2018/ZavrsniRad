/*
*	ESP-01S Test: Hardware Serial (PC over USB to Arduino) to Software Serial (Arduino to ESP-01S)
*/


#include <SoftwareSerial.h>

#define AT_TIMEOUT 5000 // ms
SoftwareSerial esp(4, 3); // RX, TX(Arduino) -> TX, RX(ESP-01S)

void setup()
{
	Serial.begin(115200);
	esp.begin(9600);
	while (!Serial);	// wait until Hardware Serial is ready
	while (!esp);		// wait until Software Serial is ready
}

void loop()
{

	String readStr = "";
	String writeStr = "";

	if (Serial.available())
	{
		writeStr = Serial.readStringUntil('\n');
	}
	if (writeStr.length() > 0)
	{
		esp.println(writeStr);
		esp.flush();
		Serial.println("TX: ");
		Serial.println(writeStr);
		Serial.flush();
	}
	while (esp.available() > 0)
	{
		readStr = esp.readStringUntil('\n');
	}
	
	if (readStr.length() > 0)
	{
		Serial.println("RX: ");
		Serial.println(readStr);
		Serial.flush();
	}

}

