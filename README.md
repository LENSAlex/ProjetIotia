Web Service dirigé par Thibaud et alex:

# WebServiceProjetIotia
Web service du projet iotia

-Le web service s'applique au serveur qui collecte toutes les données des differentes gateway des batiments (il tourne sur le serveur)

-Pour le web service on peux en fonction des actions sur le site ou l app mobile données des routes pour avoir des infos (allé chercher bdd ou onem2m)

-Donc les capteurs envoie au raspberry pi de la salle , qui lui envoie au gateway du bat vers serveur central (peut etre car pas deployé).

-Diagramme cas d utilisation pour mieux comprendre quelles ressouces (bdd , onem2m) est utilisés.

--------------------------------------------
//
GET:

//Capteur
-Capteur/Salle/:idSalle/:Obj (Avoir valeur d'un capteur , derniere valeur)
-Capteur/Salle/:idSalle/:Obj/List (List d un capteur specifique)
-Capteur/Salle/:idSalle/:Obj/List/Date1/Date2 (List capteur entre 2 dates)
-Capteur/Salle/:idSalle/All (list de toutes les valeurs releves dans une salle)
-Capteur/Salle/:idSalle/Last (list de toutes les dernieres valeurs releves dans une salle)

-Capteur/Salle/:idSalle/MoyenneCo2 (Co2Moyen journee)
-Capteur/Salle/:idSalle/Co2/Attribut (co2 min ou max journee)
-Capteur/Salle/:idSalle/Temp (tempMoyenne journee)
-Capteur/Salle/:idSalle/Temp/Attribut (temp min ou max  journee)
-Capteur/Salle/:idSalle/OuvertureFenetre (ouverture fenetre journee)
-Capteur/Salle/:idSalle/NbEntree (nombre entre salle journee)
-Capteur/Salle/:idSalle/NbEntree/Date1/Date2 (nombre entre salle entre deux dates)
-Capteur/Salle/:idSalle/NbSortie(nombre sortie salle journee)
-Capteur/Salle/:idSalle/NbSortie/Date1/Date2 (nombre sortie salle entre deux dates)

//Equipement
-/Equipement/Alerte (avertir penurie car pas de stock)

//Personne
-/Personne (liste de tous les eleves des promos)
-/Personne/Formation (List des promos)
-/Personne/Departement/ID (Liste eleves dans un departement)
-/Personne/Promotion/ID (Liste eleves dans une promo)
-/Personne/Promotion/:IDPromo/personne/cours (Liste des cours d un eleve)
-/Personne/Promotion/ID/personne/cours/presentielle (Liste des cours en presentielle d un eleve)
-/Personne/Promotion/ID/personne/cours/distancielle (Liste des cours en distancielle d un eleve)
-/Personne/ID/abs (Liste des abscence d un eleve)

---> Voir route qui pouvent aider a avoir idPromo et idPersonne ...

//Acces
-/Acces/Batiment (Jauge de tous les batiments)
-/Acces/Batiment/id/ (Jauge d un batiement)
-/Acces/Batiment/id/Etage (Jauge des etages d un batiment)
-/Acces/Batiment/id/Etage/id (Jauge d un etage d un batiment)
-/Acces/Batiment/Salle/id (Jauge d une salle d un batiment)
-/Acces/Batiment/id/Salle (Jauge des salle d un batiment)
-/Acces/Promo/ (nb acces de toutes les promos)  //pas sur possible ou par cour donc un cour et le nombre a voir 
-/Acces/Promo/id (nb acces par promo demi jauge)  //Pareil que au dessus 

//Alerte 
-/Alerte/Covid/Personne/id (alerte cas covid , alerté membre classe , etage , bat ....)

PUT:
-/Batiment/:idBat/Salle/:idSalle/:Obj/:Value (Modifié valeur d un capteur)
-/Batiment/:idBat/ (modif batiment)
-/Batiment/:idBat/Salle/:idSalle (modif salle batiment)


POST:
-/Batiment/:idBat/Salle/:idSalle/Obj (ajout d un capteur)
-/Batiment/:idBat/ (ajout batiment)
-/Batiment/:idBat/Salle/:idSalle (ajout salle batiment)

//Pour les capteurs je dois faire des requetes pour remplir onem2m ou la bdd.
//Pour recup ca se passe que avec la bdd.


-Faire partie admin en service pour administrer les brokers , rajouter enlever.
-Du coup voir les routes util via les issues.


- Application Mobile WebRequest:
Get All Capteur (Liste les capteurs via un select *)
Post Alerte Covid (Requête post vers la table AlertCovid en envoyé une ligne avec la date et la personne qui à le covid)
Put Alerte pénurie (Update un produit en stock par un 0 (donc pas en stock))
Get Capteur de la salle via search (Cherche les capteurs d'une salle via le numéro de salle)
Get Count des malades d'un salle, bâtiment et iut (Récupère le nombre de malade en fonction de ce qu'on a choisit)
Get list des équipements pour le stock (Liste les équipements disponible dans l'établissement)
