using MvcKurumsalSite.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcKurumsalSite.Controllers
{
    public class ContentsController : Controller
    {
        private DatabaseContext db = new DatabaseContext();
        // GET: Contents
        public ActionResult Index()
        {
            return View(db.Contents.ToList());
        }
    }
}