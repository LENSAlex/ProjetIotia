#Librairie

#librairie OpenCV
import cv2
#timer
from time import sleep

import sys
#libairie mqtt client
import paho.mqtt.client as mqtt

#adresse ip broker mqtt
broker_address = "192.168.143.136"

#nom de notre client mqtt
client = mqtt.Client("camera")

#lecture du fichier contenant les vecteurs pour detecter les visages
face_cascade = cv2.CascadeClassifier('haarcascade_frontalface_default.xml')

#http://192.168.1.114:99/videostream.cgi?user=admin&pwd=&resolution=32&rate=0
#cap = cv2.VideoCapture("http://192.168.143.141:8081/")

#lecture du flux video de la camera connecté en USB
cap = cv2.VideoCapture(0)
print("lancement du flux vidéo")

while True:
    _, img = cap.read()
    #convertie l'image en gris 
    gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
    #detecte les visages 
    faces = face_cascade.detectMultiScale(gray, 1.1, 4)
    #dessine un rectancgle autour du visages
    for (x, y, w, h) in faces:
        cv2.rectangle(img, (x, y), (x+w, y+h), (255, 0, 0), 2)
    #variables qui enregistre le nombres de rectangles qu'il detecte
    nb_pers = len(faces)
    #print(nb_pers)
    
    #connection au broker
    client.connect(broker_address)
    #publie sur le topic le nombre de personne
    client.publish("/batiment/etages/salles/nombre_pers",nb_pers)
    sleep(1)
    #cv2.imshow('img', img)
    #stop le programme si la touche escape est appuyé
    k = cv2.waitKey(30) & 0xff
    if k == 27:
        break
cap.release()
