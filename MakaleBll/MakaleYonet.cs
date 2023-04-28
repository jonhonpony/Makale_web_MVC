using DataDAL;
using Makale_entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MakaleBll
{
    public class MakaleYonet
    {
        repository<Makale> rep_mak = new repository<Makale>();
        public List<Makale> Listele()
        {
            return rep_mak.Liste();
        }
    }
}

