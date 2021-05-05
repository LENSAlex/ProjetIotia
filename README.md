# Projet E-Covid

Contexte : 

L'objectif est d'avoir une infrastructure réseau respectant le schéma suivant : 

![SchemaReseau](https://user-images.githubusercontent.com/77000544/115960881-22ff0780-a514-11eb-8cd9-9f9e1574d864.png)

Le schéma réseau ci-dessus nous permet de déduire que nous aurons besoin : 
- 1] Un serveur web hebergé dans la DMZ (Demilitary Zone) 
- 2] Un serveur de base de données accessible uniquement depuis l'intranet

Pour le serveur web on nous a fournis un serveur dell avec une architecture RAID installer dessus ainsi qu'un windows seveur 2019.

Etapes de configuration du serveur : 

- 1] De configurer un serveur web afin d'héberger un site internet, des web services orienté ressources et un broqueur MQTT (mosquitto)
	- 1.1] Activation de l'accès à distance
	- 1.2] Mise en place de IIS 10
	- 1.3] Installer les dépendances nécéssaire pour héberger le site développer en C-Sharp .Net Core et les web services développer en NodeJS ainsi que phpMyAdmin
	- 1.4] Installer et configurer phpMyAdmin
	- 1.5] Ouverture des ports utiliser par les différents applications web
	
Pour le serveur de base de données un Raspberry Pi 3 sachant qu'il hebergera uniquement la base de données MariaDB.

Etapes de configuration du serveur de base de données : 
- 1] Installation de Raspbian sur le raspberry Pi 3
- 2] Connecter le raspberry au sous réseau de l'intranet (cf. schéma ci-dessus) par le biais de la wifi ayant pour SSID IOT
- 3] Installer et configurer openSsh pour acceder au serveur de base de données en ssh
- 3] Installer et configurer la base de données open-source MariaDB
- 4] Création d'un utilisateur avec un profil adminstrateur sur la base de données et d'un utilisateur avec des droits limiter
- 5] Installer et configurer IpTables pour limiter les accès au serveur de base de données. Entre autre refuser toute adresse n'ayant pas le mask 10.143.1.0/24


# Configuration du serveur de base de données :

Avant toute chose il faut installer le système d'exploitation raspbian sur notre raspberry : 
- 1] Télécharger la dernière version stable de raspbian sur le site officiel https://www.raspberrypi.org ou directement depuis le liens suivant : https://downloads.raspberrypi.org/raspios_armhf/images/raspios_armhf-2021-03-25/2021-03-04-raspios-buster-armhf.zip
- 2] Formatter une clé USB et installer l'image raspbian sur celle ci à l'aide d'un logiciel comme Balena-Etcher ou Noobs
- 3] Brancher la clé USB flashé sur le Raspberry et démarrer le pour lancer l'installation du système d'exploitation raspbian

Une fois installer il faut connecter le raspberry à internet afin de vérifier s'il existe des mises a jour. Pour cela taper en ligne de commande : 
- Pour mettre à jour uniquement les paquets : 
``` 
	sudo apt-get update	
``` 
-  Pour mettre à jour les paquest ainsi que la distribution : 
``` 
	sudo apt-get update && sudo apt-get upgrade && sudo apt-get dist-upgrade
``` 

Installer OpenSsh : 
``` 
	sudo apt-get update && sudo apt-get install openssh-client	
``` 
A partir de cet instant vous pouvez vous connecter en SSH au raspberry avec un autre ordinateur en utilisant la commande suivante : 
``` 
	ssh pi@192.168.1.143 -p
```  

ATTENTION l'utilisateur "pi" et l'adresse ip "192.168.1.143" sont données a titre d'exemple, adapter cette ligne de commande a votre configuration.

L'idéale est d'interdire la connection ssh grâce au couple d'identifiants utilisateur mot de passe et de privilégier l'utilisation de clé chiffrer privé.
Pour cela il faut réaliser les actions suivantes : 
- éditer le fichier /etc/ssh/sshd_config ``` sudo nano /etc/ssh/sshd_config OU sudo vim /etc/ssh/sshd_config ```
	- 1] interdire la connection ssh avec l'utilisateur root => ```PermitRootLogin no```
	- 2] vous pouvez changer le port ssh, par défaut ssh utilise le port 22 => ```Port 22```
	- 3] interdire l'authentification avec un mot de passe => ```PasswordAuthentication no```
	- 4] autoriser les connections à l'aide de clé privées/publiques => ```PubKeyAuthentication yes```
	- 5] (Optionnel) désactiver l'utilisation de passphrase, attention le paramètre PubKeyAuthentication doit être égale à yes pour cela => ``` UsePAM yes ``

Redémarrer le service ssh : 
``` 
	sudo service ssh restart 
```  
ou 
``` 
	sudo service ssh stop && sudo service ssh start
``` 

Vous pouvez maintenant acceder au raspberry en ssh.

Installation de MariaDB : 

Mise à jour de l'ensemble des paquets : 
``` 
	sudo apt-get update
```
Puis installer le serveur mariaDB :
```
	sudo apt-get install mariadb-server
``` 
Si vous avez déjà un MySQL d'installer sur votre système le gestionnaire de paquets vous demandera 
s'il doit être installer. Dans ce cas répondez oui.

Arréter le service mariadb avant de le démarrer :
```
	sudo service mariadb stop && sudo service mariadb start
``` 
Vérifier que le service mariadb tourne correctement (Active) : 
```
	sudo service mariadb status
``` 

Définir un mot de passe pour l'utilisateur root de mariaDB est important. 
Cela permet d'ajouter une sécurité en cas d'attaque du serveur, en effet si vous n'ajouter pas de mot de passe
à l'utilisateur root il peut se connecter à tout moment et modifier/consulter l'ensemble des bases de données stocké sur le serveur.
Pour définir un mot de passe à l'utilisateur root : 
```
	mysql -u root # connection a mysql en tant qu'utilisateur root
	SET PASSWORD FOR 'root'@'localhost' = PASSWORD('new_password'); # Ajouter un mot de passe a l'utilsateur root
	# modifier le mode d'authentification par défaut "unix_socket" par "mysql_native_password"
	UPDATE user SET plugin='mysql_native_password' WHERE User = 'root';
	#Sans cette opération l'utilisateur root du système raspbian est aussi root sur mariadb
	FLUSH PRIVILEGES;
	exit;
``` 

Vous pouvez maintenant vous connecter en tant que root a mariadb en utilisant votre nouveau mot de passe  : 
``` 
	mysql -u root -p
``` 

Ajouter un utilisateur avec tous les droits (CREATE, DROP, SELECT, etc..) sur toutes les base de données : 
``` 
	mysql -u root -p
	GRANT ALL PRIVILEGES ON *.* TO 'adminmaria'@'%' IDENTIFIED BY "monmotdepasse";
	FLUSH PRIVILEGES;
``` 

Ajouter un utilisateur avec des droits limiter (SELECT, UPDATE, DELETE, INSERT) sur une base de données uniquement : 
``` 
	mysql -u adminmaria -p
	GRANT SELECT, INSERT, UPDATE, DELETE ON nomdelabase.* TO 'iotia'@'%' IDENTIFIED BY "iotiamdp";
	FLUSH PRIVILEGES;
``` 
L'instruction ``` GRANT SELECT, INSERT, UPDATE, DELETE ```, donne les droits de consultation, d'insertion, de mise à jour et de suppression à l'utilisateur iotia;
Sur toutes les tables de la base de données (remplacer "nomdelabase") ``` ON nomdelabase.* ```;
Pour l'utilisateur iotia et de n'importe qu'elle adresse ip ``` TO 'iotia'@'%' ```, pour limiter l'accès a une adresse ip spécifique ou en locale il faut remplacer le % exemple ``` TO 'iotia'@'192.168.1.100' ```.

Configuration d'IpTables : 

Commencer par installer iptables sur le raspberry ``` sudo apt install iptables.
	```
En suite vérifier s'il existe des règles en exécutant la commande : ``` sudo iptables -nL ```, s'il existe déjà des règles dans iptables il vaut mieux rénitialiser le tout en tapant les commandes suivante : 
```
	sudo iptables -F && sudo iptables -X && sudo iptables -t nat -D POSTROUTING 1
```

Exécuter les commandes suivantes pour interdire toutes réception de paquets : 

 ATTENTION, si vous êtes connecter en ssh ces commandes vont vous déconnecter automatiquement. En effet cette commande interdis toutes entrées et sorties qui ne respectent pas les règles iptables. 
	Il est conseiller dans ce cas de créer un script shell a exécuter une fois que l'ensemble des règles sont décrite.


```
	sudo iptables -P INPUT DROP && sudo iptables OUTPUT DROP && sudo iptables FORWARD DROP
```

# Configuration du serveur web :

Dans un premier temps il faut activer IIS sur le serveur (si ce n'est pas déjà fait), pour cela il suffit de suivre la procédure indiqué ici : https://enterprise.arcgis.com/fr/web-adaptor/latest/install/iis/enable-iis-2016-components-server.htm


