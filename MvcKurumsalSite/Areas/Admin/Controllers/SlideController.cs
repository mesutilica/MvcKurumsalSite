using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Entities;
using MvcKurumsalSite.DataAccess;

namespace MvcKurumsalSite.Areas.Admin.Controllers
{
    public class SlideController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Admin/Slide
        public ActionResult Index()
        {
            return View(db.Slides.ToList());
        }

        // GET: Admin/Slide/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slide slide = db.Slides.Find(id);
            if (slide == null)
            {
                return HttpNotFound();
            }
            return View(slide);
        }

        // GET: Admin/Slide/Create
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Slide slide, HttpPostedFileBase slideImg)
        {
            if (ModelState.IsValid)
            {
                string directory = Server.MapPath("~/Uploads/SlideImg/");
                if (slideImg != null && slideImg.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(slideImg.FileName);
                    slideImg.SaveAs(Path.Combine(directory, fileName));
                    slide.SlideImg = slideImg.FileName;
                }
                db.Slides.Add(slide);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(slide);
        }

        // GET: Admin/Slide/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slide slide = db.Slides.Find(id);
            if (slide == null)
            {
                return HttpNotFound();
            }
            return View(slide);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Slide slide, HttpPostedFileBase slideImg)
        {
            if (ModelState.IsValid)
            {
                string directory = Server.MapPath("~/Uploads/SlideImg/");
                if (slideImg != null && slideImg.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(slideImg.FileName);
                    slideImg.SaveAs(Path.Combine(directory, fileName));
                    slide.SlideImg = slideImg.FileName;
                }
                db.Entry(slide).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(slide);
        }

        // GET: Admin/Slide/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Slide slide = db.Slides.Find(id);
            if (slide == null)
            {
                return HttpNotFound();
            }
            return View(slide);
        }

        // POST: Admin/Slide/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Slide slide = db.Slides.Find(id);
            db.Slides.Remove(slide);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
