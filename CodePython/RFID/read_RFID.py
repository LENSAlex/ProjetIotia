#!/usr/bin/env python
# -*- coding: utf8 -*-
# Version modifiee de la librairie https://github.com/mxgxw/MFRC522-python

import RPi.GPIO as GPIO
import MFRC522
import signal
import drivers
import paho.mqtt.client as mqtt

from time import sleep

broker_address="127.0.0.1"
client = mqtt.Client("RFID_IUD")

GPIO.setmode(GPIO.BOARD)
display = drivers.Lcd()
continue_reading = True

GREEN = 11
RED = 13

GPIO.setup(GREEN, GPIO.OUT)
GPIO.setup(RED, GPIO.OUT)
#Fonction qui arrete la lecture proprement 
def end_read(signal,frame):
    display.lcd_clear()
    global continue_reading
    print ("Lecture terminée")
    continue_reading = False
    GPIO.cleanup()

signal.signal(signal.SIGINT, end_read)
MIFAREReader = MFRC522.MFRC522()

print ("Passer le tag RFID a lire")
display.lcd_display_string(" Passer le tag:",1)
display.lcd_display_string("      RFID",2)

while continue_reading:
    GPIO.output(GREEN, GPIO.LOW)
    GPIO.output(RED, GPIO.LOW)
    display.lcd_display_string(" Passer le tag:   ",1)
    display.lcd_display_string("                ",2)
    # Detecter les tags
    (status,TagType) = MIFAREReader.MFRC522_Request(MIFAREReader.PICC_REQIDL)

    # Une carte est detectee
    if status == MIFAREReader.MI_OK:
        print ("Carte detectee")
    
    # Recuperation UID
    (status,uid) = MIFAREReader.MFRC522_Anticoll()

    if status == MIFAREReader.MI_OK:
	display.lcd_clear()
	UID = str(uid[0])+str(uid[1])+str(uid[2])+str(uid[3])
	#print (UID)
	display.lcd_display_string("UID:"+UID,1)
        print ("UID de la carte : "+str(uid[0])+"."+str(uid[1])+"."+str(uid[2])+"."+str(uid[3]))
	sleep(1)
	if UID == "21713017272":
		client.connect(broker_address) #connect to broker
		client.publish("/batiment/etages/salles/UID",UID)
		display.lcd_clear()
		display.lcd_display_string("      Acces",1)
		display.lcd_display_string("    Autorisee",2)
		GPIO.output(GREEN, GPIO.HIGH)
		sleep(1)
	else:
		client.connect(broker_address) #connect to broker
                client.publish("/batiment/etages/salles/UID",UID)
		display.lcd_clear()
		display.lcd_display_string("     Acces",1)
                display.lcd_display_string("    Refusee",2)
		GPIO.output(RED, GPIO.HIGH)
		sleep(1)

