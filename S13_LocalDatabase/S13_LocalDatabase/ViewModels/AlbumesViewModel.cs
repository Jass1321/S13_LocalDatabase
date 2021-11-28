using System;
using System.Collections.Generic;
using System.Text;
using S13_LocalDatabase.Models;
using S13_LocalDatabase.Services;
using S13_LocalDatabase.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;


namespace S13_LocalDatabase.ViewModels
{
    class AlbumesViewModel : BaseViewModel
    {
        #region Services        
        private readonly AlbumService dataServiceAlbumes;
        private readonly ArtistaService dataServiceArtistas;
        #endregion Services

        #region Attributes
        private ObservableCollection<Artista> artistas;
        private ObservableCollection<Album> albumes;
        #endregion Attributes

        #region Properties
        public ObservableCollection<Album> Albumes
        {
            get { return this.albumes; }
            set { SetValue(ref this.albumes, value); }
        }
        public ObservableCollection<Artista> Artistas
        {
            get { return this.artistas; }
            set { SetValue(ref this.artistas, value); }
        }
        #endregion Properties

        #region Command

        public ICommand NeWAlbumCommand
        {
            get
            {
                return new Command(NeWAlbum);
            }
        }

        public ICommand LoadbumesCommand
        {
            get
            {
                return new Command(LoadAlbumes);
            }
        }
        #endregion

        #region Constructor
        public AlbumesViewModel()
        {
            this.dataServiceArtistas = new ArtistaService();
            this.dataServiceAlbumes = new AlbumService();
            this.CreateArtistas();
            this.LoadAlbumes();
        }
        #endregion Constructor

        #region Methods

        private void NeWAlbum()
        {
            Application.Current.MainPage.Navigation.PushAsync(new AlbumPage());
        }
        private void LoadAlbumes()
        {
            var albumesDB = this.dataServiceAlbumes.Get();
            this.Albumes = new ObservableCollection<Album>(albumesDB);
            
            var artistasDB = this.dataServiceArtistas.Get();
            this.Artistas = new ObservableCollection<Artista>(artistasDB); 
        }

        private void CreateArtistas()
        {
            var artistas = new List<Artista>()
            {
                new Artista { Nombre = "Niall Horan" },
                new Artista { Nombre = "Harry Style" },
                new Artista { Nombre = "Louis Tomlinson" },
                new Artista { Nombre = "Liam Payne" },
                new Artista { Nombre = "Zayn Malik" }
            };

            //this.dataServiceArtistas.CreateList(artistas);
        }
        #endregion Methods

    }
}
