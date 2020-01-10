using OnlineShop.Areas.Admin.Models;
using OnlineShop.Common;
using OnlineShop.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace OnlineShop.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var dao = new UserDao();
                var result = dao.Login(model.UserName, Encryptor.MD5Hash(model.PassWord),true);
                if (result == 1)
                {
                    var user = dao.GetbyId(model.UserName);
                    var userSession = new UserLogin();
                    userSession.UserName = user.UserName;
                    userSession.UserID = user.ID;
                    userSession.GroupID = user.GroupID; 
                    var listCredentials = dao.GetListCredential(model.UserName);
                    Session.Add(OnlineShop.Common.CommonContants.SESSION_CREDENTIALS, listCredentials);
                    Session.Add(OnlineShop.Common.CommonContants.USER_SESSION, userSession);
                    return RedirectToAction("Index", "Home");
                }
                else if (result == 0)
                {
                    ModelState.AddModelError("", "Tài khoản không tồn tại!!");
                }
                else if (result == -1)
                {
                    ModelState.AddModelError("", "Tài khoản đang bị khóa!!");
                }
                else if (result == -2)
                {
                    ModelState.AddModelError("", "Mật khẩu không đúng!!");
                }
                else if (result == -3)
                {
                    ModelState.AddModelError("", "Tài khoản của bạn không có quyền đăng nhập!!");
                }
                else
                {
                    ModelState.AddModelError("", "Đăng nhập không đúng!!");
                }
            }
            return View("Index");
        }
    }
}