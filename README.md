# Projet E-Covid

# Présentation :
Vous trouverez l'ensemble des codes pour les différents capteurs (PIR, Ouverture/fermeture fenêtre et Gaz) ainsi que le code pour l'haut parleur utilisé pour les alertes qui est déployé sur un M5Stack.
Chaque donnée transmise entre différents appareils est transmis en Bluetooth.
Ils ont tous été programmé avec l'interface Arduino. 

# Capteur "PIR" :  
Le PIR est un capteur qui détecte l'infrarouge provenant du corps humain. Il permet de savoir si une personne est rentrée ou sortie. De type AS312 adapté pour le M5StickC. Il est donc relié à un M5StickC et les données sont transmises par le pin 36
Vous trouverez la documentation [Ici](https://github.com/LENSAlex/ProjetIotia/blob/Code_Capteur/documentation/DocumentationPIR.adoc) (PIR Entrée)</br> ou </br> [Ici](https://github.com/LENSAlex/ProjetIotia/blob/Code_Capteur/documentation/DocumentationPIR_sortie.adoc) (PIR Sortie)

# Capteur "Gaz" : 
Le Capteur de gaz est un MH MQ Sensor, qui capte le taux de gaz présent dans une salle. Plus la valeur augmente, moins il y aura d'oxygène. Il est relié à un M5StickC et les données sont transmises par le pin 36
Vous trouverez la documentation [Ici](https://github.com/LENSAlex/ProjetIotia/blob/Code_Capteur/documentation/DocumentationGaz.adoc)

# Haut Parleur : 
L'haut parleur fonctionne sur un M5Stack, il jouera différents sons en fonction des données reçus. 
Vous trouverez la documentation [Ici](https://github.com/LENSAlex/ProjetIotia/blob/Code_Capteur/documentation/DocumentationHaut_parleur.adoc)

# Capteur "fenêtre" :
Le capteur de fenêtre est directement relié à un M5StickC sur le pin 0
Vous trouverez la documentation [Ici](https://github.com/LENSAlex/ProjetIotia/blob/Code_Capteur/documentation/DocumentationPorte.adoc)

# Code python : 
Vous trouverez un code python utilisé sur un raspberry Pi pour collecter les différentes valeurs des capteurs, envoyer les données au Broker MQTT ainsi que r'envoyer des alertes au M5Stack pour qu'il puisse jouer un son d'alerte. 
Vous trouverez la documentation [Ici](https://github.com/LENSAlex/ProjetIotia/blob/Code_Capteur/documentation/documentation_raspCapteurs.adoc)

# Installation Capteurs/Haut parleur :
## Capteur Gaz :
Veuillez réaliser les actions suivantes : (Avoir un M5StickC)</br>
**1°** : Dans *Fichier* -> *Préférences* -> ajoutez "https://dl.espressif.com/dl/package_esp32_index.json" dans le *Gestionnaire de cartes supplémentaires*
**2°** : Dans *Croquis* -> *Gestionnaire de bibliothèque* -> Recherchez "*ESP32 Lite Pack Library*" et installez là, faites de même pour "*M5StickC*"</br>
**3°** : Dans *Outils* -> *Type de cartes* -> *Gestionnaire de Carte* -> Recherchez "*esp32*"</br>
**4°** : Toujours dans *Outils* -> *Type de cartes* -> *Gestionnaire de Carte* -> *ESP32 Arduino* -> Sélectionnez "*ESP 32 Dev Module*"</br>
**5°** : Choissez le port de votre M5StickC puis téléverser votre programme. 
## Capteur PIR Entrée/Sortie:
Veuillez réaliser les actions suivantes : (Avoir un M5StickC)</br>
**1°** : Dans *Fichier* -> *Préférences* -> ajoutez "https://dl.espressif.com/dl/package_esp32_index.json" dans le *Gestionnaire de cartes supplémentaires*
**2°** : Dans *Croquis* -> *Gestionnaire de bibliothèque* -> Recherchez "*ESP32 Lite Pack Library*" et installez là, faites de même pour "*M5StickC*"</br>
**3°** : Dans *Outils* -> *Type de cartes* -> *Gestionnaire de Carte* -> Recherchez "*esp32*"</br>
**4°** : Toujours dans *Outils* -> *Type de cartes* -> *Gestionnaire de Carte* -> *ESP32 Arduino* -> Sélectionnez "*ESP 32 Dev Module*"</br>
**5°** : Choissez le port de votre M5StickC puis téléverser votre programme. 
## Capteur fenêtre :
Veuillez réaliser les actions suivantes : (Avoir un M5StickC)</br>
**1°** : Dans *Fichier* -> *Préférences* -> ajoutez "https://dl.espressif.com/dl/package_esp32_index.json" dans le *Gestionnaire de cartes supplémentaires*
**2°** : Dans *Croquis* -> *Gestionnaire de bibliothèque* -> Recherchez "*ESP32 Lite Pack Library*" et installez là, faites de même pour "*M5StickC*"</br>
**3°** : Dans *Outils* -> *Type de cartes* -> *Gestionnaire de Carte* -> Recherchez "*esp32*"</br>
**4°** : Toujours dans *Outils* -> *Type de cartes* -> *Gestionnaire de Carte* -> *ESP32 Arduino* -> Sélectionnez "*ESP 32 Dev Module*"</br>
**5°** : Choissez le port de votre M5StickC puis téléverser votre programme.</br>
***Important !*** : Veuillez bien téléverser votre programme avant de brancher le capteur de fenêtre à votre M5StickC. 
## Haut Parleur :
Veuillez réaliser les actions suivantes : (Avoir un M5Stack)</br>
**1°** : Dans *Fichier* -> *Préférences* -> ajoutez "https://dl.espressif.com/dl/package_esp32_index.json" dans le *Gestionnaire de cartes supplémentaires*
**2°** : Dans *Croquis* -> *Gestionnaire de bibliothèque* -> Recherchez "*ESP32 Lite Pack Library*" et installez là, faites de même pour "*M5Stack*"</br>
**3°** : Dans *Outils* -> *Type de cartes* -> *Gestionnaire de Carte* -> Recherchez "*esp32*"</br>
**4°** : Toujours dans *Outils* -> *Type de cartes* -> *Gestionnaire de Carte* -> *ESP32 Arduino* -> Sélectionnez "*M5Stack-core-ESP 32*"</br>
**5°** : Choissez le port de votre M5StickC puis téléverser votre programme.</br>

_________________________________________________________________________________________________________________________________________________________________________________
# Configuration Raspberry

# Présentation :
Vous trouverez ci dessous l'ensemble des codes python à installer sur le raspberry ainsi que les commande à utiliser pour parametrer le rapsberry et que le systeme fonctionne.

# Installation des Packets :
Normalement python est installé de base sur le raspberry, il faudra verifier si c'est bon et que python2 et python3 sont installé puis il vous faudra lancer les commandes suivantes pour installer les librairies python:

`sudo pip3 install opencv-python`

`sudo pip install paho-mqtt`

`sudo pip3 install paho-mqtt`

`sudo pip3 install bluepy`

maintenant il faudra créer un dossier appelé project avec un doosier driver à l'interieur ce sera la librairie de l'écran lcd:

`sudo mkdir project`

`sudo mkdir drivers`

et mettre les 4 fichiers qui se trouve [ici](https://github.com/LENSAlex/ProjetIotia/tree/Code_Capteur/CodePython/RFID/drivers) puis faire un :

`cd ..`

# Installation des Codes python :

## Code lecteur RFID :

L'explication du code RFID se trouve [ici](https://github.com/LENSAlex/ProjetIotia/blob/Code_Capteur/documentation/DocumentationRFID.adoc)

Pour mettre le code suivant il faudra que vous soyez dans le dossier project puis faire :

`sudo nano RFID.py`

Copié le code [suivant](https://github.com/LENSAlex/ProjetIotia/blob/Code_Capteur/CodePython/RFID/read_RFID.py)
puis faire CTRL+X et Y pour retourner sur le bash.

## Code de detection des visages :

L'explication du code de detection des visages se trouve [ici](https://github.com/LENSAlex/ProjetIotia/blob/Code_Capteur/documentation/DocumentationFaceDetection.adoc)

Pour mettre le code suivant il faudra que vous soyez dans le dossier project puis faire :

`sudo nano face_detection.py`

Copié le code [suivant](https://github.com/LENSAlex/ProjetIotia/blob/Code_Capteur/CodePython/face_detetection/face_detection.py)
puis faire CTRL+X et Y pour retourner sur le bash.

Et pour ajouter le fichier XML qui permet de detecter les visages il faudra faire :

`sudo nano haarcascade_frontalface_default.xml`

Copié le code [suivant](https://github.com/LENSAlex/ProjetIotia/blob/Code_Capteur/CodePython/face_detetection/haarcascade_frontalface_default.xml)
puis faire CTRL+X et Y pour retournersur le bash.

## Code des capteurs bluetooth :

L'explication du code des capteurs bluetooth se trouve [ici](https://github.com/LENSAlex/ProjetIotia/blob/Code_Capteur/documentation/DocumentationFaceDetection.adoc)

Pour mettre le code suivant il faudra que vous soyez dans le dossier project puis faire :

`sudo nano codeCapteurs_Fenetre_HautParleur_Mouvements_Gaz.py`

Copié le code [suivant](https://github.com/LENSAlex/ProjetIotia/blob/Code_Capteur/CodePython/Fenetre_HautParleur_Mouvement_Gaz/codeCapteurs_Fenetre_HautParleur_Mouvements_Gaz.py)
puis faire CTRL+X et Y pour retourner sur le bash.

# Service

# Présentation 
Pour qu'un raspberry lance des programmes automatiquement lors de son démmarage, il faut créer des services pour lancer les programmes python.
Cela va nous permettre ainsi de pouvoir relancer le programme sans aller la ou ce situe le code et de connaitre le status du service. 

## installation des services 
Pour installer les services il faudra aller dans le dossier system en faisant cette commande :

`cd /lib/systemd/system`

et faire :

`sudo nano python_RFID.service`

et mettre le code [suivant](https://github.com/LENSAlex/ProjetIotia/blob/Code_Capteur/CodePython/face_detetection/haarcascade_frontalface_default.xml)
puis faire CTRL+X et Y pour retourner sur le bash.

`sudo nano python_face_detection.service`

et mettre le code [suivant](https://github.com/LENSAlex/ProjetIotia/blob/Code_Capteur/CodePython/face_detetection/haarcascade_frontalface_default.xml)
puis faire CTRL+X et Y pour retourner sur le bash.

`sudo nano python_BTH.service`

et mettre le code [suivant](https://github.com/LENSAlex/ProjetIotia/blob/Code_Capteur/CodePython/face_detetection/haarcascade_frontalface_default.xml)
puis faire CTRL+X et Y pour retourner sur le bash.

pour donner les droit des fichiers et activer les services:

`sudo chmod 644 /lib/systemd/system/python_RFID.service`

`sudo chmod 644 /lib/systemd/system/python_face_detection.service`

`sudo chmod 644 /lib/systemd/system/python_BTH.service`

`sudo systemctl daemon-reload`

`sudo systemctl enable python_RFID.service`

`sudo systemctl enable python_face_detection.service`

`sudo systemctl enable python_BTH.service`

et faire un `sudo reboot` pour voir si les services ce lance et que les programmes fonctionnent
_________________________________________________________________________________________________________________________________________________________________________________
