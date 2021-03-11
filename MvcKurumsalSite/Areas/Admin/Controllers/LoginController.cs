using MvcKurumsalSite.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKurumsalSite.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        private DatabaseContext db = new DatabaseContext();
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string username, string password)
        {
            try
            {
                var kullanici = db.Users.FirstOrDefault(x => x.UserName == username && x.Password == password && x.IsActive == true);
                if (kullanici != null)
                {
                    Session["AdminUser"] = kullanici;//Eğer kullanıcı ve şifre ile uyuşan bir kayıt varsa bu kullanıcıyı AdminUser ismini verdiğimiz Session a yükle
                    return Redirect("~/Admin");
                }
                else
                {
                    ViewBag.Mesaj = "Giriş Başarısız! Lütfen Tekrar Deneyin!";
                    return View();
                }
            }
            catch
            {
                ViewBag.Mesaj = "Hata Oluştu!";
                return View();
            }
        }
        
    }
}
