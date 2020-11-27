using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CompShop.Models;
using CompShop.DAO;

namespace CompShop.DAO.DAOclasses
{
    public class ProvidersDAO
    {
 
        private CSEntities3 db = new CSEntities3();
        public void AddNew(Providers providers)
        {
            db.Providers.Add(providers);
            db.SaveChanges();
        }

     public void Delete (Providers providers)
        {
            providers = db.Providers.FirstOrDefault();
            if (providers != null)
            {
                db.Providers.Remove(providers);
                db.SaveChanges();
            }    
        }
    }
}