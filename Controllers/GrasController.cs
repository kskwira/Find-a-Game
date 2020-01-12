using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Find_a_Game.DataContexts;
using Find_a_Game.Models;
using PagedList;

namespace Find_a_Game.Controllers
{
    public class GrasController : Controller
    {
        private GryDb db = new GryDb();

        // GET: Gras
        public ViewResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NazwaSortParm = String.IsNullOrEmpty(sortOrder) ? "nazwa_desc" : "";
            ViewBag.GatunekSortParm = sortOrder == "Gatunek" ? "gatunek_desc" : "Gatunek";
            ViewBag.PlatformaSortParm = sortOrder == "Platforma" ? "platforma_desc" : "Platforma";
            ViewBag.ProducentSortParm = sortOrder == "Producent" ? "producent_desc" : "Producent";
            ViewBag.RokWydaniaSortParm = sortOrder == "Rok" ? "rok_desc" : "Rok";
            ViewBag.OcenaSortParm = sortOrder == "Ocena" ? "ocena_desc" : "Ocena";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var gry = from g in db.Gry
                      select g;

            if (!String.IsNullOrEmpty(searchString))
            {
                gry = gry.Where(g => g.Nazwa.Contains(searchString)
                                       || g.Gatunek.ToString().Contains(searchString)
                                       || g.Platforma.ToString().Contains(searchString)
                                       || g.Producent.Contains(searchString));
            }

            switch (sortOrder)
            {
                case "nazwa_desc":
                    gry = gry.OrderByDescending(g => g.Nazwa);
                    break;
                case "Gatunek":
                    gry = gry.OrderBy(g => g.Gatunek);
                    break;
                case "gatunek_desc":
                    gry = gry.OrderByDescending(g => g.Gatunek);
                    break;
                case "Platforma":
                    gry = gry.OrderBy(g => g.Platforma);
                    break;
                case "platforma_desc":
                    gry = gry.OrderByDescending(g => g.Platforma);
                    break;
                case "Producent":
                    gry = gry.OrderBy(g => g.Producent);
                    break;
                case "producent_desc":
                    gry = gry.OrderByDescending(g => g.Producent);
                    break;
                case "Rok":
                    gry = gry.OrderBy(g => g.RokWydania);
                    break;
                case "rok_desc":
                    gry = gry.OrderByDescending(g => g.RokWydania);
                    break;
                case "Ocena":
                    gry = gry.OrderBy(g => g.Ocena);
                    break;
                case "ocena_desc":
                    gry = gry.OrderByDescending(g => g.Ocena);
                    break;
                default:
                    gry = gry.OrderBy(g => g.Nazwa);
                    break;
            }

            int pageSize = 4;
            int pageNumber = (page ?? 1);

            return View(gry.ToPagedList(pageNumber, pageSize));
        }

        // GET: Gras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gra gra = db.Gry.Find(id);
            if (gra == null)
            {
                return HttpNotFound();
            }
            return View(gra);
        }

        // GET: Gras/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gras/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GraID,Nazwa,Gatunek,Platforma,Producent,RokWydania,Ocena,Opis")] Gra gra)
        {
            if (ModelState.IsValid)
            {
                db.Gry.Add(gra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gra);
        }

        // GET: Gras/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gra gra = db.Gry.Find(id);
            if (gra == null)
            {
                return HttpNotFound();
            }
            return View(gra);
        }

        // POST: Gras/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit([Bind(Include = "GraID,Nazwa,Gatunek,Platforma,Producent,RokWydania,Ocena,Opis")] Gra gra)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gra).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gra);
        }

        // GET: Gras/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gra gra = db.Gry.Find(id);
            if (gra == null)
            {
                return HttpNotFound();
            }
            return View(gra);
        }

        // POST: Gras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Gra gra = db.Gry.Find(id);
            db.Gry.Remove(gra);
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
