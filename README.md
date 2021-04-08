# ProjetIotia
Projet fin d'année iotia (projet covid)

Application Mobile:

Cette application mobile à été développé en C# sous Windows grâce au logiciel Visual Studio. 
Pour utiliser le code de l'application, le modifier vous devez:

- 1] Installer Visual Studio Community 
- 2] Installer les Packages Xamarin cross Platform dans le "Visual Studio Installer"
- 3] Vous devez avoir un smartphone Android en mode développeur qui accepte le débeugage par USB.
- 4] Un câble pour le brancher à votre ordinateur. Si vous n'avez pas de smartphone, vous pouvez installer des Émulateurs Android via Visual Studio.

# Création du projet:

- 1] Pour créer un nouveau projet vous devez "Créer un nouveau projet", "Suivant" et choisir "Application Shell Cross Platform", veuillez à bien vérifier si Android, IOS et UWP sont présent dans la description du type du projet choisis.
- 2] Valider les choix. Un projet s'ouvre, les fichiers principaux sont: App.xaml / App.xaml.cs et AppShell.xaml / AppShell.cs.xaml. Ce sont les pages "coeurs" du projet.
- 3] La solution du projet est composé avec 1 bibliothèque de classe contenant ces fichiers annoncés précédements et 1 projet runable par OS (android, ios, uwp). Sachant que pour IOS et UWP vous devez posséder un MacOs ou un Windows Phone pour le débugage.
- 4] Vous devez ensuite installer plusieur librairies disponible dans les Packages NuGet (clique droit sur le projet dans l'explorateur de solution)
- 5] Liste des Lib: 

Pour la bibliothèque de classe:

- PancakeView (Composant XAML)
- SharedTransitions (Composant XAML)
- Newtonsoft.Json (Json Parser)
- MySqlConnector (Liaison MySQL (falc))
- Microsoft.Azure.NotificationHubs (Notification)
- Syncfusion.Xamarin.pdf (Facultatif)

Pour le projet Android Ios & UWP:

- Newtonsoft.Json (Json Parser)
- MySqlConnector (Liaison MySQL (falc))
- Microsoft.Azure.NotificationHubs.Android (.Ios .UWP en fonction de l'OS)
- Syncfusion.Xamarin.pdf (Facultatif)
- Xamarin.Firebase.Common (Notification)
- Xamarin.Firebase.Analytics.impl (Analytics des Notifications)
- Xamarin.Firebase.Messaging (Notification Hub)
- Xamarin.Forms (Composants)
- Xamarin.Google.Dagger (Service)
- Xamarin.GooglePlayServices.Base (Service Google)
- Xamarin.GooglePlayServices.Basement (Service Google)

- 6] Vous devez également vous munir d'un compte Firebase & Azure Notification pour permettre à vos applications de recevoir des notifications push sur le téléphone. 
https://cedgabrang.wixsite.com/xamarintipsandtricks/post/xamarin-forms-implementing-push-notification-using-firebase-cloud-messaging

- 7] Pour obtenir l'application compiler vous devez ensuite: Clique droit sur le projet (Android, Ios ou UWP) et choisir "Publier". Le projet va se compiler et dans le dossier de destination vous aurez l'application que vous pourrez partager aux utilisateurs via un lien de téléchargement ou une plateforme tel que le PlayStore.
- 8] Vous devez ensuite accepter les "Applications de source inconnu" si l'application est obtenu via un lien de téléchargement sur un site internet par exemple.

# Installation du projet:

- 1] Téléchargez le .zip et décompressez le dans votre dossier ou est contenu vos projets visual studio
- 2] Vous pouvez également lancer directement le fichier "nom-projet.sln". En faisant ceci, vous n'avez pas besoin d'installer les dépendances de build.

- 3] Vous devez également vous munir d'un compte Firebase & Azure Notification pour permettre à vos applications de recevoir des notifications push sur le téléphone. 
https://cedgabrang.wixsite.com/xamarintipsandtricks/post/xamarin-forms-implementing-push-notification-using-firebase-cloud-messaging

- 4] Pour obtenir l'application compiler vous devez ensuite: Clique droit sur le projet (Android, Ios ou UWP) et choisir "Publier". Le projet va se compiler et dans le dossier de destination vous aurez l'application que vous pourrez partager aux utilisateurs via un lien de téléchargement ou une plateforme tel que le PlayStore.
- 5] Vous devez ensuite accepter les "Applications de source inconnu" si l'application est obtenu via un lien de téléchargement sur un site internet par exemple.
- 6] Si vous voulez changer les images de l'application, les backgrounds ou autre, il est important de noter que les ressources doivent se trouver dans le dossier "Ressource" de chaque OS. Pour android vous les trouverez dans "Ressource/drawable" et vous avez aussi un dossier pour chaque taille d'écran. 
- 6.2] Si vous voulez changer la police d'écriture, vous avez un dossier "Font" ou vous allez devoir mettre vos polices .ttf. Ensuite, dans le fichier "AssemblyInfo.cs", vous devez écrire cette ligne: [assembly: ExportFont("Roboto-Regular.ttf", Alias = "Roboto")]
- 6.3] Il est aussi important de définir des permissions utilisateurs notament l'accès à internet, la lecture et l'écriture. [assembly:UsesPermission(Android.Manifest.Permission.Internet)]
[assembly:UsesPermission(Android.Manifest.Permission.WriteExternalStorage)]
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
