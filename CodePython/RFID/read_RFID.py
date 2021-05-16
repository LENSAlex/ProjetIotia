#Librairie python 

#gpio raspberry
import RPi.GPIO as GPIO
#librairie lecteur RFID
import MFRC522
import signal
#librairie écran lcd
import drivers
#librairie pour client mqtt
import paho.mqtt.client as mqtt

#timer
from time import sleep

#adresse ip broker mqtt
broker_address="192.168.143.136"

#nomde notre client mqtt
client = mqtt.Client("RFID_IUD")

#initialisation des pin GPIO
GPIO.setmode(GPIO.BOARD)
#variable pour le driver lcd
display = drivers.Lcd()
#lecture mqtt
continue_reading = True

#couleur pour la led 
GREEN = 11
RED = 13

#setup des pins pour dire qu'ils sont en sortie
GPIO.setup(GREEN, GPIO.OUT)
GPIO.setup(RED, GPIO.OUT)

#Fonction qui arrete la lecture et le programme proprement 
def end_read(signal,frame):
    display.lcd_clear()
    global continue_reading
    print ("Lecture terminée")
    continue_reading = False
    GPIO.cleanup()

signal.signal(signal.SIGINT, end_read)

#Lectrure protocole MIFARE pour le lecteur RFID
MIFAREReader = MFRC522.MFRC522()

print ("Passer le tag RFID a lire")
display.lcd_display_string(" Passer le tag:",1)
display.lcd_display_string("      RFID",2)

while continue_reading:
    #extinction des pins
    GPIO.output(GREEN, GPIO.LOW)
    GPIO.output(RED, GPIO.LOW)
    display.lcd_display_string(" Passer le tag:   ",1)
    display.lcd_display_string("      RFID",2)
	
    #Detecte les tags
    (status,TagType) = MIFAREReader.MFRC522_Request(MIFAREReader.PICC_REQIDL)

    #Une carte a été detecté
    if status == MIFAREReader.MI_OK:
        print ("Carte detectee")
    
    #Recuperation UID
    (status,uid) = MIFAREReader.MFRC522_Anticoll()

    if status == MIFAREReader.MI_OK:
	display.lcd_clear()
	#integration de l'iud dans une variable string
	UID = str(uid[0])+str(uid[1])+str(uid[2])+str(uid[3])
	#print (UID)
	display.lcd_display_string("UID:"+UID,1)
	#affiche l'IUD
        print ("UID de la carte : "+str(uid[0])+"."+str(uid[1])+"."+str(uid[2])+"."+str(uid[3]))
	sleep(1)
	
	if UID == "21713017272":
		#connection au broker
		client.connect(broker_address)
		#publie sur le topic
		client.publish("/batiment/etages/salles/UID",UID)
		display.lcd_clear()
		#accès autoriser et allume le led en vert
		display.lcd_display_string("      Acces",1)
		display.lcd_display_string("    Autorisee",2)
		GPIO.output(GREEN, GPIO.HIGH)
		sleep(1)
	else:
		#connection au broker
		client.connect(broker_address)
		#publie sur le topic
                client.publish("/batiment/etages/salles/UID",UID)
		#accès autoriser et allume le led en rouge
		display.lcd_clear()
		display.lcd_display_string("     Acces",1)
                display.lcd_display_string("    Refusee",2)
		GPIO.output(RED, GPIO.HIGH)
		sleep(1)

