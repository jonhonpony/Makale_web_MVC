﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Makale_entities.ViewModel
{
    public class LoginModel
    {
        [DisplayName("Kullanıcı Adı"),Required(ErrorMessage ="{0} alanı boş geçilemez")]
        public string KullaniciAdi { get; set; }

        [DisplayName("Şifre"), Required(ErrorMessage = "{0} alanı boş geçilemez")]
        public string Sifre { get; set; }





    }
}
