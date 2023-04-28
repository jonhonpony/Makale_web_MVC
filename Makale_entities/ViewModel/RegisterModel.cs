using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makale_entities.ViewModel
{
    public class RegisterModel
    {
      
        [Required(ErrorMessage = "{0} alanı boş geçilemez"), StringLength(30)]
        public string KullaniciAdi { get; set; }


        [Required(ErrorMessage = "{0} alanı boş geçilemez"), DisplayName("Email"), StringLength(200),EmailAddress(ErrorMessage = "{0} için geçerli bir email giriniz")]
        public string Email { get; set; }

        public string Sifre { get; set; }

        [Required(ErrorMessage = "{0} alanı boş geçilemez"), DisplayName("Şifre"), StringLength(200),Compare(nameof(Sifre), ErrorMessage = "{0} ile 2.{1} eşleşmiyor")]
        public string SifreTekrar { get; set; }



    }
}
