using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CompShop.Models;
using CompShop.DAO.DAOclasses;


namespace CompShop.Controllers
{
    public class HomeController : Controller
    {

        GoodsDAO goodsDAO = new GoodsDAO();
        ProvidersDAO providersDAO = new ProvidersDAO();

        // GET: Home
        public ActionResult Index()
        {
            return View(goodsDAO.GetAllGoods());
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View(goodsDAO.ShowGoods(id));
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Home/Create
        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Create( Goods
       goods)
        {
                goodsDAO.AddNew(goods);
                  
                    return RedirectToAction("Index"); 
        }

       


        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(Goods goods)
        {
            try
            { 
            if (goodsDAO.EditGoods(goods))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Edit");
            }
            }
            catch
            {
                return View("Edit");
            }
        }



        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            return View(goodsDAO.ShowGoods(id));
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Goods goods)
        {
            try
            {
                // TODO: Add delete logic here
                if (goodsDAO.DeleteGoods(id))
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Delete");
                }
            }
            catch
            {
                return View("Delete");
            }
        }
    }
}
