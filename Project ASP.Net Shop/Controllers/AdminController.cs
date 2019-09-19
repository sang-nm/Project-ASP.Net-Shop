using Project_ASP.Net_Shop.Models;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Project_ASP.Net_Shop.Controllers
{
    public class AdminController : Controller
    {
        private Project_ASPNet_ShopContext db = new Project_ASPNet_ShopContext();

        // GET: Admin
        public ActionResult Index(string SearchString)
        {
           IQueryable<Products> lstProducts = from p in db.Products select p;
                if (!string.IsNullOrEmpty(SearchString))
                {
                    lstProducts = lstProducts.Where(x => x.ProductName.Contains(SearchString) || x.Producer.Contains(SearchString) || x.Description.Contains(SearchString));
                }
            return View(lstProducts);
        }

        // GET: Admin/Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ProductName,Description,Producer,Price,Specifications," +
            "ProductBanner,ProductThumbnail")] Products products, List<HttpPostedFileBase> file)
        {
            foreach (var item in file)
            {
                if (item == null)
                {
                    ModelState.AddModelError("Error", "Add three files");
                    ViewBag.MessageUploadFile = "Add three files";
                    return View();
                }
            }

            try
            {
                if (file[0].ContentType.Contains("text/xml"))
                {
                    string pathSpec = Path.Combine(Server.MapPath("~/Data/" + file[0].FileName));
                    file[0].SaveAs(pathSpec);
                    products.Specifications = "~/Data/" + file[0].FileName;
                }
                else
                {
                    ModelState.AddModelError("Error", "File Extensions");
                    ViewBag.MessageUploadFile = "File upload failed!!";
                }
                if (file[1].ContentType.Contains("image"))
                {
                    string pathBanner = Path.Combine(Server.MapPath("~/Images/" + file[1].FileName));
                    file[1].SaveAs(pathBanner);
                    products.ProductBanner = "~/Images/" + file[1].FileName;
                }
                else
                {
                    ModelState.AddModelError("Error", "File Extensions");
                    ViewBag.MessageUploadFile = "File upload failed!!";
                }
                if (file[2].ContentType.Contains("image"))
                {
                    string pathThumb = Path.Combine(Server.MapPath("~/Images/" + file[2].FileName));
                    file[2].SaveAs(pathThumb);
                    products.ProductThumbnail = "~/Images/" + file[2].FileName;
                }
                else
                {
                    ModelState.AddModelError("Error", "File Extensions");
                    ViewBag.MessageUploadFile = "File upload failed!!";
                }
            }
            catch
            {
                ViewBag.MessageUploadFile = "File upload failed!!";
                return View();
            }
            if (ModelState.IsValid)
            {
                db.Products.Add(products);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(products);
        }

        // GET: Admin/Edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            
            return View(products);
        }

        // POST: Admin/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ProductName,Description,Producer,Price,Specifications," +
            "ProductBanner,ProductThumbnail")] Products products, List<HttpPostedFileBase> file)
        {
            foreach (var item in file)
            {
                if (item == null)
                {
                    ModelState.AddModelError("Error", "Add three files");
                    return View();
                }
            }

            try
            {
                if (file[0].ContentType.Contains("text/xml"))
                {
                    string pathSpec = Path.Combine(Server.MapPath("~/Data/" + file[0].FileName));
                    file[0].SaveAs(pathSpec);
                    products.Specifications = "~/Data/" + file[0].FileName;
                }
                else
                {
                    ModelState.AddModelError("Error", "File Extensions");
                }
                if (file[1].ContentType.Contains("image"))
                {
                    string pathBanner = Path.Combine(Server.MapPath("~/Images/" + file[1].FileName));
                    file[1].SaveAs(pathBanner);
                    products.ProductBanner = "~/Images/" + file[1].FileName;
                }
                else
                {
                    ModelState.AddModelError("Error", "File Extensions");
                }
                if (file[2].ContentType.Contains("image"))
                {
                    string pathThumb = Path.Combine(Server.MapPath("~/Images/" + file[2].FileName));
                    file[2].SaveAs(pathThumb);
                    products.ProductThumbnail = "~/Images/" + file[2].FileName;
                }
                else
                {
                    ModelState.AddModelError("Error", "File Extensions");
                }

                ViewBag.MessageUploadFile = "File Uploaded Successfully!!";
            }
            catch
            {
                ViewBag.MessageUploadFile = "File upload failed!!";
            }
            if (ModelState.IsValid)
            {
                db.Entry(products).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(products);
        }

        // GET: Admin/Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Products products = db.Products.Find(id);
            if (products == null)
            {
                return HttpNotFound();
            }
            return View(products);
        }

        // POST: Admin/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Products products = db.Products.Find(id);
            db.Products.Remove(products);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
