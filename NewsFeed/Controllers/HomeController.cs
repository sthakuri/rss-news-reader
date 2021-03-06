﻿using System.Web.Mvc;
using NewsFeed.Channel;
using NewsFeed.Model;

namespace NewsFeed.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new ViewModel();
            model.Add(new BBCNepali());
            model.Add(new BizMandu());
            model.Add(new Google());
            model.Add(new HimalKhabar());
            model.Add(new ImageKhabar());
            model.Add(new NagarikNews());
            model.Add(new OnlineKhabar());
            model.Add(new PahiloPost());
            model.Add(new RatoPati());
            model.Add(new SetoPati());
            model.Add(new UjyaloOnline());
            model.Add(new SwasthyaKhabar());
            model.Add(new AakarPost());
            model.Add(new NayaPatrika());

            return View(model);
        }
    }
}