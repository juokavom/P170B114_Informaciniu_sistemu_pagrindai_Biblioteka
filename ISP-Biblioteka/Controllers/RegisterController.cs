﻿using ISP_Biblioteka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace ISP_Biblioteka.Controllers
{
    public class RegisterController : Controller
    {
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult AddUser(User user)
        {
            user.Validation = 0;
            user.Type = 1;
            string gender = "female";
            if (user.Gender == 1) gender = "male";
            user.Image = string.Format("~/Image/User/{0}.png", gender);
            user.insertToDb();
            BuildEmailTemplate(user);
            return Json("Registracija sėkminga!", JsonRequestBehavior.AllowGet);
        }

        public ActionResult Confirm(string email) 
        {
            ViewBag.email = email;
            return View();
        }

        public void BuildEmailTemplate(User user)
        {
            string body = System.IO.File.ReadAllText(HostingEnvironment.MapPath("~/EmailTemplate/") + "Text" + ".cshtml");
            var url = "https://localhost:44303/" + "Register/Confirm?email=" + user.Email;
            body = body.Replace("ViewBag.ConfirmationLink", url);
            body = body.ToString();
            BuildEmailTemplate("Jūsų paskyra sėkmingai sukurta!", body, user.Email);
        }
        public JsonResult RegisterConfirm(string email)
        {
            Models.User.validate(email, 1);
            var msg = "Jūsų paskyra patvirtinta!";
            return Json(msg, JsonRequestBehavior.AllowGet);
        }
        public static void BuildEmailTemplate(string subjectText, string bodyText, string sendTo)
        {
            string from, to, bcc, cc, subject, body;
            from = "biblioteka389@gmail.com";
            to = sendTo.Trim();
            bcc = "";
            cc = "";
            subject = subjectText;
            StringBuilder sb = new StringBuilder();
            sb.Append(bodyText);
            body = sb.ToString();
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(from);
            mail.To.Add(new MailAddress(to));
            if (!string.IsNullOrEmpty(bcc))
            {
                mail.Bcc.Add(new MailAddress(bcc));
            }
            if (!string.IsNullOrEmpty(cc))
            {
                mail.CC.Add(new MailAddress(cc));
            }
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;
            SendEmail(mail);
        }

        public static void SendEmail(MailMessage mail)
        {
            SmtpClient client = new SmtpClient();
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Credentials = new System.Net.NetworkCredential("biblioteka389@gmail.com", "Visaigeras5");
            try
            {
                client.Send(mail);
            }
            catch(Exception ex){
                throw ex;
            }
        }

        public JsonResult CheckUser(User user)
        {
            string result = "Fail";
            if (!user.chechUser()) {
                result = "Success";
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}