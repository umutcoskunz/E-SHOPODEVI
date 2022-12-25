using DataAccessLayer.Context;
using EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace E_TİCARET.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        DataContext db=new DataContext();   
        public ActionResult Update() 
        {
            var username = (string)Session["Mail"];
            var değerler = db.Users.FirstOrDefault(x => x.Email == username);
            return View(değerler);           
        }
        [HttpPost]
        public ActionResult Update(User data) 
        {
            var username = (string)Session["Mail"];
            var user = db.Users.Where(x => x.Email == username).FirstOrDefault();
            user.Name= data.Name;
            user.Surname= data.Surname; 
            user.Email= data.Email;
            user.Password= data.Password;
            user.repassword = data.repassword;
            user.Username= data.Username;
            db.SaveChanges();   
            return RedirectToAction("Index","Home");
        }
        public ActionResult PasswordReset()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PasswordReset(string eposta) 
        {
            var mail = db.Users.Where(x => x.Email == eposta).SingleOrDefault();

            if (mail !=null)
             {
                Random rnd=new Random();
                int yenisifre = rnd.Next();
                User sifre = new User();
                mail.Password = (Convert.ToString(yenisifre));
                db.SaveChanges();
                WebMail.SmtpServer = "smtp.gmail.com";
                WebMail.EnableSsl= true;
                WebMail.UserName = "deplasmanavideolar@gmail.com";
                WebMail.Password = "umutumut41.";
                WebMail.SmtpPort = 587;
                WebMail.Send(eposta, "GiriŞ Şifreniz", "Şifreniz" + yenisifre);
                ViewBag.uyari = "Şifreniz başarıyla gönderilmiştir";

            }
            else
            {
                ViewBag.uyari = "Hata oluştu,lütfen tekrar deneyiniz";
            }
            return View();  
        }
    }
} 

