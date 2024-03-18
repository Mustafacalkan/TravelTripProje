using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProje.Models.Sınıflar;

namespace TravelTripProje.Controllers
{
    public class YorumController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            var yorumlar =c.Yorumlars.ToList();
            return View(yorumlar);
        }
        public ActionResult YorumSil(int id)
        {
            var y = c.Yorumlars.Find(id);
            c.Yorumlars.Remove(y);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YorumGetir(int id)
        {
            var yorum = c.Yorumlars.Find(id);
            return View("YorumGetir",yorum);
        }
        public ActionResult YorumGuncelle(Yorumlar yorumlar)
        {
            var yorum = c.Yorumlars.Find(yorumlar.ID);
            yorum.KullaniciAdi = yorumlar.KullaniciAdi;
            yorum.Mail=yorumlar.Mail;
            yorum.Yorum=yorumlar.Yorum;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}