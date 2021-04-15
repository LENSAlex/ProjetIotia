
#include <M5StickC.h>
#include "BluetoothSerial.h"

#if !defined(CONFIG_BT_ENABLED) || !defined(CONFIG_BLUEDROID_ENABLED)
#error Bluetooth is not enabled! Please run `make menuconfig` to and enable it
#endif
BluetoothSerial SerialBT;
// the setup routine runs once when M5StickC starts up
void setup(){
  // Initialise le M5StickC
  M5.begin();
  SerialBT.begin("fenetreBt"); //Bluetooth device name
  // LCD display
  M5.Lcd.setCursor(0,10);
  //Initialisation recupération valeur sur le pin 0
  pinMode(0, INPUT);
}
int cpt=0;
void loop() {
  
  int info = 0;
  // read the state of the pushbutton value
  Serial.println("Port A0: ");
  //Lecture de la donnée sur le pin 0
  info = digitalRead(0);
  Serial.println(info);
  if(info == 0){
    //Affichage pour informer l'utilisateur
    M5.Lcd.setCursor(0,10);
    M5.Lcd.print("Fermer");
  }
  if(info == 1){
    //Affichage pour informer l'utilisateur
    M5.Lcd.setCursor(0,10);
    M5.Lcd.print("Ouvert");
  }
// envoi si la porte est ouverte ou non. 1== ouvert / 0 == fermé
  SerialBT.println(info);
  delay(1000);
}
