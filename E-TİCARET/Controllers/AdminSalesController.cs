﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataAccessLayer.Context;
using PagedList;
using PagedList.Mvc;

namespace E_TİCARET.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminSalesController : Controller
    {
        // GET: AdminSales
        DataContext db = new DataContext();

        public ActionResult Index(int sayfa=1)
        {

            return View(db.Sales.ToList().ToPagedList(sayfa, 5));
        }
    }
}