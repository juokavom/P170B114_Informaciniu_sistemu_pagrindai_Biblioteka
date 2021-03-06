﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ISP_Biblioteka.ViewModels
{
    public class UzsakymuIstorijaViewModel2
    {
        public List<UzsakymuIstorijaViewModel1> uzsak { get; set; }

        [DisplayName("Laikotarpis: ")]
        public int? period { get; set; }

        [DisplayName("Vartotojas: ")]
        public int? user { get; set; }
        public IList<SelectListItem> LaikotarpisList { get; set; }

        public IList<SelectListItem> VartotojasList { get; set; }
    }
}