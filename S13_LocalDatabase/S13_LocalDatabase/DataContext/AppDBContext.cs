using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using S13_LocalDatabase.Models;

namespace S13_LocalDatabase.DataContext
{
    public class AppDBContext : DbContext
    {
        string DbPath = string.Empty;

        public AppDBContext(string dbPath)
        {
            this.DbPath = dbPath;
        }

        public DbSet<Artista> Artistas { get; set; }
        public DbSet<Album> Albumes { get; set; }

        public DbSet<Album> Canciones { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={DbPath}");
        }
    }
}
