# Projet E-Covid

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
- 3] La solution du projet est composé avec 1 bibliothèque de classe contenant ces fichiers annoncés précédements et 1 projet runable par OS (android, ios, uwp). Sachant que pour IOS et UWP vous devez posséder un MacOs ou un Windows Phone pour le débugage. Effectivement, Apple ne permet pas l'émulation et la compilation sur des machines Windows. Si vous choisissez les environements Windows Phone (UWP), il est fort probable que les émulateurs soient téléchargeables directement dans visual studio.

- 4] Vous devez ensuite installer plusieur librairies disponible dans les Packages NuGet (clique droit sur le projet dans l'explorateur de solution)
- 5] Liste des Lib: 

Pour la bibliothèque de classe:

- ```PancakeView``` (Composant XAML)
- ```SharedTransitions``` (Composant XAML)
- ```Newtonsoft.Json``` (Json Parser)
- ```MySqlConnector``` (Liaison MySQL (falc))
- ```Microsoft.Azure.NotificationHubs``` (Notification)
- ```Syncfusion.Xamarin.pdf``` (Generation de Pdf)

Pour le projet Android Ios & UWP:

- ```Newtonsoft.Json``` (Json Parser)
- ```MySqlConnector``` (Liaison MySQL (falc))
- ```Microsoft.Azure.NotificationHubs.Android``` (.Ios .UWP en fonction de l'OS)
- ```Syncfusion.Xamarin.pdf``` (Facultatif)
- ```Xamarin.Firebase.Common``` (Notification)
- ```Xamarin.Firebase.Analytics.impl``` (Analytics des Notifications)
- ```Xamarin.Firebase.Messaging``` (Notification Hub)
- ```Xamarin.Forms``` (Composants)
- ```Xamarin.Google.Dagger``` (Service)
- ```Xamarin.GooglePlayServices.Base``` (Service Google)
- ```Xamarin.GooglePlayServices.Basement``` (Service Google)

- 6] Vous devez également vous munir d'un compte Firebase & Azure Notification pour permettre à vos applications de recevoir des notifications push sur le téléphone. 
https://cedgabrang.wixsite.com/xamarintipsandtricks/post/xamarin-forms-implementing-push-notification-using-firebase-cloud-messaging
Notification via AzureHub: https://docs.microsoft.com/en-us/azure/developer/mobile-apps/notification-hubs-backend-service-xamarin-forms

- 7] Pour obtenir l'application compiler vous devez ensuite: Clique droit sur le projet (Android, Ios ou UWP) et choisir "Publier". Le projet va se compiler et dans le dossier de destination vous aurez l'application que vous pourrez partager aux utilisateurs via un lien de téléchargement ou une plateforme tel que le PlayStore.
- 8] Vous devez ensuite accepter les "Applications de source inconnu" si l'application est obtenu via un lien de téléchargement sur un site internet par exemple.

- 9] Si vous voulez changer les images de l'application, les backgrounds ou autre, il est important de noter que les ressources doivent se trouver dans le dossier "Ressource" de chaque OS. Pour android vous les trouverez dans "Ressource/drawable" et vous avez aussi un dossier pour chaque taille d'écran. 
- 9.2] Si vous voulez changer la police d'écriture, vous avez un dossier "Font" ou vous allez devoir mettre vos polices .ttf. Ensuite, dans le fichier "AssemblyInfo.cs", vous devez écrire cette ligne: 
```[assembly: ExportFont("Roboto-Regular.ttf", Alias = "Roboto")]```
- 9.3] Il est aussi important de définir des permissions utilisateurs notament l'accès à internet, la lecture et l'écriture. ```[assembly:UsesPermission(Android.Manifest.Permission.Internet)]```
```[assembly:UsesPermission(Android.Manifest.Permission.WriteExternalStorage)]```

- 9.4] Dans le fichier "AndroidManifest.xml" se trouvant dans le dossier "Properties"; Il vous faudra ajouter les permissions suivantes:

```
	<uses-permission android:name="android.permission.ACCESS_NETWORK_STATE" />
	<uses-permission android:name="com.google.android.c2dm.permission.RECEIVE" />
	<uses-permission android:name="android.permission.WAKE_LOCK" />
	<uses-permission android:name="android.permission.GET_ACCOUNTS"/>
	<uses-permission android:name="android.permission.READ_EXTERNAL_STORAGE" />
	<uses-permission android:name="android.permission.WRITE_EXTERNAL_STORAGE" />
```
- 9.5] Pour la génération de pdf il vous faudra renseigner à l'application l'endroit ou se trouve les dossiers ou s'ouvriront les fichers de l'Intent (action d'ouverture de pdf ou autres depuis l'application). Toujours dans l'AndroidManisfest placez ce bout de code dans la balise application tel que:
``` 
<application>
  	<provider android:name="androidx.core.content.FileProvider" android:authorities="com.company.projetgroupe" android:exported="false" android:grantUriPermissions="true">
		<meta-data android:name="android.support.FILE_PROVIDER_PATHS" android:resource="@xml/filepath"></meta-data>
	</provider>
</application>
```
Vous allez maintenant devoir créer un dossier xml dans votre dossier Ressource de votre Projet.Droid et y placer filepath.xml qui est un fichier que vous allez aussi créer et mettre:
```
<?xml version="1.0" encoding="utf-8"?>
<paths xmlns:android="http://schemas.android.com/apk/res/android">
	<external-files-path name="filepath" path="."/>
</paths>
```
Une fois cela fait le code dans le fichier SaveAndroid.cs pourra s'exécuter correctement.

- 10] Le fichier MainActivity.cs est le fichier source ou vous mettrez toutes vos initialisations de plugin par exemple pour les notifications. N'hésitez pas à récupérer celui déjà existant. Vous allez devoir modifier les informations concernant le Hub de notification par vos informations que vous avez pu obtenir en suivant le tutoriel d'installation de Firebase et d'Azure.

- 11] Dans le fichier appsettings.json vous trouverez également les informations de liaison et les token/clé permettant les accès à certain service de l'application. Là aussi, vous alleze devoir les modifier par les votre. La classe "Config.cs" vous permet  de récupérer depuis n'importe ou, via un Getter/Setter, la chaîne récupérée par le JsonReader du fichier appsettings.json. (le appsettings.json est compilé dans la dll du projet. (Pour modifier les valeur il faut charger le projet dans Visual Studio puis recompiler)
- 11.1] 2 types de mails sont présents dans l'application, vous pouvez modifier la configuration du server smtp et les mail d'envois et de réceptions.

- 12] Concernant le bibliothèque de classe, vous avez une hiérarchie qui a été utilisée: Les classes métiers et les classes internes. Les classes métiers sont l'équivalent des tables de la base de données. Les classes internes sont les classes ou se trouvent les méthodes (Get, post, put) vers le serveur nodejs. Grâce au service RESTFul de Xamarin, nous pouvons récupérer un chaîne json et la parser pour remplir les Getter/Setter des classes métiers. Les méthodes sont ensuite récupéré dans les classes métiers étant données que se sont des méthodes "static". Ce qui nous permet de les appeler directement depuis le backend. Ici, chaque méthode (Get, Post, Put) est symbolisé par une méthode (Get => List() (pour une liste) ou Load() pour une ligne spécifique, Post => Save(), Put => Update()). Le principe est de ne pas avoir de requête vers la base de données directement dans le code, donc il faut passer par des webservices, ce sont eux qui font les requêtes SQL.
Pour que l'application puisse atteindre le serveur nodejs, il faut lui donner une permission à rajouter dans "AssemblyInfo.cs": 
```[assembly: Application(UsesCleartextTraffic = true)]```

- 13] Autres: Lors de la compilation du projet sur le smartphone veillez à ce que vos images, frames et pages, soient responsives, c'est à dire qu'elle s'affichent bien (margin, padding) sur chaque Device. 


# Installation du projet:

- 1] Téléchargez le .zip et décompressez le dans votre dossier ou est contenu vos projets visual studio
- 2] Vous pouvez également lancer directement le fichier "nom-projet.sln". En faisant ceci, vous n'avez pas besoin d'installer les dépendances de build.

- 3] Vous devez également vous munir d'un compte Firebase & Azure Notification pour permettre à vos applications de recevoir des notifications push sur le téléphone. 
https://cedgabrang.wixsite.com/xamarintipsandtricks/post/xamarin-forms-implementing-push-notification-using-firebase-cloud-messaging
Notification via AzureHub: https://docs.microsoft.com/en-us/azure/developer/mobile-apps/notification-hubs-backend-service-xamarin-forms

- 4] Pour obtenir l'application compiler vous devez ensuite: Clique droit sur le projet (Android, Ios ou UWP) et choisir "Publier". Le projet va se compiler et dans le dossier de destination vous aurez l'application que vous pourrez partager aux utilisateurs via un lien de téléchargement ou une plateforme tel que le PlayStore.
- 5] Vous devez ensuite accepter les "Applications de source inconnu" si l'application est obtenu via un lien de téléchargement sur un site internet par exemple.

- 6] Autres: Lors de la compilation du projet sur le smartphone veillez à ce que vos images, frames et pages, soient responsives, c'est à dire qu'elle s'affichent bien (margin, padding) sur chaque Device. 

- 7] Installation du serveur nodejs (Autres collaborateurs)

# Utilisation de l'application:

- 1] Ouvrez l'application
- 2] Vous arrivez ensuite sur une page d'authentification, utiliser vos identifiants de connexion (Ici nous utilisons ceux de l'IUT)
- 3] Vous avez ensuite accès aux pages de l'application
- 4] Il est important de noter qu'à votre connexion à l'application (une fois le bouton connexion pressé), vous serrez ammener à accepter les notifications push car votre smartphone sera enregistré au Hub de Notification Azure via Firebase. Egalement si vous voulez générer un pdf, on vous demandera d'activté ou non les droits d'écriture.

Les fichiers générés sont engeristé dans: "android/data/com.company.projetgroupe/files/SmartCovid/" pour les appareis Android.

# Notification API

- Pour pouvoir envoyer des notifications push à tout le monde lors d'une alerte de covid-19. Il faut créer une API application web sur Visual Studio.
Voici un tutoriel d'installation de l'api sur Azure via votre compte Etudiant ou Entreprise.
https://docs.microsoft.com/en-us/azure/developer/mobile-apps/notification-hubs-backend-service-xamarin-forms

- Attention ! A chaque nouveau projet (ou changement d'ordinateur pour la compilation) vous devez remettre les user-secrets. Vous devez vous positionner dans votre répertoire "NotificationAPI" et executé en ligne de commande (via GitBash par exemple) :

```dotnet user-secrets set "NotificationHub:ConnectionString" "Endpoint=sb://suitedevotreendpoint"```

```dotnet user-secrets set "NotificationHub:Name" "NomDuProjet"```

Après avoir mit en ligne l'API, il est possible de tester l'envoie de notification avec postman:
Envoyez une requête POST sur https://nomduprojet.azurewebsites.net/api/notifications/requests avec votre body un json tel que
```
{
    "text": "Alerte Covid",
    "action": "action_a"
}
```
Pour envoyer une notification, envoyez simplement un requête post via la librairie HttpClient de Visual Studio et en lui envoyant votre chaîne json.
Il est aussi important de noter que pour recevoir convenablement les notifications, il faut que votre smartphone aie la dernière version de l'application, sinon le Hub de Notification n'arrive pas à vous retrouver étant donnée que la compilation et l'installation change certaines données uniques dont l'API a besoin. Il va aussi de soit que si vous avez l'application ouverte, vous ne recevrai pas de notification, mais une alerte via une popup directement sur votre écran (sauf si vous êtes l'expéditeur de l'alerte)

# Définitions des WebServices:

- Get All Capteur (Liste les capteurs via un select *)  OK 
- Post Alerte Covid (Requête post vers la table AlertCovid en envoyé une ligne avec la date et la personne qui à le covid) OK
- Put Alerte pénurie (Update un produit en stock par un 0 (donc pas en stock)) OK
- Get All Salle de la personne connecté (Select *) OK
- Get Capteur de la salle via search (Cherche les capteurs d'une salle via le numéro de salle) OK
- Get Count des malades d'un salle, bâtiment et iut (Récupère le nombre de malade en fonction de ce qu'on a choisit) OK
- Get list des équipements pour le stock (Liste les équipements disponible dans l'établissement) OK
- Get Historique by CapteurId (Liste les données du Capteur choisi) OK
- Get Historique des capteurs (Liste toute les données) OK 
- Get Historique Valeur Moyenne d'un Capteur (donne la ligne du capteur avec sa moyenne via son Id) OK 
- Get Historique Dernière Valeur d'un Capteur (donne la ligne du capteur avec sa dernière valeur (la plus récente) via son Id) OK
- Post (envoie un text et une action à une API en ligne sur les service d'azure) OK

# Documentation 

- Vous allez pouvoir trouver la documentation XML de la bibliothèque de classe nommée "ProjetGroupe" et celle du ProjetDroid dans le dossier Documentation/AppMobile
- Vous allez pouvoir télécharger la document Doxygen du projet global via Github sinon vous pouvez vous rendre sur ce lien:
[Test] (http://51.77.137.170/lpiotia/AppMobile/ProjetDroid_Documentation/index.html)

