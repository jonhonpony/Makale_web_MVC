using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makale_entities
{
    [Table("Kategori")]
    public class Kategori:BaseClass
    {
        [Required,StringLength(50)]
        public string Baslik { get; set; }

        [StringLength(150)]
        public string Aciklama { get; set; }

        
        public virtual List<Makale> Makaleler { get; set; }

        public Kategori() 
        {
            Makaleler= new List<Makale>(); // listeye bir şey eklemek istediğimizde düz makaleler atamayız örneklemek lazım bu yüzden ctoruna her çağrıldığında örneklenmiş oldu
        }


    }
}
