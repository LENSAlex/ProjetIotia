# ProjetIotia
Projet fin d'année iotia (projet covid)

Web Service:

Ce web service est une api de type REST , codé grace a Node JS.

# Utilisation du WebService :

Les codes qui constitue le WebService ce trouve [ici](https://github.com/LENSAlex/ProjetIotia/tree/WebService/WebService)

Pour **utiliser** les service cela se passe pour l'instant sur l'ip ```http://51.75.125.121```

Ce WebService est décomposé en plusieurs services voir le tableau ci dessous:
| Nom du service | Port | Remarque |
| --- | --- | --- |
| Infrastructure | 3000 | Service pour avoir des informations sur les infrastructures |
| Usager | 3001 | Service pour avoir des informations sur les membres de l'iut (etudiant , professeur , ..)|
| Covid | 3002 | Service pour gérer les cas covid |
| Infra admin  | 3004 | Modifs , gateways  |
| Infra PROD  | 3005 | Capteur et actionneurs |
| Alerte  | 3006 | Alerte (covid , personne , actionneur)  |

A remplacer infrastcture et capteurs et mettre alerte.

--> Tout ces services possede leurs propres documentation sur la route  ```/docs ``` (exemple:  ```localhost:3000/docs ``` documentation pour le service Batiment)


# Outils utilisés :

Pour utiliser cette api , la modifier vous devez :

- 1] [Installer](https://nodejs.org/en/) Node JS (version utiliser v12.18.4)
- 2] Installer les dependance present dans le fichier package.json avec npm par exemple.
- 3] Faire un [dump](https://github.com/LENSAlex/ProjetIotia/blob/documentation/ScriptSQL.txt) de notre base de donnée (phpmyadmin).
- Avoir un editeur de texte type Visual Studio Code est conseillé.


# Création d'une nouvelle API :

- 1] Pour créer une API va devez creer un fichier .js
- 2] Vous pouvez ensuite utiliser des modules comme express pour creer un server http [Voir ici](https://www.npmjs.com/package/express)
- 3] Lancer votre serveur http avec la commande   ```node NomFichier.js```
- 4] Vous pouvez voir le resultat sur ```localhost:VotrePort/VotreRoute ```

