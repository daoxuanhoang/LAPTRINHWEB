using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.DAO
{
    public class ContactDao
    {
        OnlineShopContext db = null;
        public ContactDao()
        {
            db = new OnlineShopContext();

        }
        public Contact GetActiveContact()
        {
            return db.Contacts.Single(X => X.Status == true);
        }

        public int InsertFeedBack(FeedBack fb)
        {
            db.FeedBacks.Add(fb);
            db.SaveChanges();
            return fb.ID;
        }
    }
}