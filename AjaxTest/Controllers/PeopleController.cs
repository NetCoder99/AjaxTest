using AjaxTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AjaxTest.Controllers
{
    public class PeopleController : Controller
    {
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Person person)
        {

            if (!ModelState.IsValid)
            { // re-render the view when validation failed.
                return View("Create", person);
            }

            TempData["notice"] = "Person successfully created";
            return RedirectToAction("Index");

        }
    }
}