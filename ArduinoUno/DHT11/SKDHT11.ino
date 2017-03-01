#include <SKDHT11.h>
#include <LiquidCrystal.h>
#define DHTPIN 2

SKDHT11 dht(DHTPIN);

LiquidCrystal lcd(13, 12, 11, 10, 9, 8);

void setup()
{
	Serial.begin(115200);
	lcd.begin(16, 2);
	dht.begin();
}

void loop()
{
	
	Serial.flush();
	Serial.print("SKDHT11: ");
	Serial.print("Temp=");
	Serial.print(dht.Temperature());
	Serial.print(", Humid=");
	Serial.print(dht.Humidity());
	Serial.print("\n");
	Serial.flush();
	
	lcd.clear();
	lcd.setCursor(0, 0);	// (column, row)
	lcd.print("Temp: ");
	lcd.print(dht.Temperature());
	lcd.print(" *C");

	lcd.setCursor(0, 1);
	lcd.print("Humid: ");
	lcd.print(dht.Humidity());
	lcd.print(" %RH");
	lcd.setCursor(15, 1);
	lcd.blink();
	
	delay(2000);
	SKDHT11::SensorState state = dht.begin();
	if (state != SKDHT11::SSRD_OK)
	{
		lcd.clear();
		lcd.setCursor(0, 0);
		lcd.print(">ERROR:DHT11<");
		lcd.setCursor(0, 1);
		if (state == SKDHT11::SSRD_ERR_CHKSM)
		{
			lcd.print(">>CHECKSUM<<");
		}
		else
		{
			lcd.print(">>TIMEOUT<<");
		}
		lcd.setCursor(15, 1);
		delay(3000);
	}
}
