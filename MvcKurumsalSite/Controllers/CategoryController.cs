using MvcKurumsalSite.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MvcKurumsalSite.Controllers
{
    public class CategoryController : Controller
    {
        private DatabaseContext db = new DatabaseContext();
        // GET: Category
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var kategori = db.Categories.Find(id);
            if (kategori == null)
            {
                return HttpNotFound();
            }
            return View(kategori);
        }
    }
}