 using System;
using System.IO;
using Android.Content;
using Java.IO;
using Xamarin.Forms;
using System.Threading.Tasks;
using ProjetGroupe;
using Android.Content.PM;
using Android;
using Android.App;
using AndroidX.Core.App;
using AndroidX.Core.Content;
using System.Drawing;
using Plugin.Permissions;
using Android.Widget;
using Plugin.Permissions.Abstractions;
using ProjetGroupe.Droid;
using Permission = Android.Content.PM.Permission;

[assembly: Dependency(typeof(SaveAndroid))]
class SaveAndroid : ISave
{
    /// <summary>
    /// Action réalisée après la génération du PDF
    /// </summary>
    /// <param name="fileName">nom du fichier</param>
    /// <param name="contentType">application/pdf</param>
    /// <param name="stream">le fichier sous forme de stream</param>
    /// <returns>task</returns>
    [Obsolete]
    public async Task SaveAndView(string fileName, String contentType, MemoryStream stream)
    {
        if (ContextCompat.CheckSelfPermission(Forms.Context, Manifest.Permission.WriteExternalStorage) != Permission.Granted)
        {
            ActivityCompat.RequestPermissions((Activity)Forms.Context, new String[] { Manifest.Permission.WriteExternalStorage }, 1);
        }
        //Création de dossier SmartCovid 
        string newRoot = Android.App.Application.Context.GetExternalFilesDir(null).AbsolutePath;
        Java.IO.File myDir = new Java.IO.File(newRoot + "/SmartCovid");
        Directory.CreateDirectory(myDir.ToString());
        Java.IO.File file = new Java.IO.File(myDir, fileName);
        if (file.Exists()) file.Delete();

        FileOutputStream outs = new FileOutputStream(file);
        outs.Write(stream.ToArray());

        outs.Flush();
        outs.Close();

        if (file.Exists())
        {
            Android.Net.Uri path = FileProvider.GetUriForFile(Forms.Context.ApplicationContext, "com.company.projetgroupe", file);
            string extension = Android.Webkit.MimeTypeMap.GetFileExtensionFromUrl(Android.Net.Uri.FromFile(file).ToString());
            string mimeType = Android.Webkit.MimeTypeMap.Singleton.GetMimeTypeFromExtension(extension);
            Intent intent = new Intent(Intent.ActionView);
            intent.SetDataAndType(path, mimeType);
            intent.AddFlags(ActivityFlags.GrantReadUriPermission);
            Forms.Context.StartActivity(Intent.CreateChooser(intent, "Choisir l'application"));
        }
    }
    /// <summary>
    /// Méthode pour ouvrir la galerie du smartphone
    /// </summary>
    /// <returns>task</returns>
    public async Task OpenGallery()
    {
        try
        {
            ActivityCompat.RequestPermissions((Activity)Forms.Context, new string[] { Manifest.Permission.WriteExternalStorage }, 1);
            var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Plugin.Permissions.Abstractions.Permission.Storage);
            if (status != PermissionStatus.Granted)
            {
                if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Plugin.Permissions.Abstractions.Permission.Storage))
                {
                    Toast.MakeText(Forms.Context, "Besoin de la permission de stockage activée", ToastLength.Long).Show();
                }

                var results = await CrossPermissions.Current.RequestPermissionsAsync(new[] { Plugin.Permissions.Abstractions.Permission.Storage });
                status = results[Plugin.Permissions.Abstractions.Permission.Storage];
            }

            if (status == PermissionStatus.Granted)
            {
                Toast.MakeText(Forms.Context, "Sélectionnez une photo", ToastLength.Long).Show();
                var imageIntent = new Intent(
                    Intent.ActionPick);
                imageIntent.SetType("image/*");
                imageIntent.PutExtra(Intent.ExtraAllowMultiple, true);
                imageIntent.SetAction(Intent.ActionGetContent);
                ((Activity)Forms.Context).StartActivityForResult(
                    Intent.CreateChooser(imageIntent, "Select photo"), MainActivity.OPENGALLERYCODE);

            }
            else if (status != PermissionStatus.Unknown)
            {
                Toast.MakeText(Forms.Context, "Permission refusée", ToastLength.Long).Show();
            }
        }
        catch (Exception ex)
        {
            Toast.MakeText(Forms.Context, "Erreur lors de l'upload de la photo", ToastLength.Long).Show();
        }
    }
    /// <summary>
    /// Permet d'envoyer un message d'erreur ou non qui disparaît juste après
    /// </summary>
    public void DisplayAlert(string message)
    {
        Toast.MakeText(Forms.Context, message, ToastLength.Short).Show();
    }

}

