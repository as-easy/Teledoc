using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Teledoc.Models;

namespace Teledoc.Controllers
{
    public class FoundersController : Controller
    {
        private ClientContext db = new ClientContext();

        // GET: Founders
        public ActionResult Index()
        {
            var founders = db.Founders.Include(f => f.Client);
            return View(founders.ToList());
        }

        // GET: Founders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Founder founder = db.Founders.Include(t=>t.Client).FirstOrDefault(t => t.Id == id);
            if (founder == null)
            {
                return HttpNotFound();
            }
            return View(founder);
        }

        // GET: Founders/Create
        public ActionResult Create()
        {
            ViewBag.ClientId = new SelectList(db.Clients, "Id", "Name");
            return View();
        }

        // POST: Founders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Inn,Fio,Date_Add,Date_Upd,ClientId")] Founder founder)
        {
            if (ModelState.IsValid)
            {
                founder.Date_Add = DateTime.Now;
                founder.Date_Upd = DateTime.Now;
                db.Founders.Add(founder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientId = new SelectList(db.Clients, "Id", "Name", founder.ClientId);
            return View(founder);
        }

        // GET: Founders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Founder founder = db.Founders.Find(id);
            if (founder == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientId = new SelectList(db.Clients, "Id", "Name", founder.ClientId);
            return View(founder);
        }

        // POST: Founders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Inn,Fio,Date_Add,Date_Upd,ClientId")] Founder founder)
        {
            if (ModelState.IsValid)
            {
                founder.Date_Upd = DateTime.Now;
                db.Entry(founder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientId = new SelectList(db.Clients, "Id", "Name", founder.ClientId);
            return View(founder);
        }

        // GET: Founders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Founder founder = db.Founders.Include(t => t.Client).FirstOrDefault(t => t.Id == id);
            if (founder == null)
            {
                return HttpNotFound();
            }
            return View(founder);
        }

        // POST: Founders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Founder founder = db.Founders.Find(id);
            db.Founders.Remove(founder);
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
