using Makale_entities;
using System;
using System.Data.Entity;
using System.Linq;

namespace DataDAL
{
    public class DatabaseContext : DbContext // database iþlemleri için dbset gerekir burada bir database oluþturduk kayýt tutacak
    {
        public DbSet<Kategori>Kategoriler { get; set; }
        public DbSet<Makale> Makaleler { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<Yorum> Yorumlar { get; set; }
        public DbSet<Begeni> Begeniler { get; set; }

        public DatabaseContext()
        {
            Database.SetInitializer(new VeriTabanýOlusturucu());
        }

    }
     

 
}