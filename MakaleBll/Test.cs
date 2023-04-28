using DataDAL;
using Makale_entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakaleBll
{
    public class Test
    {
        repository<Kullanici> rep_kul = new repository<Kullanici>();
        repository<Makale> rep_makale = new repository<Makale>();
        repository<Yorum> rep_yorum = new repository<Yorum>();
        public Test()
        {
            //DatabaseContext db= new DatabaseContext();
            //db.Kullanicilar.ToList();//  db.Database.CreateIfNotExists(); bu da database i oluşturur yok ise ama tekrar çalıştığında hata verebilir


            rep_kul.Liste();// artık repository den alacağı için bunları kullanıyoruz burada kullanıcıyı aldı

            List<Kullanici> sonuc = rep_kul.Liste();
            List<Kullanici> liste = rep_kul.Liste(x=>x.Admin ==true); // kaç admin var sorgusu bu da  sonuc veya listeyi de buranın üzerinden var mı yok mu diye balmak için yazdık 

        }   

        public void EkleTest()
        {
            rep_kul.Insert(new Kullanici() { Adi="test",Soyad="test",Admin=false,Aktif=false,AktivasyonKodu=Guid.NewGuid(),Email="test",
                KayitTarihi=DateTime.Now,DegistirmeTarihi=DateTime.Now,DegistirenKullanici="ata",KullaniciAdi="test",Sifre="test"});

        }

        public void Updatetest()
        {
             Kullanici k = rep_kul.Find(x=>x.KullaniciAdi=="test");
            if (k!=null)
            {
                k.Adi = "deneme";
                k.Soyad = "deneme";
                rep_kul.Update(k);// burada da test kullanıcıadı var mı var ise bunlarla değiştir şeklinde bir update testi yaptık

            }

        }
        public void delete()
        {
            Kullanici kul = rep_kul.Find(x => x.KullaniciAdi == "test");
            if (kul != null)
            {
              
                rep_kul.Delete(kul);// burada da test kullanıcıadı var mı var ise bunlarla değiştir şeklinde bir update testi yaptık

            }

        }
        public void YorumTest()
        {

           
            Kullanici k = rep_kul.Find(x => x.Id == 1);
            Makale m = rep_makale.Find(x => x.Id == 1);


            Yorum yorun = new Yorum() {Text="deneme yorum",KayitTarihi=DateTime.Now,DegistirmeTarihi=DateTime.Now,DegistirenKullanici="ata",Kullanici = k, Makale=m };

            rep_yorum.Insert(yorun);

        }



    }
}
