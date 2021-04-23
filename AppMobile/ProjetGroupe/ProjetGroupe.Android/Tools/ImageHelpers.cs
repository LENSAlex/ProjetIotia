using Android;
using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Graphics;
using Android.Media;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AndroidX.Core.App;
using AndroidX.Core.Content;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Bitmap = Android.Graphics.Bitmap;

namespace ProjetGroupe.Droid.Tools
{
	/// <summary>
	/// Classe Permettant de gérer l'upload des images de profil
	/// </summary>
	public static class ImageHelpers
	{
		/// <summary>
		/// Méthoqui permet de sauvegarder la photo dans les dossiers de l'application
		/// </summary>
		/// <param name="collectionName">collectionName</param>
		/// <param name="imageByte">L'image au format binaire</param>
		/// <param name="fileName">le nom de l'image</param>
		/// <returns>l'uri de l'image</returns>
		public static string SaveFile(string collectionName, byte[] imageByte, string fileName)
		{
			ActivityCompat.RequestPermissions((Activity)Forms.Context, new String[] { Manifest.Permission.WriteExternalStorage }, 1);
			string newRoot = Android.App.Application.Context.GetExternalFilesDir(null).AbsolutePath;
			Java.IO.File myDir = new Java.IO.File(newRoot + "/Images");
			Directory.CreateDirectory(myDir.ToString());
			Java.IO.File file = new Java.IO.File(myDir, fileName);
			if (file.Exists()) file.Delete();
			File.WriteAllBytes(file.Path, imageByte);
			return file.Path;
		}
		/// <summary>
		/// Permet de choisir la rotation de l'image
		/// </summary>
		/// <param name="path"></param>
		/// <returns>l'image au format binaire</returns>
		public static byte[] RotateImage(string path)
		{
			byte[] imageBytes;

			var originalImage = BitmapFactory.DecodeFile(path);
			var rotation = GetRotation(path);
			var width = (originalImage.Width * 0.25);
			var height = (originalImage.Height * 0.25);
			var scaledImage = Bitmap.CreateScaledBitmap(originalImage, (int)width, (int)height, true);

			Bitmap rotatedImage = scaledImage;
			if (rotation != 0)
			{
				var matrix = new Matrix();
				matrix.PostRotate(rotation);
				rotatedImage = Bitmap.CreateBitmap(scaledImage, 0, 0, scaledImage.Width, scaledImage.Height, matrix, true);
				scaledImage.Recycle();
				scaledImage.Dispose();
			}

			using (var ms = new MemoryStream())
			{
				rotatedImage.Compress(Bitmap.CompressFormat.Jpeg, 90, ms);
				imageBytes = ms.ToArray();
			}

			originalImage.Recycle();
			rotatedImage.Recycle();
			originalImage.Dispose();
			rotatedImage.Dispose();
			GC.Collect();

			return imageBytes;
		}
		/// <summary>
		/// Méthode qui récupère les type de rotations
		/// </summary>
		/// <param name="filePath">URI de l'image</param>
		/// <returns>int (Rotation)</returns>
		private static int GetRotation(string filePath)
		{
			using (var ei = new ExifInterface(filePath))
			{
				var orientation = (Android.Media.Orientation)ei.GetAttributeInt(ExifInterface.TagOrientation, (int)Android.Media.Orientation.Normal);

				switch (orientation)
				{
					case Android.Media.Orientation.Rotate90:
						return 90;
					case Android.Media.Orientation.Rotate180:
						return 180;
					case Android.Media.Orientation.Rotate270:
						return 270;
					default:
						return 0;
				}
			}
		}
	}
}
