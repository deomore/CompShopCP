using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompShop.Models;
using CompShop.DAO.DAOclasses;

namespace CompShop.Controllers
{
    public class ProvidersController : Controller
    {
        ProvidersDAO providersDAO = new ProvidersDAO();
        private CSEntities3 db = new CSEntities3();
        // GET: Providers
        public ActionResult Index()
        {
            return View(db.Providers.ToList());
        }

        // GET: Providers/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Providers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Providers/Create
        [HttpPost]
        public ActionResult Create(Providers providers)
        {
            providersDAO.AddNew(providers);

            return RedirectToAction("Index");
        }

        // GET: Providers/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Providers/Edit/5
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

        // GET: Providers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Providers/Delete/5
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
