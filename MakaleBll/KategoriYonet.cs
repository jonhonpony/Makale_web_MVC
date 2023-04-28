using DataDAL;
using Makale_entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakaleBll
{
    public class KategoriYonet
    {
        repository<Kategori> rep_kat = new repository<Kategori>();
        public List<Kategori> Listele()
        {
            return rep_kat.Liste();
        }

        public Kategori Kategoribul(int id)
        {
            return rep_kat.Find(x=>x.Id == id);// kategorinin tüm kaydını buluyor burada
        }
    }
}
