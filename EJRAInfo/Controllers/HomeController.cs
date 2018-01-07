using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Mvc;
using EJRAInfo.Models;

namespace EJRAInfo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EJRAIntroduction()
        {
            return View();
        }

        public ActionResult EJRALinks()
        {
            return View();
        }

        public ActionResult EJRAOther()
        {
            return View();
        }

        public ActionResult EJRAJudgements()
        {
            return View();
        }

        public ActionResult EJRAGalligan()
        {
            return View();
        }

        public ActionResult EJRAGovernance()
        {
            return View();
        }

        public ActionResult EJRAPress()
        {
            return View();
        }

        public ActionResult ContactUs()
        {
            var contactViewModel = new ContactViewModel();
            return View(contactViewModel);
        }


        public ActionResult EJRAMotion()
        {
            return View();
        }
        public ActionResult EJRAWhyMotion()
        {
            return View();
        }

        public ActionResult EJRADebate()
        {
            return View();
        }

        public ActionResult EJRAOxfordMagazine()
        {
            return View();
        }

        public ActionResult EJRAMotionSupport()
        {
            return View();
        }
        public ActionResult SupportUs()
        {
            return View();
        }

        public ActionResult InformOthers()
        {
            return View();
        }

        public ActionResult EJRAAbolish()
        {
            return View();
        }

        public ActionResult EJRAFAQs()
        {
            return View();
        }

        public ActionResult EJRAKeyPoints()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ContactUs(ContactViewModel contactViewModel)
        {

            if (!ModelState.IsValid)
            {
                return View(contactViewModel);
            }

            var contact = new Contact
            {
                From = contactViewModel.From,
                Subject = contactViewModel.Subject,
                Message = contactViewModel.Message
            };

            string emailAccount = WebConfigurationManager.AppSettings["EmailAccount"];
            string emailPassword = WebConfigurationManager.AppSettings["EmailPassword"];
            string eMailClient = WebConfigurationManager.AppSettings["EMailClient"];
            string defaultEmailFrom = WebConfigurationManager.AppSettings["DefaultEmailFrom"];

            new Email(emailAccount, emailPassword, eMailClient, defaultEmailFrom).Send(contact);

            return RedirectToAction("index", "Home");
        }
        #region Non-view functions


        #endregion
    }
}