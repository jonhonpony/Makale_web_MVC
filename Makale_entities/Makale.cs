using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makale_entities
{
    [Table("Makale")]
    public class Makale:BaseClass
    {
        [Required,StringLength(100)]
        public string Baslik { get; set; }
        [Required, StringLength(1000)]
        public string Icerik { get; set; }
        public bool Taslak { get; set; }
        public int BegeniSayisi { get; set; }

        public virtual List<Begeni>Begeniler { get; set; }
        public virtual List<Yorum> Yorumlar { get; set; }
        public virtual Kullanici Kullanici { get; set; } // makalenin birden fazla kullanıcısı olabilir kullanıcının da birden fazla makalesi olabilir bunların ilişkisini kurmayı unutmamak lazım
        public virtual Kategori Kategori { get; set; }

        public Makale()
        {
            Yorumlar = new List<Yorum>();  
            Begeniler = new List<Begeni>();
        }

    }
}
