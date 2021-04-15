#include <M5StickC.h>
#include "BluetoothSerial.h"

BluetoothSerial SerialBT;

void setup() {
  //Initialisation du bluetooph nom du peripherique
    SerialBT.begin("PirSortieBL");
    
  // put your setup code here, to run once:
    M5.begin();
    M5.Lcd.fillScreen(BLACK);
    M5.Lcd.setCursor(15, 15, 2);M5.Lcd.println("PIR Etat");
    pinMode(36,INPUT_PULLUP);
}

void loop() {
  // put your main code here, to run repeatedly:
  
  if(digitalRead(36)==1){
    M5.Lcd.setCursor(25, 70, 7);M5.Lcd.print("1");
    /*Serial.println("PIR Status: Sensing");
    Serial.println(" value: 1");*/
    //Ici j envoie qu'un passage a été détecté = 1
    SerialBT.println("1");
    Serial.println("1");
    delay(1000);
  }
  else{
    M5.Lcd.setCursor(25, 70, 7);M5.Lcd.print("0");
    /*Serial.println("PIR Status: Not Sensed");
    Serial.println(" value: 0");*/
    //Ici j envoie qu'un passage a été détecté = 0
    SerialBT.println("0");
    Serial.println("0");
  }
  
}
