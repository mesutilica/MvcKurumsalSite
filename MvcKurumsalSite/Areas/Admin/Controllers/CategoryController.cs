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
    public class CategoryController : Controller
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: Admin/Category
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        // GET: Admin/Category/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Admin/Category/Create
        public ActionResult Create()
        {
            ViewBag.ParentId = new SelectList(db.Categories, "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category,HttpPostedFileBase CategoryImg)
        {
            if (ModelState.IsValid)
            {
                string directory = Server.MapPath("~/Uploads/CategoryImg/");
                if (CategoryImg != null && CategoryImg.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(CategoryImg.FileName);
                    CategoryImg.SaveAs(Path.Combine(directory, fileName));
                    category.CategoryImg = CategoryImg.FileName;
                }
                if (category.ParentId is null) category.ParentId = 0;
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: Admin/Category/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            ViewBag.ParentId = new SelectList(db.Categories, "Id", "Name", category.ParentId);
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category, HttpPostedFileBase CategoryImg, string resmiSil)
        {
            if (ModelState.IsValid)
            {
                string directory = Server.MapPath("~/Uploads/CategoryImg/");
                if (CategoryImg != null && CategoryImg.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(CategoryImg.FileName);
                    CategoryImg.SaveAs(Path.Combine(directory, fileName));
                    category.CategoryImg = CategoryImg.FileName;
                }
                if (resmiSil == "on")
                {
                    category.CategoryImg = string.Empty;
                }
                if (category.ParentId is null) category.ParentId = 0;
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Admin/Category/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Admin/Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
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
