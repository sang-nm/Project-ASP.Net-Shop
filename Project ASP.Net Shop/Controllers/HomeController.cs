using Project_ASP.Net_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Xml;

namespace Project_ASP.Net_Shop.Controllers
{

    public class HomeController : Controller
    {

        private Project_ASPNet_ShopContext db = new Project_ASPNet_ShopContext();

        //Home/Mainsite
        public ActionResult Mainsite()
        {
            var model = new ViewModelMainSite();
            model.Prod = db.Products.ToList();
            return View(model);
        }

        //Home/Childsite
        public ActionResult Childsite(string paramChildName, string paramProducer)
        {
            var model = new ViewModelMainSite();

            ViewBag.pChild = paramChildName;
            ViewBag.pProd = paramProducer;

            var list = db.Products.ToList();

            if (!String.IsNullOrEmpty(paramChildName))
            {
                list = list.Where(i => i.Description.ToLower().Contains(paramChildName.ToLower())).ToList();
            }

            if (!String.IsNullOrEmpty(paramProducer))
            {
                list = list.Where(j => j.Producer.ToLower().Contains(paramProducer.ToLower()) || j.ProductName.ToLower().Contains(paramProducer.ToLower())).ToList();
            }

            model.Prod = list;

            return View(model);
        }

        //Home/Laptop
        public ActionResult LaptopDetail(string paramSpec, string paramBanner, string paramName, string paramThumb, string paramPrice, string paramDesc)
        {
            List<LaptopXML> list = new List<LaptopXML>();
            XmlDocument doc = new XmlDocument();
            doc.Load(Server.MapPath(paramSpec));

            foreach (XmlNode node in doc.SelectNodes("/Laptop/Specifications"))
            {
                list.Add(new LaptopXML
                {
                    Processor = node["Processor"].InnerText,
                    Memory = node["Memory"].InnerText,
                    VideoCard = node["VideoCard"].InnerText,
                    Display = node["Display"].InnerText,
                    HardDrive = node["HardDrive"].InnerText,
                    Battery = node["Battery"].InnerText
                });
            }

            var model = new ViewModelMainSite();

            model.Laptop = list;
            ViewBag.Name = paramName;
            ViewBag.Banner = paramBanner;
            ViewBag.Desc = paramDesc;
            ViewBag.Price = paramPrice;
            ViewBag.Thumb = paramThumb;
            return View(model);
        }
        
        //public ActionResult KeyMouDetail()
        //{
        //    List<string> list = new List<string>();
        //    XmlDocument doc = new XmlDocument();
        //    doc.Load(Server.MapPath("~/Data/RAZER OUROBOROS.xml"));

        //    foreach (XmlNode node in doc.SelectNodes("/KeyAndMouse/Specifications/doc"))
        //    {
        //        list.Add(node["doc"].InnerText);
        //    }

        //    var model = new ViewModelMainSite();
        //    model.KaM.ListXML = list; 
        //    return View(model);
        //}
    }
}