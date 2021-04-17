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

[assembly: Dependency(typeof(SaveAndroid))]
class SaveAndroid : ISave
{
    /// <summary>
    /// Action réalisée après la génération du PDF
    /// </summary>
    /// <param name="fileName">nom du fichier</param>
    /// <param name="contentType">application/pdf</param>
    /// <param name="stream">le fichier sous forme de stream</param>
    /// <returns></returns>
    [Obsolete]
    public async Task SaveAndView(string fileName, String contentType, MemoryStream stream)
    {
        if (ContextCompat.CheckSelfPermission(Forms.Context, Manifest.Permission.WriteExternalStorage) != Permission.Granted)
        {
            ActivityCompat.RequestPermissions((Activity)Forms.Context, new String[] { Manifest.Permission.WriteExternalStorage }, 1);
        }

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
            Forms.Context.StartActivity(Intent.CreateChooser(intent, "Choose App"));
        }
    }
}

