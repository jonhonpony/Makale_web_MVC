using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makale_entities
{
    [Table("Yorum")]
    public class Yorum:BaseClass
    {
        [Required, StringLength(300)]
        public string Text { get; set; }
        
        public virtual Makale Makale { get; set; } //bir den fazla makale olabilir bu yüzden virtual yaptık ve list olarak yorum classına ekledik ilişkisini kurduk

        public virtual Kullanici Kullanici { get; set; }
    }
}
