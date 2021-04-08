# Noeud collecteur Salle (raspbery) 

Le raspbery sera le noeud collecteur d'une salle. Il est conecté sur le réseau et a un broker MQTT (mosquitto) configuré pour être inscrit aux topics du batiment.

Les capteurs envoie les données sur un socket bluetooth. 

# Configuration

**LOG** 
os : 
RASPIAN 9.4

/!\ A modifier en release 

utilisateur root : 
**user:** pi 
**password:** RASPiotia

/!\ A modifier en release 

**Configuration network** 
Conection du résau lp-iotia, 
static ip 192.168.0.10


## Installation Packets
**Installation packets bluetooth**

bluetooth bluez libbluetooth-dev blueman python-bluez


**Installation mosquitto**
