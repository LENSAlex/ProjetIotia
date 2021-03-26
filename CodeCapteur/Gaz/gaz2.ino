#include <M5StickC.h>
#include <driver/adc.h>
#include "BluetoothSerial.h"

#if !defined(CONFIG_BT_ENABLED) || !defined(CONFIG_BLUEDROID_ENABLED)
#error Bluetooth is not enabled! Please run `make menuconfig` to and enable it
#endif
BluetoothSerial SerialBT;
// the setup routine runs once when M5StickC starts up
void setup(){
  // Initialize the M5StickC object
  M5.begin();
  //Serial.begin(115200);
  SerialBT.begin("GazBt"); //Bluetooth device name
  // LCD display
  //M5.Lcd.print("Hello World");
  pinMode(0, INPUT);
}

// the loop routine runs over and over again forever
void loop() {
  // variable for storing the pushbutton status 
  int buttonState = 0;
  int toto = 0;
  // read the state of the pushbutton value
  toto = digitalRead(0);
  Serial.println(toto);

  SerialBT.println(toto);
  /*int read_raw;
    adc2_config_channel_atten( ADC2_CHANNEL_1, ADC_ATTEN_0db );

    esp_err_t r = adc2_get_raw( ADC2_CHANNEL_1, ADC_WIDTH_12Bit, &read_raw);
    if ( r == ESP_OK ) {
        printf("%d\n", read_raw );
    } else if ( r == ESP_ERR_TIMEOUT ) {
        printf("ADC2 used by Wi-Fi.\n");
    }
  
  int sensorValue= analogRead(read_raw);
  Serial.println(sensorValue);*/
  delay(500);
  
}
