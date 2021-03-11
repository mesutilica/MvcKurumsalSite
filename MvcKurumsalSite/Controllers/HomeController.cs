using MvcKurumsalSite.DataAccess;
using MvcKurumsalSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKurumsalSite.Controllers
{
    public class HomeController : Controller
    {
        DatabaseContext db = new DatabaseContext();

        public ActionResult Index()
        {
            var anasayfaModel = new HomePageVM
            {
                Slide = db.Slides.ToList(),
                Categories = db.Categories.Where(k => k.IsActive == true && k.IsHomePage == true).ToList()
            };
            return View(anasayfaModel);
        }
        public PartialViewResult _UstMenu()
        {
            return PartialView(db.Categories.Where(k => k.ParentId == 0 && k.IsActive == true).ToList());
        }
    }
}