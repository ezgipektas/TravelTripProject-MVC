﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelTripProject.Models.Class;

namespace TravelTripProject.Controllers
{
    public class AboutController : Controller
    {
        Context c=new Context();
        public ActionResult Index()
        {
            var values = c.Hakkimizdas.ToList();
            return View(values);
        }
    }
}