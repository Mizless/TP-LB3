﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;


namespace TP_LB3.Controllers
{
    public class LB3Controller : IController
    {

        public void Execute(RequestContext requestContext)
        {
            string action = (string)requestContext.RouteData.Values["action"];
            int id;
            if (!int.TryParse((string)requestContext.RouteData.Values["id"], out id))
            {
                id = 1;
            }

            if (action == "start" && id == 0)
            {
                requestContext.HttpContext.Response.Redirect("/Home/Index");
            }
            else
            {
                requestContext.HttpContext.Response.Write("Ошибка! <br>");
                requestContext.HttpContext.Response.Write("URL: " + requestContext.HttpContext.Request.Url.ToString());
            }
            
        }
    }


    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(string name, string Age, int? id_Person, string info, bool Choose)
        {
            if (id_Person != null)
            {
                int age = int.Parse(Age);
                

                ViewBag.Name = name;
                ViewBag.Age = age;
                ViewBag.VAG = Request.Form["VAG"];
                ViewBag.Id = id_Person.Value;
                ViewBag.Info = info;
                ViewBag.Choose = Choose;

                return View("Result");
                

            }
            else
            {
                return RedirectToRoute(new { controller = "Home", action = "Index" });
            }
        }
        public ActionResult Result()
        {
            return View();
        }
    }
}
