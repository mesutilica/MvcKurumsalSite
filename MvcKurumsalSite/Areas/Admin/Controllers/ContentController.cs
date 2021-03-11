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
    public class ContentController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Admin/Content
        public ActionResult Index()
        {
            var contents = db.Contents.Include(c => c.Category);
            return View(contents.ToList());
        }

        // GET: Admin/Content/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Content content = db.Contents.Find(id);
            if (content == null)
            {
                return HttpNotFound();
            }
            return View(content);
        }

        // GET: Admin/Content/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Content content, HttpPostedFileBase ContentImg)
        {
            if (ModelState.IsValid)
            {
                string directory = Server.MapPath("~/Uploads/ContentImg/");
                if (ContentImg != null && ContentImg.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(ContentImg.FileName);
                    ContentImg.SaveAs(Path.Combine(directory, fileName));
                    content.ContentImg = ContentImg.FileName;
                }
                content.CreateDate = DateTime.Now;
                content.UpdateDate = DateTime.Now;
                db.Contents.Add(content);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", content.CategoryId);
            return View(content);
        }

        // GET: Admin/Content/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Content content = db.Contents.Find(id);
            if (content == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", content.CategoryId);
            TempData["EklenmeTarihi"] = content.CreateDate;
            return View(content);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Content content, HttpPostedFileBase ContentImg, string resmiSil)
        {
            if (ModelState.IsValid)
            {
                string directory = Server.MapPath("~/Uploads/ContentImg/");
                if (ContentImg != null && ContentImg.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(ContentImg.FileName);
                    ContentImg.SaveAs(Path.Combine(directory, fileName));
                    content.ContentImg = ContentImg.FileName;
                }
                if (resmiSil == "on")
                {
                    content.ContentImg = string.Empty;
                }
                content.CreateDate = Convert.ToDateTime(TempData["EklenmeTarihi"]);
                content.UpdateDate = DateTime.Now;
                
                db.Entry(content).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", content.CategoryId);
            return View(content);
        }

        // GET: Admin/Content/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Content content = db.Contents.Find(id);
            if (content == null)
            {
                return HttpNotFound();
            }
            return View(content);
        }

        // POST: Admin/Content/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Content content = db.Contents.Find(id);
            db.Contents.Remove(content);
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
