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
            Models.User user = new Models.User { Email = email};
            user.updateValues();
            return View(user);
        }
        public JsonResult RemoveUser(int id)
        {
            Models.User.removeUser(id);
            return Json("", JsonRequestBehavior.AllowGet);
        }
        public JsonResult EditUser(Models.User user)
        {
            Models.User.removeUser(id);
            return Json("", JsonRequestBehavior.AllowGet);
        }
    }
}