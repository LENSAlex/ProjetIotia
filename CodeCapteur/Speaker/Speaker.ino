#pragma mark - Depend ESP8266Audio and ESP8266_Spiram libraries
#include <M5Stack.h>
#include <WiFi.h>
#include "AudioFileSourceSD.h"
#include "AudioFileSourceID3.h"
#include "AudioGeneratorMP3.h"
#include "AudioOutputI2S.h"
#include "BluetoothSerial.h"

#if !defined(CONFIG_BT_ENABLED) || !defined(CONFIG_BLUEDROID_ENABLED)
#error Bluetooth is not enabled! Please run `make menuconfig` to and enable it
#endif

BluetoothSerial SerialBT;

/*#define NOTE_D0 -1
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
*/

//pour fichier 1
AudioGeneratorMP3 *mp3;
AudioFileSourceSD *file;
AudioOutputI2S *out;
AudioFileSourceID3 *id3;
//pour fichier 2
/*AudioGeneratorMP3 *mp3_1;
AudioFileSourceSD *file2;
AudioOutputI2S *out_1;
AudioFileSourceID3 *id3_1;*/


void setup() {
  // Initialize the M5Stack object
  M5.begin();
  M5.Power.begin();
  M5.Lcd.printf("M5Stack Speaker test:\r\n");
  delay(500);
  SerialBT.begin("Charbonnel_test"); //Bluetooth device name
  Serial.println("The device started!");
  
  M5.Lcd.setTextFont(2);
  M5.Lcd.printf("Sample MP3 playback begins...\n");
  Serial.printf("Sample MP3 playback begins...\n");

  // pno_cs from https://ccrma.stanford.edu/~jos/pasp/Sound_Examples.html
  //premier fichier audio
  file = new AudioFileSourceSD("/joie.mp3");
  id3 = new AudioFileSourceID3(file);
  out = new AudioOutputI2S(0, 1); // Output to builtInDAC
  out->SetOutputModeMono(true);
  mp3 = new AudioGeneratorMP3();
  mp3->begin(id3, out);
  /*//deuxième fichier audio
  file2 = new AudioFileSourceSD("/peur.mp3");
  id3_1 = new AudioFileSourceID3(file2);
  out_1 = new AudioOutputI2S(0, 1); // Output to builtInDAC
  out_1->SetOutputModeMono(true);
  mp3_1 = new AudioGeneratorMP3();
  mp3_1->begin(id3_1, out_1);*/
}

void loop() {
  if (SerialBT.available())
  {
    Serial.println(SerialBT.readString());
  }
  /*if(5==5){
    M5.Lcd.printf("entrer \r\n");
    if (mp3->isRunning()) {
      if (!mp3->loop()) mp3->stop();
    } 
    else {
      Serial.printf("MP3 done\n");
      delay(1000);
    }
  }*/
  M5.update();
}
