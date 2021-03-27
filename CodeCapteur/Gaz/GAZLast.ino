#include <M5StickC.h>
#include "BluetoothSerial.h"

#if !defined(CONFIG_BT_ENABLED) || !defined(CONFIG_BLUEDROID_ENABLED)
#error Bluetooth is not enabled! Please run `make menuconfig` to and enable it
#endif

BluetoothSerial SerialBT;
void setup() {
  // put your setup code here, to run once:
 M5.begin();
 SerialBT.begin("BtGaz"); //Bluetooth device name
 //Serial.begin(115200);
 pinMode(36,INPUT);
}

void loop() {

  int gaz;
  // put your main code here, to run repeatedly:
gaz=analogRead(36);
Serial.println("GAZ Level :");
Serial.println(gaz);
SerialBT.println(gaz);
delay(2000);
}
