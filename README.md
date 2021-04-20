# ProjetIotia

# Présentation :
Vous trouverez l'ensemble des codes pour les différents capteurs (PIR, Ouverture/fermeture fenêtre et Gaz) ainsi que le code pour l'haut parleur utilisé pour les alertes qui est déployé sur un M5Stack.
Chaque donnée transmise entre différents appareils est transmis en Bluetooth.
Ils ont tous été programmé avec l'interface Arduino. 

# Capteur "PIR" :  
Le PIR est un capteur qui détecte l'infrarouge provenant du corps humain. Il permet de savoir si une personne est rentrée ou sortie. De type AS312 adapté pour le M5StickC. Il est donc relié à un M5StickC et les données sont transmises par le pin 36
Vous trouverez la documentation [Ici](https://github.com/LENSAlex/ProjetIotia/blob/Code_Capteur/documentation/DocumentationPIR.adoc)(PIR Sortie)</br> ou </br> [Ici](https://github.com/LENSAlex/ProjetIotia/blob/Code_Capteur/documentation/DocumentationPIR_sortie.adoc)

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
