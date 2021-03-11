using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entities;

namespace MvcKurumsalSite.Models
{
    public class HomePageVM
    {
        public List<Slide> Slide { get; set; }
        public List<Category> Categories { get; set; }

    }
}