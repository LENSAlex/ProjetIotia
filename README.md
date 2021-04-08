# ProjetIotia
Projet fin d'année iotia (projet covid)

Application Mobile:

Cette application mobile à été développé en C# sous Windows grâvce au logiciel Visual Studio. 
Pour utiliser le code de l'application, le modifier vous devez:

1] Installer Visual Studio Community 
2] Installer les Packages Xamarin cross Platform dans le "Visual Studio Installer"
3] Vous devez avoir un smartphone Android en mode développeur qui accepte le débeugage par USB.
4] Un câble pour le brancher à votre ordinateur. Si vous n'avez pas de smartphone, vous pouvez installer des Émulateurs Android via Visual Studio.

Création du projet:

1] Pour créer un nouveau projet vous devez "Créer un nouveau projet", "Suivant" et choisir "Application Shell Cross Platform", veuillez à bien vérifier si Android, IOS et UWP sont présent dans la description du type du projet choisis.
2] Valider les choix. Un projet s'ouvre, les fichiers principaux sont: App.xaml / App.xaml.cs et AppShell.xaml / AppShell.cs.xaml. Ce sont les pages "coeurs" du projet.
3] La solution du projet est composé avec 1 bibliothèque de classe contenant ces fichiers annoncés précédements et 1 projet runable par OS (android, ios, uwp). Sachant que pour IOS et UWP vous devez posséder un MacOs ou un Windows Phone pour le débugage.
4] Vous devez ensuite installer plusieur librairies disponible dans les Packages NuGet (clique droit sur le projet dans l'explorateur de solution)
5] Liste des Lib: 

Pour la bibliothèque de classe:
- PancakeView
- SharedTransitions
- Newtonsoft.Json
- MySqlConnector
- Microsoft.Azure.NotificationHubs
- Syncfusion.Xamarin.pdf (Facultatif)

Pour le projet Android Ios & UWP:

- Newtonsoft.Json
- MySqlConnector
- Microsoft.Azure.NotificationHubs.Android (.Ios .UWP en fonction de l'OS)
- Syncfusion.Xamarin.pdf (Facultatif)
- Xamarin.Firebase.Common
- Xamarin.Firebase.Analytics.impl
- Xamarin.Firebase.Messaging
- Xamarin.Forms
- Xamarin.Google.Dagger
- Xamarin.GooglePlayServices.Base
- Xamarin.GooglePlayServices.Basement

6] Vous devez également vous munir d'un compte Firebase & Azure Notification pour permettre à vos applications de recevoir des notifications push sur le téléphone. 
https://cedgabrang.wixsite.com/xamarintipsandtricks/post/xamarin-forms-implementing-push-notification-using-firebase-cloud-messaging

Installation du projet:

1] Téléchargez le .zip et décompressez le dans votre dossier ou est contenu vos projets visual studio
2] Vous pouvez également lancer directement le fichier "nom-projet.sln". En faisant ceci, vous n'avez pas besoin d'installer les dépendances de build.

3] Vous devez également vous munir d'un compte Firebase & Azure Notification pour permettre à vos applications de recevoir des notifications push sur le téléphone. 
https://cedgabrang.wixsite.com/xamarintipsandtricks/post/xamarin-forms-implementing-push-notification-using-firebase-cloud-messaging
