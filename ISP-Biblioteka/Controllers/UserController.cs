﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ISP_Biblioteka.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Edit(string email)
        {
            Models.User user = new Models.User { Email = email };
            user.updateValues();
            return View(user);
        }
        public ActionResult Password(string email)
        {
            Models.User user = new Models.User { Email = email };
            user.updateValues();
            return View(user);
        }
        public ActionResult Create()
        {
            return View();
        }
        public JsonResult RemoveUser(int id)
        {
            Models.User.removeUser(id);
            return Json("", JsonRequestBehavior.AllowGet);
        }
        public JsonResult EditUser(Models.User user)
        {
            user.updateToDb();
            return Json(JsonRequestBehavior.AllowGet);
        }
        public JsonResult CreateUser(Models.User user)
        {
            string gender = "female";
            if (user.Gender == 1) gender = "male";
            user.Image = string.Format("~/Image/User/{0}.png", gender);
            user.insertToDb();
            return Json(JsonRequestBehavior.AllowGet);
        }
        public JsonResult ChangePassword(string password, string email)
        {
            Models.User.changePassword(email, password);
            return Json(JsonRequestBehavior.AllowGet);
        }
    }
}