using BusinnessLayer.Concrete;
using DataAccessLayer.Context;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList.Mvc;
using PagedList;
 

namespace E_Shop.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminProductController : Controller
    {
        // GET: AdminProduct
        ProductRepository ProductRepository= new ProductRepository(); 
        DataContext db=new DataContext();
        public ActionResult Index(int sayfa=1)
        {
            return View(ProductRepository.List().ToPagedList(sayfa,3)); 
        }

        public ActionResult Create() 
        { 
          List<SelectListItem> deger1=(from i in db.Categories.ToList()
              select new SelectListItem
            {
             Text=i.Name,
             Value=i.Id.ToString()

            } ) .ToList();
            ViewBag.ktgr = deger1;
            return View();
        }
        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Create(Product data, HttpPostedFileBase File)

        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Hata oluştu");
            }   
            string path=Path.Combine("~/Content/Image/" + File.FileName);
            File.SaveAs(Server.MapPath(path));
            data.Image = File.FileName.ToString();
            ProductRepository.Insert(data);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var delete= ProductRepository.GetById(id);
            ProductRepository.Delete(delete);   
            return RedirectToAction("Index");
        }

        public ActionResult Update(int id) 
        {
            List<SelectListItem> deger1 = (from i in db.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = i.Name,
                                               Value = i.Id.ToString()

                                           }).ToList();
            ViewBag.ktgr = deger1;
            var update = ProductRepository.GetById(id);
           return View(update); 
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
       
        public ActionResult Update(Product Data,HttpPostedFileBase File) 
        {
            var update = ProductRepository.GetById(Data.Id); 
            if (!ModelState.IsValid)
            {
                if (File == null)
                {

                    update.Description = Data.Description;
                    update.Name = Data.Name;
                    update.IsApproved = Data.IsApproved;
                    update.Popular = Data.Popular;
                    update.Price = Data.Price;
                    update.Stock = Data.Stock;
                    update.CategoryId = Data.CategoryId;
                    ProductRepository.Update(Data);
                    return RedirectToAction("Index");
                }
                else
                {

                    update.Description = Data.Description;
                    update.Name = Data.Name;
                    update.IsApproved = Data.IsApproved;
                    update.Popular = Data.Popular;
                    update.Price = Data.Price;
                    update.Stock = Data.Stock;
                    update.Image = File.FileName.ToString();
                    update.CategoryId = Data.CategoryId;
                    ProductRepository.Update(update );
                    return RedirectToAction("Index");
                }
            }
           
            return View(update);  
                
           
           
           
        }
        public ActionResult CriticalStock() 
        {
            var kritik = db.Products.Where(x => x.Stock <= 50).ToList();
            return View(kritik);
        }

        public PartialViewResult StockCount()
        {
            if (User.Identity.IsAuthenticated)
            {
                var count = db.Products.Where(x => x.Stock < 50).Count();
                ViewBag.count = count;
                var azalan = db.Products.Where(x => x.Stock == 50).Count();
                ViewBag.azalan = azalan;
            }
            return PartialView();

        }


    }
}