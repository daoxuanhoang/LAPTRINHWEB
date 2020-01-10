using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.DAO
{
    public class ContentDao
    {
        OnlineShopContext db = null;
        public ContentDao()
        {
            db = new OnlineShopContext();

        }
        public Content GetByID(long id)
        {
            return db.Contents.Find(id);
        }
    }
}