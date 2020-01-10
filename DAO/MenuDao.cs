using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.DAO
{
    public class MenuDao
    {
        OnlineShopContext db = null;
        public MenuDao()
        {
            db = new OnlineShopContext();
        }

        public List<Menu> ListByGroupId(int groupId)
        {
            return db.Menus.Where(x => x.TypeID == groupId && x.Status == true).OrderBy(y => y.DisplayOrder).ToList();
        }
    }
}