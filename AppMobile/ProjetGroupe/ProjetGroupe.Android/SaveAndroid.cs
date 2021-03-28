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
    //Method to save document as a file in Android and view the saved document
    [Obsolete]
    public async Task SaveAndView(string fileName, String contentType, MemoryStream stream)
    {

        string root = null;

        if (ContextCompat.CheckSelfPermission(Forms.Context, Manifest.Permission.WriteExternalStorage) != Permission.Granted)
        {
            ActivityCompat.RequestPermissions((Android.App.Activity)Forms.Context, new String[] { Manifest.Permission.WriteExternalStorage }, 1);
        }

        //Get the root path in android device.
        //if (Android.OS.Environment.IsExternalStorageEmulated)
        //{
        // root = Android.OS.Environment.ExternalStorageDirectory.ToString();
        //}
        //else
        string newRoot = Android.App.Application.Context.GetExternalFilesDir(null).AbsolutePath;
       // root = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        //Create directory and file 
        Java.IO.File myDir = new Java.IO.File(newRoot + "/SmartCovid");
       // myDir.Mkdir();
        Directory.CreateDirectory(myDir.ToString());
        Java.IO.File file = new Java.IO.File(myDir, fileName);

        //Remove if the file exists
        if (file.Exists()) file.Delete();

        //Write the stream into the file
        FileOutputStream outs = new FileOutputStream(file);
        outs.Write(stream.ToArray());

        outs.Flush();
        outs.Close();

        //Invoke the created file for viewing
        if (file.Exists())
        {
            Android.Net.Uri path = Android.Net.Uri.FromFile(file);
            string extension = Android.Webkit.MimeTypeMap.GetFileExtensionFromUrl(Android.Net.Uri.FromFile(file).ToString());
            string mimeType = Android.Webkit.MimeTypeMap.Singleton.GetMimeTypeFromExtension(extension);
            Intent intent = new Intent(Intent.ActionView);
            intent.SetDataAndType(path, mimeType);
            Forms.Context.StartActivity(Intent.CreateChooser(intent, "Choose App"));

            //string extension = Android.Webkit.MimeTypeMap.GetFileExtensionFromUrl(Android.Net.Uri.FromFile(file).ToString());
            //string mimeType = Android.Webkit.MimeTypeMap.Singleton.GetMimeTypeFromExtension(extension);
            //Intent intent = new Intent(Intent.ActionView);
            //intent.SetFlags(ActivityFlags.ClearTop | ActivityFlags.NewTask);
            //Android.Net.Uri path = FileProvider.GetUriForFile(Forms.Context, Android.App.Application.Context.PackageName + ".provider", file);
            //intent.SetDataAndType(path, mimeType);
            //intent.AddFlags(ActivityFlags.GrantReadUriPermission);
            //Forms.Context.StartActivity(Intent.CreateChooser(intent, "Choose App"));
        }
    }
}

