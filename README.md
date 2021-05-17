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

- 7] Dans le fichier appsettings.json vous trouverez également les informations de liaison et les token/clé permettant les accès à certain service de l'application. Là aussi, vous alleze devoir les modifier par les votre. La classe "Config.cs" vous permet  de récupérer depuis n'importe ou, via un Getter/Setter, la chaîne récupérée par le JsonReader du fichier appsettings.json.
- 9] Concernant le bibliothèque de classe, vous avez une hiérarchie qui a été utilisée: Les classes métiers et les classes internes. Les classes métiers sont l'équivalent des tables de la base de données. Les classes internes sont les classes ou se trouvent les méthodes (Get, post, put) vers le serveur nodejs. Grâce au service c#, nous pouvons récupérer un chaîne json et la parser pour remplir les Getter/Setter des classes métiers. Les méthodes sont ensuite récupéré dans les classes métiers étant données que se sont des méthodes "static". Ce qui nous permet de les appeler directement depuis le backend. Ici, chaque méthode (Get, Post, Put) est symbolisé par une méthode (Get => List() (pour une liste) ou Load() pour une ligne spécifique, Post => Save(), Put => Update()). Le principe est de ne pas avoir de requête vers la base de données directement dans le code, donc il faut passer par des webservices, ce sont eux qui font les requêtes SQL.

- 10] Installation du serveur nodejs (Autres collaborateurs)

# Utilisation de l'application:

- 1] Ouvrez l'application
- 2] Vous arrivez ensuite sur une page d'authentification, utiliser vos identifiants de connexion 
- 3] Vous avez ensuite accès aux pages de l'application web et au tableau de bord (Acccuil) avec c'est 3 card clicable et ca bar de navigation a gauche
- 4] Pour crée un Utilisateur , Promotion , Module ou Batiment il vous faul aller dans la bar de navigation et choisir ce que vous voulez créé
- 5] Pour voir un Utilisateur , Promotion , Module ou Batiment il vous faul aller dans la bar de navigation et choisir ce que vous voulez regarder
- 6] Pour modifier un Utilisateur , Promotion , Module ou Batiment il vous faul aller dans la bar de navigation , puis dans la liste d'affichage que vous voulez puit choisir
- 7] Pour supprimer un Utilisateur , Promotion , Module ou Batiment il vous faul aller dans la bar de navigation , puis dans la liste d'affichage que vous voulez puit choisir


# Définitions des WebServices:

- Get sont utiliser pour recupérair est afficher les donnée sur un tableau , le token ou des dropdwon
- Post sont utiliser pour crée des donnée en fonction de ce que vous avez ramplie dans le formulaire 
- Put sont utiliser pour modifier les donnée en fonction de ce que vous avez ramplie dans le formulaire 
- Delete sont utiliser pour supprimer les donnée en fonction de celui que vous avez choisi 


# Documentation:

