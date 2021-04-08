# ProjetIotia
Vous trouverez l'ensemble des codes pour les différents capteurs (PIR, Ouverture/fermeture fenêtre et Gaz) ainsi que le code pour l'haut parleur utilisé pour les alertes qui est déployé sur un M5Stack.
Chaque donnée transmise entre différents appareil est transmis en Bluetooth.
Ils ont tous été programmé avec l'interface Arduino. 

Le PIR est un capteur qui détecte l'infrarouge provenant du corps humain. De type AS312 adapté pour le M5StickC. Il est donc relié à un M5StickC et les données sont transmises par le pin 36

Le Capteur de gaz est un MH MQ Sensor, qui capte le taux de gaz présent dans une salle. Plus la valeur augmente, moins il y aura d'oxygène. Il est relié à un M5StickC et les données sont transmises par le pin 36

L'haut parleur fonctionne donc sur un M5Stack, il jouera différents sons en fonction des données reçus. 

Le capteur de fenêtre est directement relié à un M5StickC sur le pin 0

De plus, vous trouverez un code python utilisé sur un raspberry Pi pour collecter les différentes valeurs des capteurs, envoyer les données dans la base de données ainsi que r'envoyer des alertes au M5Stack pour qu'il puisse jouer un son d'alerte. 

Pour le bon fonctionnement de l'ensemble des capteurs/haut parleur, veuillez téléverser les différents codes sur les bon appareils. 
Pour le bon fonctionnement des alertes et du stockage des données veuillez ... (à suivre) 
