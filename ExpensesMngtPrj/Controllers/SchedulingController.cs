using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using SchedulingApp.Models;
using System.Collections.Generic;

namespace SchedulingApp.Controllers
{
    public class SchedulingController : Controller
    {
        private SchedulingAppContext db = new SchedulingAppContext();

        // GET: Appointment
        public ActionResult Index()
        {
            return View(db.Appointment.ToList());
        }
     
        // GET: Appointment/Create
        public ActionResult Create()
        {
            IEnumerable<SelectListItem> items = db.Worker.Select(c => new SelectListItem
            {
                Value = c.ID.ToString(),
                Text = c.LastName

            });
            ViewBag.EmployeeList = items;
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,customer,worker,Date,Time,Description")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                db.Appointment.Add(appointment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
       
            return View(appointment);
        }
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment appointment = db.Appointment.Find(id);
            if (appointment == null)
            {
                return HttpNotFound();
            }
            return View(appointment);
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,customer,worker,Date,Time,Description")] Appointment appointment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(appointment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(appointment);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Appointment expense = db.Appointment.Find(id);
            if (expense == null)
            {
                return HttpNotFound();
            }
            return View(expense);
        }
               
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Appointment expense = db.Appointment.Find(id);
            db.Appointment.Remove(expense);
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