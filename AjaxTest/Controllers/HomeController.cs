using AjaxTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AjaxTest.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult AjaxTest1()
        {
            AjaxTestModel model = new AjaxTestModel();
            return View();
        }
        [HttpPost]
        public ActionResult AjaxTest1(AjaxTestModel model)
        {
            string file_name = @"C:\Users\dughome002\source\repos\AjaxTest\AjaxTest\Json\test.json";
            if (System.IO.File.Exists(file_name))
            {
                string json_data = System.IO.File.ReadAllText(file_name);
                var json_rslt = Json(json_data);
            }
            if (model.OptIn)
            {
                dynamic errorMessage = new { param1 = "param1", param2 = "You opted in." };
                HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
                return Json(errorMessage, JsonRequestBehavior.AllowGet);
            }
            else
            {
                dynamic errorMessage = new { param1 = "param1", param2 = "You opted out." };
                HttpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                return Json(errorMessage, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult AjaxTest2()
        {
            AjaxTestModel model = new AjaxTestModel();
            return View(model);
        }

        public ActionResult AjaxTest2(AjaxTestModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            return View(model);
        }

    }
}