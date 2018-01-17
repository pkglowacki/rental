using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Rental.DAL;
using Rental.Models;

namespace Rental.Controllers
{
    public class ZamówienieController : Controller
    {
        private RentalContext db = new RentalContext();

        // GET: Zamówienie
        public ActionResult Index(string sortOrder)
        {
            ViewBag.LastNameSortParm = String.IsNullOrEmpty(sortOrder) ? "LastName_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            ViewBag.DateSortParm = sortOrder == "Date2" ? "date_desc2" : "Date2";

            var zamówienia = db.Zamówienia.Include(z => z.Urządzenie);

            switch (sortOrder)
            {
                case "LastName_desc":
                    zamówienia = zamówienia.OrderByDescending(s => s.Nazwisko);
                    break;
                case "Date":
                    zamówienia = zamówienia.OrderBy(s => s.DataZwrotu);
                    break;
                case "date_desc":
                    zamówienia = zamówienia.OrderByDescending(s => s.DataZwrotu);
                    break;
                case "Date2":
                    zamówienia = zamówienia.OrderBy(s => s.DataZłożenia);
                    break;
                case "date_desc2":
                    zamówienia = zamówienia.OrderByDescending(s => s.DataZłożenia);
                    break;
                default:
                    zamówienia = zamówienia.OrderBy(s => s.ZamówienieId);
                    break;
            }
            return View(zamówienia.ToList());
        }

        // GET: Zamówienie/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zamówienie zamówienie = db.Zamówienia.Find(id);
            if (zamówienie == null)
            {
                return HttpNotFound();
            }
            return View(zamówienie);
        }

        // GET: Zamówienie/Create
        public ActionResult Create()
        {           
            ViewBag.UrządzenieId = new SelectList(db.Urządzenia, "Id", "NazwaUrządzenia");
            return View();
        }

        // POST: Zamówienie/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ZamówienieId,Imie,Nazwisko,Ulica,NumerDomu,NumerMieszkania,KosztZamówienia,IlośćMiesięcyWypożyczenia,DataZłożenia,DataZwrotu,UrządzenieId,MiesięcznyKosztWypożyczenia")] Zamówienie zamówienie, Urządzenie urządzenie)
        {
            if (ModelState.IsValid)
            {

                zamówienie.całkowityKoszt(urządzenie);

                zamówienie.dataZwrotu(zamówienie.IlośćMiesięcyWypożyczenia);

                zamówienie.sprawdźDate();
                db.Zamówienia.Add(zamówienie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UrządzenieId = new SelectList(db.Urządzenia, "Id", "NazwaUrządzenia", zamówienie.UrządzenieId);        
            return View(zamówienie);
        }

        // GET: Zamówienie/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zamówienie zamówienie = db.Zamówienia.Find(id);
            if (zamówienie == null)
            {
                return HttpNotFound();
            }
            ViewBag.UrządzenieId = new SelectList(db.Urządzenia, "Id", "NazwaUrządzenia", zamówienie.UrządzenieId);
            return View(zamówienie);
        }

        // POST: Zamówienie/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ZamówienieId,Imie,Nazwisko,Ulica,NumerDomu,NumerMieszkania,KosztZamówienia,IlośćMiesięcyWypożyczenia,DataZłożenia,DataZwrotu,UrządzenieId")] Zamówienie zamówienie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zamówienie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UrządzenieId = new SelectList(db.Urządzenia, "UrządzenieId", "NazwaUrządzenia", zamówienie.UrządzenieId);
            return View(zamówienie);
        }

        // GET: Zamówienie/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zamówienie zamówienie = db.Zamówienia.Find(id);
            if (zamówienie == null)
            {
                return HttpNotFound();
            }
            return View(zamówienie);
        }

        // POST: Zamówienie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Zamówienie zamówienie = db.Zamówienia.Find(id);
            db.Zamówienia.Remove(zamówienie);
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
