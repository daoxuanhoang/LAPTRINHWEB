using OnlineShop.Common;
using OnlineShop.DAO;
using OnlineShop.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OnlineShop.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        OnlineShopContext db = new OnlineShopContext();
        // GET: Admin/Product
        public ActionResult Index(string searchString, int page=1,int pageSize=10)
        {
            var dao = new ProductDao();
            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SearchString = searchString;
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(product);

        }
        [HttpPost]
        public JsonResult UploadImage()
        {
            var file = Request.Files["fileImg"];
            string Name="";
            if (file != null && file.ContentLength > 0)

            {
                string path = Server.MapPath("~/assets/admin/images/" + file.FileName);
                file.SaveAs(path);
                Name = file.FileName;
                return Json(new { name = Name }, JsonRequestBehavior.AllowGet);
            }
             return Json(new { name = Name },JsonRequestBehavior.AllowGet);
        }
        public ActionResult Delete(int id)
        {
            new ProductDao().Delete(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult ChangeStatus(long id)
        {
            Product product = db.Products.Find(id);
            if (product.Status)
            {
            product.Status = false;
            }
          else
            {
                product.Status = true;

            }
            db.SaveChanges();
            return Json(product, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }
    }
}