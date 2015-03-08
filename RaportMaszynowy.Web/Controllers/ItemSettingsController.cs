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
    public class ItemSettingsController : Controller
    {

        private Model1 db = new Model1();

        public ActionResult Index()
        {
            return View(db.Settings.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
             Settings setting = db.Settings.Find(id);
            if (setting == null)
            {
                return HttpNotFound();
            }
            return View(setting);
        }

        /// <summary>
        /// Ustawia flage IsActive settingsa na true 
        /// W Systemie moze byc tylko jeden aktywny settings
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult SetActive(int id)
        {
            using (var context = new Model1())
            {
                using (var dbContextTransaction = context.Database.BeginTransaction())
                {
                    var dbActiveItems = context.Settings.Where(x => x.isActive);
                    dbActiveItems.ForEach(x => x.isActive = false);

                    var dbItem = context.Settings.SingleOrDefault(x => x.SettingsID == id);
                    if (dbItem != null)
                    {
                        dbItem.isActive = true;
                    }
                    context.SaveChanges();
                }
            }

            return RedirectToAction("Details", id);

        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Settings setting)
        {
            if (ModelState.IsValid)
            {
                db.Settings.Add(setting);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(setting);
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Settings setting = db.Settings.Find(id);
            if (setting == null)
            {
                return HttpNotFound();
            }
            return View(setting);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Settings setting)
        {
            if (ModelState.IsValid)
            {
                db.Entry(setting).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(setting);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Settings setting = db.Settings.Find(id);
            if (setting == null)
            {
                return HttpNotFound();
            }
            return View(setting);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Settings setting = db.Settings.Find(id);
            db.Settings.Remove(setting);
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
