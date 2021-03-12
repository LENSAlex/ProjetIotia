using ProjetGroupe.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace ProjetGroupe.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}