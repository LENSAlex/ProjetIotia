using ProjetGroupe.Models;
using Syncfusion.Drawing;
using Syncfusion.Pdf;
using Syncfusion.Pdf.Graphics;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace ProjetGroupe.ViewModels
{
    public class eCovidViewModel : BaseViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<CapteurType> items { get; set; }
        public ObservableCollection<CapteurType> Items
        {
            get
            {
                return items;
            }
            set
            {
                items = value;
                RaisepropertyChanged("Items");
            }
        }
        public async void GetData()
        {
            Items = await CapteurType.List();
        }
        public void RaisepropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public Command ClickedTest { get; }
        public eCovidViewModel()
        {
            Device.BeginInvokeOnMainThread(() => GetData());
            ClickedTest = new Command(OnClickedTestClicked);
        }

        private void OnClickedTestClicked(object obj)
        {
            PdfDocument document = new PdfDocument();

            //Add a page to the document
            PdfPage page = document.Pages.Add();

            //Create PDF graphics for the page
            PdfGraphics graphics = page.Graphics;
             
            //Set the standard font
            PdfFont font = new PdfStandardFont(PdfFontFamily.Helvetica, 20);

            //Draw the text
            graphics.DrawString("Hello World!!!", font, PdfBrushes.Black, new PointF(0, 0));

            //Save the document to the stream
            MemoryStream stream = new MemoryStream();
            document.Save(stream);

            //Close the document
            document.Close(true);

            //Save the stream as a file in the device and invoke it for viewing
            DependencyService.Get<ISave>().SaveAndView("Output.pdf", "application/pdf", stream);
        }
    }
}
