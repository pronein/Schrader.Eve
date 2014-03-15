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
using Schrader.Eve.Models.Repositories.Interfaces;
using Schrader.Eve.Services.Interfaces;
using Schrader.Eve.Services;

namespace Schrader.Eve.Controllers
{
    // Every navigation or refresh (F5 or CTRL+F5) builds a brand new
    // controller (ei. _missionService is always null at action method entry)
    public class MiningRunController : Controller
    {
        private IMissionService _missionService;

        public MiningRunController()
        {
            _missionService = new MissionService();
        }

        public MiningRunController(IMissionService missionService)
        {
            _missionService = missionService;
        }

        // GET: /MiningRun/
        public ActionResult Index()
        {
            // this is going to be a problem for when missions are still
            // in pending state and don't have a start time yet...
            //IEnumerable<Mission> missions = db.Missions
            //    .Where(x => x.Type == MissionType.MiningRun)
            //    .ToList();
            var missions = _missionService.GetMissions(x => x.Type == MissionType.MiningRun);

            return View(missions);
        }

        // GET: /MiningRun/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Mission miningRun = _missionService.GetMission(id.Value);

            if (miningRun == null)
            {
                return HttpNotFound();
            }

            return View(miningRun);
        }

        // GET: /MiningRun/Create
        public ActionResult Create()
        {
            return View(new Mission());
        }

        // POST: /MiningRun/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Date,System,Site,Status")] Mission miningRun)
        {
            if (ModelState.IsValid)
            {
                //db.Missions.Add(miningRun);
                //db.SaveChanges();
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
            Mission miningRun = null;// db.Missions.Find(id);
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
        public ActionResult Edit([Bind(Include = "Id,Date,System,Site,Status")] Mission miningRun)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(miningRun).State = EntityState.Modified;
                //db.SaveChanges();
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
            Mission miningRun = null;// db.Missions.Find(id);
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
            //Mission miningRun = db.Missions.Find(id);
            //db.Missions.Remove(miningRun);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public PartialViewResult LoadMissionPilotDetailPartial(long pilotId)
        {
            var capsuleer = _missionService.GetPilot(pilotId);

            return PartialView("MissionPilotDetailPartial", capsuleer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_missionService != null) _missionService.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
