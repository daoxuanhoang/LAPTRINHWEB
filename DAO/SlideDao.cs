using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.DAO
{
    public class SlideDao
    {
        OnlineShopContext db = null;
        public SlideDao()
        {
            db = new OnlineShopContext();
        }

        public List<Slide> ListAll()
        {
           
            return db.Slides.Where(x => x.Status == true).OrderBy(y => y.DisplayOrder).ToList();
        }
    }
}