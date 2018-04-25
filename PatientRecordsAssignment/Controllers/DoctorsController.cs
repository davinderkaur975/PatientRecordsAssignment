using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PatientRecordsAssignment.Models;

namespace PatientRecordsAssignment.Controllers
{
    [Authorize]
    public class DoctorsController : Controller
    {
        //db connection moved to EFDoctorsRepository
        private PatientRecordsModel db = new PatientRecordsModel();

       


        // GET: Doctors
        [OverrideAuthorization]
        public ActionResult Index()
        {
            return View(db.Doctors.ToList());
        }

        // GET: Doctors/Details/5
        [OverrideAuthorization]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return View("Error");
            }
            // modify so it can work with ef or the mock repo
            //Doctor doctor = db.Doctors.Find(id);


            // new code to select single order using LINQ
            Doctor doctor = db.Doctors.SingleOrDefault(o => o.DoctorId == id);

            if (doctor == null)
            {
                //return HttpNotFound();
                return View("Error");
            }
            return View(doctor);
        }

        // GET: Doctors/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Doctors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DoctorId,Name,FieldSpecialist,OfficeLocation")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                //db.Doctors.Add(doctor);
                //db.SaveChanges();
                db.Save(doctor);   // use repo's now instead of ef directly
                return RedirectToAction("Index");
            }

            return View("Create", doctor);
        }

        // GET: Doctors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return View("Error");
            }
            //Doctor doctor = db.Doctors.Find(id);

            // new code - works with both mock and ef repositories
            Doctor doctor = db.Doctors.SingleOrDefault(o => o.DoctorId == id);

            if (doctor == null)
            {
                //return HttpNotFound();
                return View("Error");
            }
            return View(doctor);
        }

        // POST: Doctors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DoctorId,Name,FieldSpecialist,OfficeLocation")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(doctor).State = EntityState.Modified;
                //db.SaveChanges();

                // new code - works with mock & ef repo's
                db.Save(doctor);

                return RedirectToAction("Index");
            }
            return View("Edit", doctor);
        }

        // GET: Doctors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                //return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                return View("Error");
            }
            //Doctor doctor = db.Doctors.Find(id);
            Doctor doctor = db.Doctors.SingleOrDefault(o => o.DoctorId == id);

            if (doctor == null)
            {
                //return HttpNotFound();
                return View("Error");
            }
            return View("Delete", doctor);
        }

        // POST: Doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Doctor doctor = db.Doctors.Find(id);
            //db.Doctors.Remove(doctor);
            //db.SaveChanges();
            Doctor doctor = db.Doctors.SingleOrDefault(o => o.DoctorId == id);
            db.Delete(doctor);
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
