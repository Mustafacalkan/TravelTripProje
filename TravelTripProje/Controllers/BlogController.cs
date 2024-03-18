using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Sınıflar;
namespace TravelTripProje.Controllers
{
    public class BlogController : Controller
    {
        Context c = new Context();
        BlogYorum by = new BlogYorum();
        public ActionResult Index()
        {
            //var degerler=c.Blogs.ToList();
            by.Deger1 = c.Blogs.ToList();
            by.Deger3 = c.Blogs.Take(3).ToList();
            return View(by);
        }

        public ActionResult BlogDetay(int ID)
        {

            //var blogbul=c.Blogs.Where(x=>x.ID==ID).ToList();
            by.Deger1 = c.Blogs.Where(x => x.ID == ID).ToList();
            by.Deger2 = c.Yorumlars.Where(x => x.BlogID == ID).ToList();
            return View(by);
        }
        [HttpGet]
        public PartialViewResult YorumYap(int id)
        {
            ViewBag.deger = id;
            return PartialView();
        }

        [HttpPost]
        public PartialViewResult YorumYap(Yorumlar yorumlar)
        {
            c.Yorumlars.Add(yorumlar);
            c.SaveChanges();
            return PartialView();
        }
    }
}