import cv2
import time
import sys
import paho.mqtt.client as mqtt

broker_address = "127.0.0.1"
client = mqtt.Client("camera")
# Load the cascade
face_cascade = cv2.CascadeClassifier('haarcascade_frontalface_default.xml')

# http://192.168.1.114:99/videostream.cgi?user=admin&pwd=&resolution=32&rate=0
#cap = cv2.VideoCapture("http://192.168.143.141:8081/")
cap = cv2.VideoCapture(0)
# To use a video file as input
# cap = cv2.VideoCapture('filename.mp4')
print("lancement du flux vidéo")
while True:
    _, img = cap.read()
    # Convert to grayscale
    gray = cv2.cvtColor(img, cv2.COLOR_BGR2GRAY)
    # Detect the faces
    faces = face_cascade.detectMultiScale(gray, 1.1, 4)
    # Draw the rectangle around each face
    for (x, y, w, h) in faces:
        cv2.rectangle(img, (x, y), (x+w, y+h), (255, 0, 0), 2)
    # Display
    nb_pers = len(faces)
    #print(nb_pers)
    client.connect(broker_address) #connect to broker
    client.publish("/batiment/etages/salles/nombre_pers",nb_pers)
    #cv2.imshow('img', img)
    # Stop if escape key is pressed
    k = cv2.waitKey(30) & 0xff
    if k == 27:
        break
# Release the VideoCapture object
cap.release()
