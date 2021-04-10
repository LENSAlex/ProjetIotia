# ProjetIotia
Projet fin d'année iotia (projet covid)

Application Web:

Cette application mobile à été développé en .Net Core (C#,html,css,js,json) sous Windows grâce au logiciel Visual Studio. 
Pour utiliser le code de l'application, le modifier vous devez:

- 1] Installer Visual Studio Community 
- 2] Installer les Packages Developpement web et ASP.Net dans le "Visual Studio Installer"

# Création du projet:

- 1] Pour créer un nouveau projet vous devez "Créer un nouveau projet", "Suivant" et choisir "Application web ASP.NET Core".
- 2] Ecrire le Nom de projet , mettre l'emplacement ou ce touve le projet et faire le nom de la solution ,"Suivent"
- 3] Ne rien changer et metre "Suivent"
- 3] les Document principaux sont: wwwroot ou il y a toute les page de css , js et librérie  / Pages ou il y a toute les page du site web avec leur back. Il y a aussi 3 page importente appsettings.json ,Program.cs et Startup.cs.
- 4] La solution du projet est composé avec 1 bibliothèque de classe contenant ces fichiers annoncés précédements et 1 projet runable par un moteur de recherche  (EDGE, FireFox, Chrome). 
- 5] Vous devez ensuite installer plusieur librairies disponible dans les Packages NuGet (clique droit sur le projet dans l'explorateur de solution)
- 5] Liste des Lib: 

Pour la bibliothèque de classe:

- System.Text.Json
- System.Net.HTTP
- Microsoft.Extensions.DependencyInjection
- Microsoft.Extensions.Configuration

Pour le projet Web:

- System.Text.Json
- System.Net.HTTP
- Microsoft.Extensions.DependencyInjection
- Microsoft.Extensions.Configuration

- 6] Pour aller sur  l'application web il vous faux aller sur le lien https://Smart_ECovid_IUT.com (pas encore disponible)


# Installation du projet:

- 1] Téléchargez le .zip et décompressez le dans votre dossier ou est contenu vos projets visual studio
- 2] Vous pouvez également lancer directement le fichier "Smart_ECovid_IUT.sln". En faisant ceci, vous n'avez pas besoin d'installer les dépendances de build.

- 4] Pour obtenir l'application compiler vous devez ensuite: Clique droit sur le projet et choisir "Publier". Le projet va se compiler et dans le dossier de destination vous aurez l'application web .

- 5] Si vous voulez changer les images de l'application, les backgrounds ou autre, il est important de noter que les ressources doivent se trouver dans le dossier "wwwroot/img" .
- 6.2] Si vous voulez changer la police d'écriture, vous avez un dossier "Font" ou vous allez devoir mettre vos polices .ttf. Ensuite, dans le document "wwwroot/css"
- 6.3] Il est aussi important de définir des permissions utilisateurs que l'ont peut modifier quan on vas dans 
- "Liste Uilisateur " ensuite on choise un utilisateur on click sur le stylo et on peut modifier les droit (et aussi tous ce qui et relier a utilisateur)
- 6.4] Il vous faudra aussi une adresse mail d'envois et de réception pour les alertes par emails, celles ci sont à changer dans le appsettings.json

- 7] Le fichier MainActivity.cs est le fichier source ou vous mettrez toutes vos initialisations de plugin par exemple pour les notifications. N'hésitez pas à récupérer celui déjà existant. Vous allez devoir modifier les informations concernant le Hub de notification par vos informations que vous avez pu obtenir en suivant le tutoriel d'installation de Firebase et d'Azure.
- 8] Dans le fichier appsettings.json vous trouverez également les informations de liaison et les token/clé permettant les accès à certain service de l'application. Là aussi, vous alleze devoir les modifier par les votre. La classe "Config.cs" vous permet  de récupérer depuis n'importe ou, via un Getter/Setter, la chaîne récupérée par le JsonReader du fichier appsettings.json.
- 9] Concernant le bibliothèque de classe, vous avez une hiérarchie qui a été utilisée: Les classes métiers et les classes internes. Les classes métiers sont l'équivalent des tables de la base de données. Les classes internes sont les classes ou se trouvent les méthodes (Get, post, put) vers le serveur nodejs. Grâce au service RESTFul de Xamarin, nous pouvons récupérer un chaîne json et la parser pour remplir les Getter/Setter des classes métiers. Les méthodes sont ensuite récupéré dans les classes métiers étant données que se sont des méthodes "static". Ce qui nous permet de les appeler directement depuis le backend. Ici, chaque méthode (Get, Post, Put) est symbolisé par une méthode (Get => List() (pour une liste) ou Load() pour une ligne spécifique, Post => Save(), Put => Update()). Le principe est de ne pas avoir de requête vers la base de données directement dans le code, donc il faut passer par des webservices, ce sont eux qui font les requêtes SQL.
Pour que l'application puisse atteindre le serveur nodejs, il faut lui donner une permission à rajouter dans "AssemblyInfo.cs": [assembly: Application(UsesCleartextTraffic = true)]

- 10] Installation du serveur nodejs (Autres collaborateurs)

# Utilisation de l'application:

- 1] Ouvrez l'application
- 2] Vous arrivez ensuite sur une page d'authentification, utiliser vos identifiants de connexion (Ici nous utilisons ceux de l'IUT)
- 3] Vous avez ensuite accès aux pages de l'application

# Définitions des WebServices:

- Get All Capteur (Liste les capteurs via un select *)
- Post Alerte Covid (Requête post vers la table AlertCovid en envoyé une ligne avec la date et la personne qui à le covid)
- Put Alerte pénurie (Update un produit en stock par un 0 (donc pas en stock))
- Get Capteur de la salle via search (Cherche les capteurs d'une salle via le numéro de salle)
- Get Count des malades d'un salle, bâtiment et iut (Récupère le nombre de malade en fonction de ce qu'on a choisit)
- Get list des équipements pour le stock (Liste les équipements disponible dans l'établissement)

