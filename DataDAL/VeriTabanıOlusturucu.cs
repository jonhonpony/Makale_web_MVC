﻿using Makale_entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataDAL
{

    public class VeriTabanıOlusturucu : CreateDatabaseIfNotExists<DatabaseContext>//burada vreate database not exist in seed metodunu burassı çalıştığı anda kullanabilmek için kalıtım ettik
    {
        
        protected override void Seed(DatabaseContext context)
        {
            Kullanici admin = new Kullanici()
            {
                Adi = "Elif",
                Soyad = "Cengiz",
                Email = "cenelif@gmail.com",
                Admin = true,
                Aktif = true,
                KullaniciAdi = "elif",
                Sifre = "123",
                AktivasyonKodu = Guid.NewGuid(),
                KayitTarihi = DateTime.Now,
                DegistirmeTarihi = DateTime.Now.AddMinutes(5),
                DegistirenKullanici = "elif"
            };

            context.Kullanicilar.Add(admin);

            for (int i = 1; i < 6; i++)
            {
                Kullanici k = new Kullanici()
                {
                    Adi = FakeData.NameData.GetFirstName(),
                    Soyad = FakeData.NameData.GetSurname(),
                    Admin = false,
                    Aktif = true,
                    Email = FakeData.NetworkData.GetEmail(),
                    AktivasyonKodu = Guid.NewGuid(),
                    KullaniciAdi = $"user{i}",
                    Sifre = "123",
                    KayitTarihi = DateTime.Now.AddDays(-1),
                    DegistirmeTarihi = DateTime.Now,
                    DegistirenKullanici = $"user{i}"
                };

                context.Kullanicilar.Add(k);
            }

            context.SaveChanges();

            List<Kullanici> kullanicilar = context.Kullanicilar.ToList();


            for (int i = 0; i < 5; i++)
            {
                //Kategori ekle

                Kategori kat = new Kategori()
                {
                    Baslik = FakeData.PlaceData.GetStreetName(),
                    Aciklama = FakeData.PlaceData.GetAddress(),
                    KayitTarihi = DateTime.Now,
                    DegistirmeTarihi = DateTime.Now,
                    DegistirenKullanici = admin.KullaniciAdi
                };

                context.Kategoriler.Add(kat);

                for (int j = 0; j < 6; j++)
                {
                    Kullanici kullanici = kullanicilar[FakeData.NumberData.GetNumber(0, 5)];

                    //Makale ekle
                    Makale makale = new Makale()
                    {
                        Baslik = FakeData.TextData.GetAlphabetical(5),
                        Icerik = FakeData.TextData.GetSentences(2),
                        Taslak = false,
                        BegeniSayisi = FakeData.NumberData.GetNumber(2, 6),
                        KayitTarihi = DateTime.Now.AddDays(-2),
                        DegistirmeTarihi = DateTime.Now,
                        DegistirenKullanici = kullanici.KullaniciAdi,
                        Kullanici = kullanici
                    };

                    kat.Makaleler.Add(makale);

                    //Yorum ekle
                    for (int z = 0; z < 3; z++)
                    {
                        Kullanici yorum_kullanici = kullanicilar[FakeData.NumberData.GetNumber(0, 5)];
                        Yorum yorum = new Yorum()
                        {
                            Text = FakeData.TextData.GetSentence(),
                            KayitTarihi = DateTime.Now.AddDays(-1),
                            DegistirmeTarihi = DateTime.Now,
                            DegistirenKullanici = yorum_kullanici.KullaniciAdi,
                            Kullanici = yorum_kullanici
                        };

                        //yorum.Makale = makale;
                        //context.Yorumlar.Add(yorum);

                        makale.Yorumlar.Add(yorum);
                    }


                    //Begeni ekleme
                    for (int x = 0; x < makale.BegeniSayisi; x++)
                    {
                        Kullanici begenen_kullanici = kullanicilar[FakeData.NumberData.GetNumber(0, 5)];

                        Begeni begen = new Begeni()
                        {
                            Kullanici = begenen_kullanici
                        };
                        makale.Begeniler.Add(begen);
                    } //for begeni

                }//for makale

            }//for kategori

            try
            {
                context.SaveChanges();

            }
            catch (DbEntityValidationException e)
            {
                foreach (var item in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        item.Entry.Entity.GetType().Name, item.Entry.State);
                    foreach (var ve in item.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw;
            }
        }
    }

}
    


















