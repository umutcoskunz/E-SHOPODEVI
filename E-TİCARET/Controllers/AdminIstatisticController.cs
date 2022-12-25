using DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace E_TİCARET.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminIstatisticController : Controller
    {
        

        // GET: AdminIstatistic

        DataContext db=new DataContext();
        public ActionResult Index()
        {
            var satis=db.Sales.Count(); 
            ViewBag.satis = satis;

            var urun = db.Products.Count();
            ViewBag.satis = urun;

            var kategori = db.Categories.Count();
            ViewBag.satis = kategori;

            var sepet = db.Carts.Count();
            ViewBag.satis = sepet;

            var kullanici = db.Users.Count();
            ViewBag.satis = kullanici;

            return View();
        }
    }
}