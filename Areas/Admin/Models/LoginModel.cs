using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Mời nhập user name")]
        public string UserName { set; get; }
        [Required(ErrorMessage = "Mời nhập password")]
        public string PassWord { set; get; }

        public bool RememberMe { set; get; }
    }
}