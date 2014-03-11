using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Schrader.Eve.Models;
using Schrader.Eve.Models.DbContexts;

namespace Schrader.Eve.Controllers
{
    public class MiningRunController : Controller
    {
        private MiningRunDbContext db = new MiningRunDbContext();

        // GET: /MiningRun/
        public ActionResult Index(long? id)
        {
            if (id.HasValue)
                return View(db.MiningRuns
                    .Include(mr => mr.LineItems)
                    .Include(mr => mr.Capsuleers.Select(p=>p.Pilot))
                    .First(mr => mr.Id == id));

            return View(new MiningRun());
        }

        // GET: /MiningRun/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MiningRun miningRun = db.MiningRuns.Find(id);
            if (miningRun == null)
            {
                return HttpNotFound();
            }
            return View(miningRun);
        }

        // GET: /MiningRun/Create
        public ActionResult Create()
        {
            return View(new MiningRun());
        }

        // POST: /MiningRun/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,System,Site,Status")] MiningRun miningRun)
        {
            if (ModelState.IsValid)
            {
                db.MiningRuns.Add(miningRun);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(miningRun);
        }

        // GET: /MiningRun/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MiningRun miningRun = db.MiningRuns.Find(id);
            if (miningRun == null)
            {
                return HttpNotFound();
            }
            return View(miningRun);
        }

        // POST: /MiningRun/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Date,System,Site,Status")] MiningRun miningRun)
        {
            if (ModelState.IsValid)
            {
                db.Entry(miningRun).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(miningRun);
        }

        // GET: /MiningRun/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MiningRun miningRun = db.MiningRuns.Find(id);
            if (miningRun == null)
            {
                return HttpNotFound();
            }
            return View(miningRun);
        }

        // POST: /MiningRun/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            MiningRun miningRun = db.MiningRuns.Find(id);
            db.MiningRuns.Remove(miningRun);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public PartialViewResult ShowCapsuleerDetailPartial(string characterId)
        {
            var capsuleer = db.Capsuleers.Include(x => x.Pilot).Where(x => x.Pilot.CharacterId == characterId).FirstOrDefault();
            return PartialView("CapsuleerDetailPartial", capsuleer);
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
