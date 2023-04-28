using Makale_entities;
using Makale_entities.ViewModel;
using MakaleBll;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;

namespace Makale_web_MVC.Controllers
{
    public class HomeController : Controller
    {
        MakaleYonet my = new MakaleYonet();
        KategoriYonet ky = new KategoriYonet(); 
        // GET: Home
        public ActionResult Index()
        {
            Test test = new Test(); // burada sadece class çağrıldı ctor da zaten database oluşturulduğunda çağırdığımızda oluşacaktır
            //test.EkleTest();
            //test.Updatetest();
            test.YorumTest();
            MakaleYonet makaleYonet = new MakaleYonet();
            
            return View(makaleYonet.Listele());
        }

        public ActionResult Kategori(int? id)
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Kategori kat = ky.Kategoribul(id.Value);

            return View("Index",kat.Makaleler);
        }
        public ActionResult EnBegenilenler()
        {


            return View("Index",my.Listele().OrderByDescending(x=>x.BegeniSayisi).ToList());
        }
        public ActionResult SonYazilanlar()
        {


            return View("Index", my.Listele().OrderByDescending(x => x.DegistirmeTarihi).ToList());
        }

        public ActionResult Hakkimizda()
        {


            return View();
        }
        public ActionResult Giris()
        {



            return View();
        }
        [HttpPost]
        public ActionResult Giris(LoginModel model)
        {



            return View();
        }
        public ActionResult Kayitol()
        {



            return View();
        }
        [HttpPost]
        public ActionResult Kayitol(RegisterModel model)// kullanıcı adı ve email kontrolü sonra kayıt işlemi yapılacak ve aktivasyon kodu gönderilecek
        {
            KullaniciYonet ky =new KullaniciYonet();

            if (ModelState.IsValid)// model geçerli mi sorusu geçerli mail girldi mi falan
            {
               Kullanici kul=ky.KullaniciBul(model);
                if (kul!=null)
                {
                    ModelState.AddModelError("", "Bu kullanıcı yada email zaten kayıtlı");
                    return View(model);// bu modeli geri yolladığımız zaman girdiğim bilgiler girili şekilde gelir

                }
                else
                {
                    return RedirectToAction("Giris");
                }
            }


            return View();
        }






    }
}