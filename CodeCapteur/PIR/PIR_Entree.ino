#include <M5StickC.h>
#include "BluetoothSerial.h"

BluetoothSerial SerialBT;

void setup() {
  //Initialisation du bluetooph nom du peripherique
    SerialBT.begin("PirEntreeBL");
    
  //Initialisation du M5stickC
    M5.begin();
    //Couleur Ecran
    M5.Lcd.fillScreen(BLACK);
    //Position du curseur et taille du texte sur l'écran de LCD
    M5.Lcd.setCursor(15, 15, 2);
    //Affichage sur l'écran LCD
    M5.Lcd.println("PIR Etat");
    //Initialisation pour récuperer valeur du capteur
    pinMode(36,INPUT_PULLUP);
}

void loop() {
  //Si une personne est entrée 
  if(digitalRead(36)==1){
    // Affichage de la valeur 
    M5.Lcd.setCursor(25, 70, 7);M5.Lcd.print("1");
    //Ici j envoie qu'un passage a été détecté = 1
    SerialBT.println("1");
    //Affichage dans le terminal 
    Serial.println("1");
    delay(1000);
  }
  else{//si personne n'est rentrée
    //Affichage de la valeur 
    M5.Lcd.setCursor(25, 70, 7);M5.Lcd.print("0");
    //Ici j envoie qu'un passage a été détecté = 0
    SerialBT.println("0");
    Serial.println("0");
    delay(1000);
  }
}
