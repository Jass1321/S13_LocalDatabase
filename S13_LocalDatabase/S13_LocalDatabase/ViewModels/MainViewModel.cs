using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using S13_LocalDatabase.Models;
using S13_LocalDatabase.Services;


namespace S13_LocalDatabase.ViewModels
{
    class MainViewModel : BaseViewModel
    {
        #region Attributes
        private ObservableCollection<MenuItemViewModel> menu;
        #endregion Attributes

        #region Properties
        public ObservableCollection<MenuItemViewModel> Menu
        {
            get { return this.menu; }
            set { SetValue(ref this.menu, value); }
        }
        #endregion Properties

        #region Constructor
        public MainViewModel()
        {
            this.LoadMenu();
            this.SaveArtistasList();
            this.SaveAlbumList();
        }
        #endregion Constructor

        #region Methods
        private void LoadMenu()
        {
            this.Menu = new ObservableCollection<MenuItemViewModel>();

            this.Menu.Clear();
            this.Menu.Add(new MenuItemViewModel { Id = 1, Option = "Crear Album" });
            this.Menu.Add(new MenuItemViewModel { Id = 2, Option = "Lista de Albums" });
            this.Menu.Add(new MenuItemViewModel { Id = 3, Option = "Crear Cancion" });
            this.Menu.Add(new MenuItemViewModel { Id = 4, Option = "Lista de Canciones" });
        }
        #endregion Methods

        DBDataAccess<Artista> dataService = new DBDataAccess<Artista>();
        DBDataAccess<Album> dataServiceAlbum = new DBDataAccess<Album>();
        private void SaveArtistasList()
        {
            var artistas = new List<Artista>()
            {
                new Artista{ Nombre = "Arjona" },
                new Artista{ Nombre = "Luismi" },
                new Artista{ Nombre = "Kalimba" }
            };

            dataService.SaveList(artistas);
        }
        private void SaveAlbumList()
        {
            
            var albumes = new List<Album>()
            {
                new Album { Titulo = "Mind of Mine" },
                new Album { Titulo = "Icarus Falls" },
                new Album { Titulo = "Flicker" },
                new Album { Titulo = "LP1" },
                new Album { Titulo = "Walls" },
                new Album { Titulo = "Midnight Memories" },
                new Album { Titulo = "Up All Night" }
            };

            this.dataServiceAlbum.SaveList(albumes);
        }


    }
}
