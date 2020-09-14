using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FarhanBooks.Models;

namespace FarhanBooks.Controllers
{
    public class BookModelsController : Controller
    {
        private BookDBContext db = new BookDBContext();

        // GET: BookModels
        public ActionResult Index(string searchString)
        {
            var books = from m in db.Books
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                books = books.Where(s => s.Name.Contains(searchString));
            }

            return View(books);
        }

        // GET: BookModels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookModel bookModel = db.Books.Find(id);
            if (bookModel == null)
            {
                return HttpNotFound();
            }
            return View(bookModel);
        }

        // GET: BookModels/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookModels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,IssueDate,Subject,Price")] BookModel bookModel)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(bookModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bookModel);
        }

        // GET: BookModels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookModel bookModel = db.Books.Find(id);
            if (bookModel == null)
            {
                return HttpNotFound();
            }
            return View(bookModel);
        }

        // POST: BookModels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,IssueDate,Subject,Price")] BookModel bookModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bookModel);
        }

        // GET: BookModels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookModel bookModel = db.Books.Find(id);
            if (bookModel == null)
            {
                return HttpNotFound();
            }
            return View(bookModel);
        }

        // POST: BookModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookModel bookModel = db.Books.Find(id);
            db.Books.Remove(bookModel);
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
