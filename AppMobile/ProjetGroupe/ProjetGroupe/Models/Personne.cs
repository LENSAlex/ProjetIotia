using ProjetGroupe.Models.Manager;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using Syncfusion.Pdf.Grid;
using Syncfusion.Drawing;
using System.IO;
using Xamarin.Forms;
using System.Linq;

namespace ProjetGroupe.Models
{
    /// <summary>
    /// Enum du Type de personne
    /// </summary>
    public enum PersonneType
    {
        /// <summary>
        /// Etudiant
        /// </summary>
        Etudiant = 1,
        /// <summary>
        /// Professeur
        /// </summary>
        Professeur = 2,
        /// <summary>
        /// Personnel Administration / Agent d'entretien
        /// </summary>
        Personnel = 3
    }
    /// <summary>
    /// Classe personne
    /// </summary>

    public class Personne
    {
        private int id;
        private string email;
        private string sexe;
        private string password;
        private PersonneType persType;
        private DateTime anniversaire;
        private string rfid;

        /// <summary>
        /// Id de la personne
        /// </summary>
        public int Id { get => id; set => id = value; }
        /// <summary>
        /// Email de la personne
        /// </summary>
        public string Email { get => email; set => email = value; }
        /// <summary>
        /// Sexe de la personne
        /// </summary>
        public string Sexe { get => sexe; set => sexe = value; }
        /// <summary>
        /// Mot de passe de la personne
        /// </summary>
        public string Password { get => password; set => password = value; }
        /// <summary>
        /// Type de la personne
        /// </summary>
        public PersonneType PersonneType { get => persType; set => persType = value; }
        /// <summary>
        /// anniversaire de la personne
        /// </summary>
        public DateTime Anniversaire { get => anniversaire; set => anniversaire = value; }
        /// <summary>
        /// Identifiant de la personne
        /// </summary>
        public string RFID { get => rfid; set => rfid = value; }
        /// <summary>
        /// Méthode statique permettant de charger une personne spéficique via son Id en contactant la base de données par le biai de la classe Manager
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Une personne</returns>
        public static Personne Load(int id)
        {
            return PersonneManager.Load(id);
        }
        /// <summary>
        /// Méthode statique permettant de charger une personne spéficique via son Email et son mot de passe en contactant la base de données par le biai de la classe Manager
        /// </summary>
        /// <param name="rfid">Identifiant de la personne</param>
        /// <param name="password">mdp de la personne</param>
        /// <returns>Une personne</returns>
        public static Personne Search(string rfid, string password)
        {
            return PersonneManager.Search(rfid, password);
        }
        /// <summary>
        /// Methode Static vérifiant si une personne est connecté ou non à l'application en regardant si son Id est bien en cookie de session
        /// </summary>
        /// <returns></returns>
        public static Personne IsLogged()
        {
            int result = Convert.ToInt32(Xamarin.Essentials.SecureStorage.GetAsync("isLogged").Result);
            if (result == 1)
            {
                int id = Convert.ToInt32(Xamarin.Essentials.SecureStorage.GetAsync("Id").Result);
                Personne Personne = Personne.Load(id);
                if(Personne != null)
                {
                    return Personne;
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }
        /// <summary>
        /// Envoie d'un mail vers le secrétariat avec les informations de la personne en cas de CasCovid
        /// </summary>
        /// <param name="personne">Objet Personne</param>
        /// <returns>true si mail envoyé</returns>
        public bool RappelMail(Personne personne)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(Config.Mail);
                mail.To.Add(Config.MailTo);
                mail.Subject = "Une alerte à été envoyé par un utilisateur à: " + DateTime.Now;
                mail.Body = "<h1 style='text-align:center'>Une alerte vous a été envoyé par l'application Smart E-Covid IUT.</h1>" +
                    "<p>Merci de prévenir les personnes présentent autour de lui au plus vite.</p>" + "Envoyé par: " + personne.Email;

                mail.Headers.Add("Content-Type", "text/html; charset=utf-8");
                mail.Headers.Add("MIME-Version", "1.0");

                mail.IsBodyHtml = true;
                using (SmtpClient smtp = new SmtpClient(Config.MailServer, Convert.ToInt32(Config.MailPort)))
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(Config.Mail, Config.MailPw);
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
                return true;
            }
        }
        /// <summary>
        /// Méthode permettant d'nevoyer une mail au secrétariat avec les informations de l'équipement et de la personne concernant l'information sur la pénurie qu'il a émit
        /// </summary>
        /// <param name="personne">Objet Personne</param>
        /// <param name="penurie">Objet Penurie</param>
        /// <returns>true si mail envoyé</returns>
        public bool RappelMailPenurie(Personne personne, Penurie penurie)
        {
            using (MailMessage mail = new MailMessage())
            {
                mail.From = new MailAddress(Config.Mail);
                mail.To.Add(Config.MailTo);
                mail.Subject = "Une alerte de pénurie d'un produit à été envoyé par un utilisateur à: " + DateTime.Now;
                mail.Body = "<h1 style='text-align:center'>Une alerte de pénurie d'un produit vous a été envoyé par l'application Smart E-Covid IUT.</h1>" +
                    "<p>Envoyé par: " + personne.Email + "</p>" +
                    "<p>Equipement : " + penurie.Id_Equipement + "</p>" +
                    "<p>Salle : " + penurie.SalleId + "</p>";

                mail.Headers.Add("Content-Type", "text/html; charset=utf-8");
                mail.Headers.Add("MIME-Version", "1.0");

                mail.IsBodyHtml = true;
                using (SmtpClient smtp = new SmtpClient(Config.MailServer, Convert.ToInt32(Config.MailPort)))
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(Config.Mail,Config.MailPw);
                    smtp.EnableSsl = true;
                    smtp.Send(mail);
                }
                return true;
            }
        }
        /// <summary>
        /// Méthode static asynchrone générant un PDF et demandanr l'ouverture de celui-ci (avec demande de permission)
        /// </summary>
        /// <param name="size">Le nombre de ligne voulu</param>
        /// <param name="data">La Liste d'historique de valeur à afficher dans le pdf</param>
        public static async void GeneratePdfAsync(int size, List<Historique> data)
        {
            PdfDocument document = new PdfDocument();
            PdfPage page = document.Pages.Add();
            PdfGrid pdfGrid = new PdfGrid();
            PdfGraphics graphics = page.Graphics;
            PdfBrush solidBrush = new PdfSolidBrush(new PdfColor(126, 151, 173));
            RectangleF bounds = new RectangleF(100, 0, 290, 130);
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 16);
            graphics.DrawString("Historique des données 40 dernières données:", font, PdfBrushes.Black, new PointF(0, 0));
            pdfGrid.Draw(page, new PointF(10, 10));

            bounds = new RectangleF(0, bounds.Top + 32, graphics.ClientSize.Width, 30);
            graphics.DrawRectangle(solidBrush, bounds);
            PdfFont subHeadingFont = new PdfStandardFont(PdfFontFamily.TimesRoman, 14);
            PdfTextElement element = new PdfTextElement("Liste des données avec informations: ", subHeadingFont);
            element.Brush = PdfBrushes.White;
            PdfLayoutResult result = element.Draw(page, new PointF(10, bounds.Top + 8));
            string currentDate = "Date: " + DateTime.Now.ToString("dd/MM/yyyy");
            SizeF textSize = subHeadingFont.MeasureString(currentDate);
            PointF textPosition = new PointF(graphics.ClientSize.Width - textSize.Width - 10, result.Bounds.Y);
            graphics.DrawString(currentDate, subHeadingFont, element.Brush, textPosition);
            PdfFont timesRoman = new PdfStandardFont(PdfFontFamily.TimesRoman, 10);
            element = new PdfTextElement("Données: ", timesRoman);
            element.Brush = new PdfSolidBrush(new PdfColor(126, 155, 203));
            result = element.Draw(page, new PointF(10, result.Bounds.Bottom + 25));
            foreach (Historique histo in data.OrderByDescending(x => x.Id_device).Take(size))
            {
                element = new PdfTextElement("#ID: " + histo.Id_device + " | " + "Libelle: " + histo.Libelle + " | " + "LibelleType: " + histo.LibelleType + " | " + "Valeur: " + histo.Valeur + " | " + "Unité: " + histo.Unite, timesRoman);
                element.Brush = new PdfSolidBrush(new PdfColor(126, 155, 203));
                result = element.Draw(page, new PointF(10, result.Bounds.Bottom + 5));
            }
            PdfPen linePen = new PdfPen(new PdfColor(126, 151, 173), 0.70f);
            PointF startPoint = new PointF(0, result.Bounds.Bottom + 3);
            PointF endPoint = new PointF(graphics.ClientSize.Width, result.Bounds.Bottom + 3);
            graphics.DrawLine(linePen, startPoint, endPoint);
            PdfGridCellStyle cellStyle = new PdfGridCellStyle();
            cellStyle.Borders.All = PdfPens.White;
            PdfGridCellStyle headerStyle = new PdfGridCellStyle();
            headerStyle.Borders.All = new PdfPen(new PdfColor(126, 151, 173));
            headerStyle.BackgroundBrush = new PdfSolidBrush(new PdfColor(126, 151, 173));
            headerStyle.TextBrush = PdfBrushes.White;
            headerStyle.Font = new PdfStandardFont(PdfFontFamily.TimesRoman, 14f, PdfFontStyle.Regular);
            cellStyle.Borders.Bottom = new PdfPen(new PdfColor(217, 217, 217), 0.70f);
            cellStyle.Font = new PdfStandardFont(PdfFontFamily.TimesRoman, 12f);
            cellStyle.TextBrush = new PdfSolidBrush(new PdfColor(131, 130, 136));
            PdfGridLayoutFormat layoutFormat = new PdfGridLayoutFormat();
            layoutFormat.Layout = PdfLayoutType.Paginate;
            PdfGridLayoutResult gridResult = pdfGrid.Draw(page, new RectangleF(new PointF(0, result.Bounds.Bottom + 40), new SizeF(graphics.ClientSize.Width, graphics.ClientSize.Height - 100)), layoutFormat);
            MemoryStream stream = new MemoryStream();
            document.Save(stream);
            document.Close(true);
            await DependencyService.Get<ISave>().SaveAndView("DonneesCapteurs-" + Personne.IsLogged().RFID + "-" + DateTime.Now.Day + DateTime.Now.Minute + DateTime.Now.Millisecond + ".pdf", "application/pdf", stream);
        }
    }
}
