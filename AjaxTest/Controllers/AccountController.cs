using AjaxTest.Connections;
using AjaxTest.Extensions;
using AjaxTest.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace AjaxTest.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public ActionResult SearchUsers()
        {
            SearchUsersMain model = new SearchUsersMain();
            using (var userManager = new UserManager<AppUser>(new UserStore<AppUser>(new SqlExpContext())))
            {
                List<AppUser> u_list = userManager.Users.ToList();
                List<SearchUsersDetails> s_list = u_list.ConvertAll(new Converter<AppUser, SearchUsersDetails>(SearchUsersDetails.Converter));
                model.SrchUserList.AddRange(s_list);
            }
            return View(model);
        }


        [HttpPost]
        public ActionResult SearchUsers(SearchUsersMain model)
        {
            using (var userManager = new UserManager<AppUser>(new UserStore<AppUser>(new SqlExpContext())))
            {
                List<AppUser> u_list = userManager.Users.ToList();
                List<SearchUsersDetails> s_list = u_list.ConvertAll(new Converter<AppUser, SearchUsersDetails>(SearchUsersDetails.Converter));
                model.SrchUserList.AddRange(s_list);
            }

            var partialView = ViewRenderer.RenderPartialView("SearchUsersResults", model.SrchUserList, this.ControllerContext);

            dynamic jsonResponse = new { param1 = "param1", partialViewStr = partialView };
            HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
            return Json(jsonResponse, JsonRequestBehavior.AllowGet);

            //return View(model);
        }


        [HttpPost]
        public ActionResult SearchUsersPartial(string email, string fname, string lname)
        {
            SearchUsersMain model = new SearchUsersMain();
            using (var userManager = new UserManager<AppUser>(new UserStore<AppUser>(new SqlExpContext())))
            {
                List<AppUser> u_list = userManager.Users.Where(w=>w.FirstName.ToLower().StartsWith(fname.ToLower())).ToList();
                List<SearchUsersDetails> s_list = u_list.ConvertAll(new Converter<AppUser, SearchUsersDetails>(SearchUsersDetails.Converter));
                model.SrchUserList.AddRange(s_list);
            }


           return PartialView("SearchUsersPartial", model);
        }

        [HttpGet]
        public JsonResult GetUsersJson(string email, string fname, string lname)
        {
            List<SearchUsersDetails> model = new List<SearchUsersDetails>();
            using (var userManager = new UserManager<AppUser>(new UserStore<AppUser>(new SqlExpContext())))
            {
                //List<AppUser> u_list = userManager.Users.Where(w => w.FirstName.ToLower().StartsWith(fname.ToLower())).ToList();
                List<AppUser> u_list = userManager.Users.ToList();
                List<SearchUsersDetails> s_list = u_list.ConvertAll(new Converter<AppUser, SearchUsersDetails>(SearchUsersDetails.Converter));
                model.AddRange(s_list);
            }
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Excel()
        {


            List<SearchUsersDetails> model = new List<SearchUsersDetails>();
            using (var userManager = new UserManager<AppUser>(new UserStore<AppUser>(new SqlExpContext())))
            {
                //List<AppUser> u_list = userManager.Users.Where(w => w.FirstName.ToLower().StartsWith(fname.ToLower())).ToList();
                List<AppUser> u_list = userManager.Users.ToList();
                List<SearchUsersDetails> s_list = u_list.ConvertAll(new Converter<AppUser, SearchUsersDetails>(SearchUsersDetails.Converter));
                model.AddRange(s_list);
            }

            var excelStream = ExcelBuilder.GetExcelFromList(model);
            return File(excelStream, "application/vnd.ms-excel", "Employees.xlsx");

            //return Json(model, JsonRequestBehavior.AllowGet);
        }

    }
}