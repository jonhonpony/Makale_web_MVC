using DataDAL;
using Makale_entities;
using System;
using Makale_entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Makale_entities.ViewModel;

namespace MakaleBll
{
    public class KullaniciYonet
    {
        repository<Kullanici> rep_kul = new repository<Kullanici>();
        public Kullanici KullaniciBul(RegisterModel nesne)
        {
            return rep_kul.Find(x => x.KullaniciAdi == nesne.KullaniciAdi || x.Email == nesne.Email);
        }



    }
}
