using Makale_entities;
using System;
using System.Data.Entity;
using System.Linq;

namespace DataDAL
{
    public class DatabaseContext : DbContext // database i�lemleri i�in dbset gerekir burada bir database olu�turduk kay�t tutacak
    {
        public DbSet<Kategori>Kategoriler { get; set; }
        public DbSet<Makale> Makaleler { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Yorum> Yorumlar { get; set; }
        public DbSet<Begeni> Begeniler { get; set; }

        public DatabaseContext()
        {
            Database.SetInitializer(new VeriTaban�Olusturucu());
        }

    }
     

 
}