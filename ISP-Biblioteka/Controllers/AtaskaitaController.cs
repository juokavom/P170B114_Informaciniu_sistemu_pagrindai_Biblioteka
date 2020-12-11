﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ISP_Biblioteka.Repos;
using ISP_Biblioteka.ViewModels;

namespace ISP_Biblioteka.Controllers
{
    public class AtaskaitaController : Controller
    {
        AtaskaitaRepository neaktyvRepository = new AtaskaitaRepository();

        // GET: Ataskaita
        public ActionResult UzsakymuIstorija()
        {
            return View();
        }
        public ActionResult AtaskaituSiuntimas()
        {
            return View();
        }
        public ActionResult IsiskolineSkaitytojai()
        {
            return View();
        }
        public ActionResult KnyguStatistika()
        {
            return View();
        }
        public ActionResult MetMenAtaskaita()
        {
            return View();
        }
        public ActionResult NeaktyvusVartotojai(int? period)
        {
            NeaktyvusViewModel neaktyvus = new NeaktyvusViewModel();

            PopulateSelections(neaktyvus);

            neaktyvus.period = period == null ? null : period;

            neaktyvus.neaktyvus = neaktyvRepository.getNeaktyvusVartotojai(neaktyvus.period);

            return View(neaktyvus);
        }

        public void PopulateSelections(NeaktyvusViewModel vart)
        {
            List<SelectListItem> selectListlaikotarpiai = new List<SelectListItem>();

            selectListlaikotarpiai.Add(new SelectListItem() { Value = Convert.ToString(1), Text = "1 mėnuo" });

            vart.LaikotarpisList = selectListlaikotarpiai;
        }
    }
}