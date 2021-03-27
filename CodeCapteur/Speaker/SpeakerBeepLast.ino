#include <M5Stack.h>
#include "BluetoothSerial.h"

#if !defined(CONFIG_BT_ENABLED) || !defined(CONFIG_BLUEDROID_ENABLED)
#error Bluetooth is not enabled! Please run `make menuconfig` to and enable it
#endif

BluetoothSerial SerialBT;

#define NOTE_D0 -1
#define NOTE_D1 294
#define NOTE_D2 330
#define NOTE_D3 350
#define NOTE_D4 393
#define NOTE_D5 441
#define NOTE_D6 495
#define NOTE_D7 556

#define NOTE_DL1 147
#define NOTE_DL2 165
#define NOTE_DL3 175
#define NOTE_DL4 196
#define NOTE_DL5 221
#define NOTE_DL6 248
#define NOTE_DL7 278

#define NOTE_DH1 589
#define NOTE_DH2 661
#define NOTE_DH3 700
#define NOTE_DH4 786
#define NOTE_DH5 882
#define NOTE_DH6 990
#define NOTE_DH7 112


void setup() {
  // Initialize the M5Stack object
  M5.begin();
  M5.Power.begin();
  SerialBT.begin("Charbonnel_test"); //Bluetooth device name
  M5.Lcd.printf("M5Stack Speaker test:\r\n");
}
char result[255];
void loop() {
  if (SerialBT.available())
  {
    Serial.println(SerialBT.readString());
  }
  /*sprintf(result,"%s",SerialBT.readString());
  M5.Lcd.printf(result);*/
  if(SerialBT.readString()=="PirEntreeBL")
  //if(M5.BtnB.wasPressed())
  {
    M5.Lcd.printf("B wasPressed \r\n");
    M5.Speaker.tone(NOTE_DH3, 200); //frequency 3000, with a duration of 200ms
  }
  if(SerialBT.readString()=="GazBL")
  //if(M5.BtnB.wasPressed())
  {
    M5.Lcd.printf("B wasPressed \r\n");
    M5.Speaker.tone(NOTE_DH7, 200); //frequency 3000, with a duration of 200ms
  }
  if(SerialBT.readString()=="Ouvert")
  {
    M5.Lcd.printf("B wasPressed \r\n");
    M5.Speaker.tone(NOTE_D7, 200); //frequency 3000, with a duration of 200ms
  }
  if(SerialBT.readString()=="Ferme")
  {
    M5.Lcd.printf("B wasPressed \r\n");
    M5.Speaker.tone(NOTE_DH5, 200); //frequency 3000, with a duration of 200ms
  }
  if(SerialBT.readString()=="Gaz")
  {
    M5.Lcd.printf("B wasPressed \r\n");
    M5.Speaker.tone(NOTE_D1, 200); //frequency 3000, with a duration of 200ms
  }
  M5.update();
}
