# Interaction réseaux 
## Introduction 
Le projet met en oeuvre la collecte de données et la communication d'objets conectés au travers du protocole **MQTT**.

Ce document présente ces intéractions réseaux et les processus de connections. 

## Les entitées comuniquantes 

Nous distinguons 3 entités qui interargissent entre elles. Ne seront spécifiées ici que les services et fonctionalitées propre au processus de colecte de données.

+ **Le serveur**  : héberge la basse de données et les services web. Il appartient au réseau interne et a également accès au réseau publique. C'est sur le serveur que seront stockées les données collectées ainsi que les informations de configuration de l'ensemble du réseau. Plusieurs services sont assurés par lui. 
	- **La basse de données** ( mariadb) 
	- **Broker MQTT** (mosquitto)
+ **Le server DHCP** : Sert de passerelle entre le **serveur** et les **GW-batiment** pour les echanges de données. Plusieurs services sont assurés par celle ci:
	- **Broker MQTT** (mosquitto)
	- **serveur DHCP**: qui s'occupera de l'attrivution des adresses ip des éléments du réseau.
+ **Les gateway**: Servent de passerelles entre les **box** de chaques salles et la **GW-Main**
	- **Broker MQTT** (mosquitto)
+ **Box** : Une box représente chaques salles du batiments. Cette **Box** collecte les données de ses capteurs et pilote ses actionneurs.

![Schemas interactions](/config-raspbery/SCHEMAS/SCHEMAS_EXPORT/0-1_interaction-entite.png)

## Les mécanismes de communications

Plusieurs mécanismes de communications entre ces entités seront mis en oeuvre. Tout d'abord, tous ces éléments doivent pouvoir communiquer sur le réseau, pour cela nous mettons en place uns erveur **DHCP** qui permettra l'attribution d'adresse ip à ces entités.

**Le serveur DHCP** 
La **GW-main** sera un serveur DHCP qui sera identifiée par une ip fixe via laquelle elle communiquera avec le serveur. Ce serveur DHCP attribura des ip aux différents élements du réseau. 

**Le service MQTT**
La circulation des données entre les entités du serveur ( ex : capteur -> box -> BDD) sera assuré par le protocole MQTT. 

## Fonctionnement global

Nous souhaitons mettre en place un conection dyanmique entre ces entitées permetant de collecter/piloter les capteurs/accesseurs des box depuis le serveur. 

Pour cela, nous mettons d'abord en place une architecgure réseau permettant une communication entre tout ces éléments qui seront identifiés par une adresse ip attribuée par un serveur DHCP. 

Ensuite pour l'ajout d'éléments au réseau nous mettons en place une méthode de configuration du système permettant l'identification de chaqu'un des éléments auprès du serveur. Ces éléments sont enregistrés sur le serveur grace à leurs adresses **MAC** et localisés grace à une localisation de type __{campus/batiment/etage/salle}__. 

Lorsque les éléménts out-of-the-box sont instalés, ils entrent dans une phase d'initialisation dans l'aquelle ils:
+ Se connectent sur le réseaux(attribution d'une adresse IP)
+ démarage du service mosquitto (MQTT)
+ S'authentifie auprès du serveur ( téléchargement de leurs configuration qui comprends 
	+ Hostname
	+ Adresse ip de leurs gateway
	+ Localisation (c/b/e/s)
	+ Liste de leurs capteurs ( adresse Mac/ type de capteurs) 
	+ Liste de leurs acesseurs ( adresse MAC / type d'acceseurs ) 
+ Appairage / Initialisation des capteurs/ senseurs
+ démarage des processus de collecte de données( publication topic ) 
+ démarage de l'écoute ( subscription topic) 


