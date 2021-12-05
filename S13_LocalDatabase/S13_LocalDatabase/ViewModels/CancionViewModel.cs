using System;
using System.Collections.Generic;
using System.Text;

using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.Linq;


using S13_LocalDatabase.Models;
using S13_LocalDatabase.Services;
using S13_LocalDatabase.Views;


namespace S13_LocalDatabase.ViewModels
{
    class CancionViewModel : BaseViewModel
    {
        #region Services
        private readonly DBDataAccess<Cancion> dataServiceCanciones;
        private readonly DBDataAccess<Album> dataServiceAlbumes;
        private readonly DBDataAccess<Artista> dataServiceArtistas;
        #endregion Services

        #region Attributes
        private ObservableCollection<Artista> artistas;
        private ObservableCollection<Album> albumes;
        private ObservableCollection<Cancion> canciones;
        private Album selectedAlbum;
        private string name;
        private bool like;
        private int fechaEstreno;
        private int time;
        #endregion Attributes

        #region Properties
        public ObservableCollection<Artista> Artistas
        {
            get { return this.artistas; }
            set { SetValue(ref this.artistas, value); }
        }

        public ObservableCollection<Album> Albumes
        {
            get { return this.albumes; }
            set { SetValue(ref this.albumes, value); }
        }
        public ObservableCollection<Cancion> Canciones
        {
            get { return this.canciones; }
            set { SetValue(ref this.canciones, value); }
        }

        public Album SelectedAlbum
        {
            get { return this.selectedAlbum; }
            set { SetValue(ref this.selectedAlbum, value); }
        }

        public string Name
        {
            get { return this.name; }
            set { SetValue(ref this.name, value); }
        }

        public bool Like
        {
            get { return this.like; }
            set { SetValue(ref this.like, value); }
        }
        public int Time
        {
            get { return this.time; }
            set { SetValue(ref this.time, value); }
        }

        public int FechaEstreno
        {
            get { return this.fechaEstreno; }
            set { SetValue(ref this.fechaEstreno, value); }
        }
        #endregion Properties

        #region Commands
        public ICommand CreateCommand
        {
            get
            {
                return new Command(async () =>
                {
                    var newCancion = new Cancion()
                    {
                        AlbumID = this.SelectedAlbum.AlbumID,
                        Name = this.Name,
                        Like = this.Like,
                        FechaEstreno = this.FechaEstreno,
                        Time = this.Time
                    };

                    if (newCancion != null)
                    {
                        if (this.dataServiceCanciones.Create(newCancion))
                        {
                            await Application.Current.MainPage.DisplayAlert("Operación Exitosa",
                                                                            $"Cancion del Album: {this.selectedAlbum.Titulo} " +
                                                                            $"creado correctamente en la base de datos",
                                                                            "Ok");

                            this.SelectedAlbum = null;
                            this.Name = string.Empty;
                            this.Like = true;
                            this.FechaEstreno = DateTime.Now.Year;
                            this.time = 0;
                        }

                        else
                            await Application.Current.MainPage.DisplayAlert("Operación Fallida",
                                                                            $"Error al crear el Albúm en la base de datos",
                                                                            "Ok");
                    }
                });
            }
        }
        #endregion Commands
        #region Constructor
        public CancionViewModel()
        {
            this.dataServiceAlbumes = new DBDataAccess<Album>();
            this.dataServiceCanciones = new DBDataAccess<Cancion>();

            this.CreateAlbumes();

            this.LoadAlbumes();
            this.LoadCanciones();

            this.fechaEstreno = DateTime.Now.Year;
        }
        #endregion Constructor

        #region Methods

        private void LoadAlbumes()
        {
            var albumesDB = this.dataServiceAlbumes.Get(null, null, "Album").ToList() as List<Album>;
            this.Albumes = new ObservableCollection<Album>(albumesDB);
        }

        private void LoadCanciones()
        {
            var cancionesDB = this.dataServiceCanciones.Get(null, null, "Cancion").ToList() as List<Cancion>;
            this.Canciones = new ObservableCollection<Cancion>(cancionesDB);
        }


        private void CreateAlbumes()
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

           this.dataServiceAlbumes.SaveList(albumes);
        }
        #endregion Methods
    }
}
