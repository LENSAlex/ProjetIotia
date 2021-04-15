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
  //Récupération de la valeur du capteur sur le pin 36
  gaz=analogRead(36);
  Serial.println("GAZ Level :");
  // Affichage dans le terminal pour vérification 
  Serial.println(gaz);
  // Envoi de la donnée en bluetooth 
  SerialBT.println(gaz);
  //Placement du curseur sur l'écran LCD
  M5.Lcd.setCursor(25, 70);
  //Affichage de la donnée sur l'écran LCD
  M5.Lcd.print(gaz);
  delay(2000);
}
