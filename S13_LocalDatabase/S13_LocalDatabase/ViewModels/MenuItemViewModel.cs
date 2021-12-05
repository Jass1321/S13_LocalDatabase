using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using S13_LocalDatabase.Views;

namespace S13_LocalDatabase.ViewModels
{
    class MenuItemViewModel
    {

        #region Attributes
        public int Id { get; set; }
        public string Option { get; set; }
        public string Icon { get; set; }
        #endregion Attributes

        #region Commands
        public ICommand SelectMenuItemCommand
        {
            get
            {
                return new Command(SelectMenuItemExecute);
            }
        }
        #endregion Commands

        #region Methods
        private void SelectMenuItemExecute()
        {
            if (this.Id == 1)
                Application.Current.MainPage.Navigation.PushAsync(new AlbumPage());
            if (this.Id == 2)
                Application.Current.MainPage.Navigation.PushAsync(new AlbumesPage());
            if (this.Id == 3)
                Application.Current.MainPage.Navigation.PushAsync(new CancionPage());
            else
                Application.Current.MainPage.Navigation.PushAsync(new CancionesPage());
        }
        #endregion Methods

    }
}
