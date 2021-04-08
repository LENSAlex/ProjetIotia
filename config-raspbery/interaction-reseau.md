# Interaction réseaux 
## Introduction 
Le projet met en oeuvre la collecte de données et la communication d'objets conectés au travers du protocole **MQTT**.

Ce document présente ces intéractions réseaux et les processus de connections. 

Nous distinguons 3 entités qui interargissent entre elles. Ne seront spécifiées ici que les servoces et fonctionalitées propre au processus de colecte de données.
+ **Le serveur**  : héberge la basse de données et les services web. Il appartient au réseau interne et a également accès au réseau publique. C'est sur le serveur que seront stockées les données collectées ainsi que les informations de configuration de l'ensemble du réseau. Plusieurs services sont assurés par lui. 
	- **La basse de données** ( mariadb) 
	- **Broker MQTT** (mosquitto)
+ **La GW-Main** : Sert de passerelle entre le **serveur** et les **GW-batiment** pour les echanges de données. Plusieurs services sont assurés par celle ci:
	- **Broker MQTT** (mosquitto)
	- **serveur DHCP**: qui s'occupera de l'attrivution des adresses ip des éléments du réseau.
+ **Des GW-Batiment**: Sert de passerelles entre les **box** de chaques salles et la **GW-Main**
	- **Broker MQTT** (mosquitto)
+ **Box** : Une box représente chaques salles du batiments. Cette **Box** collecte les données de ses capteurs et pilote ses actionneurs.

![Schemas interactions](/configRaspbery/config-raspbery/SCHEMAS/SCHEMAS_EXPORT/0-1_interaction-entite.png)

			https://github.com/LENSAlex/ProjetIotia/blob/configRaspbery/config-raspbery/SCHEMAS/SCHEMAS_EXPORT/0-1_interaction-entite.png

<
