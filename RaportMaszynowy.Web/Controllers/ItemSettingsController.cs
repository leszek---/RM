using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RaportManager.Domian;
using WebGrease.Css.Extensions;

namespace RaportMaszynowy.Web.Controllers
{
    public class ItemSettignsController : Controller
    {

     

        // GET: Item
        public ActionResult Index()
        {
            return View();
        }

        // GET: Item/Details/5
        public ActionResult Details(int id)
        {
            return View();
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

                    var dbItem = context.Settings.SingleOrDefault(x => x.ItemID == id);
                    if (dbItem != null)
                    {
                        dbItem.isActive = true;
                    }
                    context.SaveChanges();
                }
            }

            return RedirectToAction("Details", id);

        }

        // GET: Item/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Item/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Item/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Item/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
