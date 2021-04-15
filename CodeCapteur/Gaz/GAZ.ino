#include <M5StickC.h>
#include "BluetoothSerial.h"

#if !defined(CONFIG_BT_ENABLED) || !defined(CONFIG_BLUEDROID_ENABLED)
#error Bluetooth is not enabled! Please run `make menuconfig` to and enable it
#endif

BluetoothSerial SerialBT;
void setup() {
 M5.begin();
 SerialBT.begin("BtGaz"); //Bluetooth device name
 M5.Lcd.setCursor(10, 10);
 M5.Lcd.println(" Taux Gaz :");
 //Serial.begin(115200);
 pinMode(36,INPUT);
}

void loop() {
  int gaz;
  
  gaz=analogRead(36);
  Serial.println("GAZ Level :");
  Serial.println(gaz);
  SerialBT.println(gaz);
  M5.Lcd.setCursor(25, 70);
  M5.Lcd.print(gaz);
  delay(2000);
}
