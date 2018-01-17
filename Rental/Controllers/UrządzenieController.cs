using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Rental.DAL;
using Rental.Models;

namespace Rental.Controllers
{
    public class UrządzenieController : Controller
    {
        private RentalContext db = new RentalContext();

        // GET: Urządzenie
        public ActionResult Index()
        {
            return View(db.Urządzenia.ToList());
        }

        // GET: Urządzenie/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Urządzenie urządzenie = db.Urządzenia.Find(id);
            if (urządzenie == null)
            {
                return HttpNotFound();
            }
            return View(urządzenie);
        }

        // GET: Urządzenie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Urządzenie/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NazwaUrządzenia,MiesięcznyKosztWypożyczenia")] Urządzenie urządzenie)
        {
            if (ModelState.IsValid)
            {
                db.Urządzenia.Add(urządzenie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(urządzenie);
        }

        // GET: Urządzenie/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Urządzenie urządzenie = db.Urządzenia.Find(id);
            if (urządzenie == null)
            {
                return HttpNotFound();
            }
            return View(urządzenie);
        }

        // POST: Urządzenie/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NazwaUrządzenia,MiesięcznyKosztWypożyczenia")] Urządzenie urządzenie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(urządzenie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(urządzenie);
        }

        // GET: Urządzenie/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Urządzenie urządzenie = db.Urządzenia.Find(id);
            if (urządzenie == null)
            {
                return HttpNotFound();
            }
            return View(urządzenie);
        }

        // POST: Urządzenie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Urządzenie urządzenie = db.Urządzenia.Find(id);
            db.Urządzenia.Remove(urządzenie);
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
