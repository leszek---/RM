using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RaportManager.Domian;
using WebGrease.Css.Extensions;
using System.Net;
using System.Data.Entity;

namespace RaportMaszynowy.Web.Controllers
{
    public class MachineErrorsController : Controller
    {
        private Model1 db = new Model1();

        public ActionResult Index()
        {
            return View(db.MachineError.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MachineError error = db.MachineError.Find(id);
            if (error == null)
            {
                return HttpNotFound();
            }
            return View(error);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MachineError error = db.MachineError.Find(id);
            if (error == null)
            {
                return HttpNotFound();
            }
            return View(error);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MachineError error)
        {
            if (ModelState.IsValid)
            {
                db.Entry(error).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(error);
        }

        // GET: Item/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Item/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
