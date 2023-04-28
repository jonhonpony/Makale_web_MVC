using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makale_entities
{
    [Table("Kullanici")]
    public class Kullanici : BaseClass
    {
        [StringLength(30)]
        public string Adi { get; set; }
        [StringLength(30)]
        public string Soyad { get; set; }
        [Required, StringLength(30)]
        public string KullaniciAdi { get; set; }


        [Required,StringLength(200)]
        public string Email { get; set; }
        [Required,StringLength (200)]
        public string Sifre { get; set; }
        public bool Aktif { get; set; } //aktif mi değil mi aktivastyon maili için gerekli bir bool sütunu
        [Required]
        public Guid AktivasyonKodu { get; set; }
        public bool Admin { get; set; }//admin true olan yönetici false olan kullanıcı olacak burada da

        public virtual List<Makale> Makaleler { get; set; }
        public virtual List<Begeni> Begeniler { get; set; } // hangi kullanıcı beğendi listesi için
        public virtual List<Yorum> Yorumlar { get; set; }



    }
}
