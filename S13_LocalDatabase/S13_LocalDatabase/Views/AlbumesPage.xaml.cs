using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S13_LocalDatabase.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace S13_LocalDatabase.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlbumesPage : ContentPage
    {
        public AlbumesPage()
        {
            InitializeComponent();
            this.BindingContext = new AlbumesViewModel();
        }
    }
}