using System;
using System.Collections.Generic;
using System.Text;
using S13_LocalDatabase.Models;
using S13_LocalDatabase.DataContext;
using System.Linq;

namespace S13_LocalDatabase.Services
{
    class ArtistaService
    {
        private readonly AppDBContext _context;

        public ArtistaService() => _context = App.GetContext();

        public List<Artista> Get()
        {
            return _context.Artistas.ToList();
        }

        public Artista GetByID(int ID)
        {
            return _context.Artistas.Where(x => x.ArtistaID == ID).FirstOrDefault();
        }
        public void Create(Artista item)
        {
            _context.Artistas.Add(item);
            _context.SaveChanges();
        }

        public void CreateList(List<Artista> items)
        {
            _context.Artistas.AddRange(items);
            _context.SaveChanges();
        }
        public void Update(Artista item, int ID)
        {
            var model = GetByID(ID);
            model.Nombre = item.Nombre;
            model.ArtistaID = item.ArtistaID;
            _context.SaveChanges();
        }
        public void Delete(int ID)
        {
            var model = GetByID(ID);
            _context.Remove(model);
            _context.SaveChanges();
        }

    }
}
