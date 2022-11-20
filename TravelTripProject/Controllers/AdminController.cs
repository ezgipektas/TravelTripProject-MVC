using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProject.Models.Class;

namespace TravelTripProject.Controllers
{
    public class AdminController : Controller
    {
        Context c=new Context();
        [Authorize]
        public ActionResult Index()
        {
            var values = c.Blogs.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult YeniBlog()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniBlog(Blog p)
        {
            c.Blogs.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult SIL(int id)
        {
            var b=c.Blogs.Find(id);
            c.Blogs.Remove(b);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult BlogGetir(int id)
        {
            var bl = c.Blogs.Find(id);
            return View("BlogGetir",bl);
        }
        public ActionResult GUNCELLE(Blog b)
        {
            var blg = c.Blogs.Find(b.ID);
            blg.Aciklama = b.Aciklama;
            blg.Tarih = b.Tarih;
            blg.BlogImage = b.BlogImage;
            blg.Baslik = b.Baslik;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult YorumListesi()
        {
            var yorumlar=c.Yorumlars.ToList();
            return View(yorumlar);
        }
        public ActionResult YORUMSIL(int id)
        {
            var b = c.Yorumlars.Find(id);
            c.Yorumlars.Remove(b);
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
        public ActionResult YorumGetir(int id)
        {
            var yr = c.Yorumlars.Find(id);
            return View("YorumGetir", yr);
        }
        public ActionResult YORUMGUNCELLE(Yorumlar b)
        {
            var y = c.Yorumlars.Find(b.ID);
            y.KullaniciAdi = b.KullaniciAdi;
            y.Mail = b.Mail;
            y.Yorum = b.Yorum;
            c.SaveChanges();
            return RedirectToAction("YorumListesi");
        }
        public ActionResult IletisimGetir()
        {
            var i = c.AdresBlogs.ToList();
            return View(i);
        }
        public ActionResult ILETISIMSIL(int id)
        {
            var l = c.AdresBlogs.Find(id);
            c.AdresBlogs.Remove(l);
            c.SaveChanges();
            return RedirectToAction("IletisimGetir");
        }

    }
}