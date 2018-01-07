using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HTMLFileContent.Domain;
using HTMLFileContent.Repository.HTMLFileContentClasses;

namespace EJRAInfo.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        public ActionResult SpeechLinksList()
        {
            HTMLContentView hTMLContentView = new HTMLContentView();
            string connectionString = ConfigurationManager.ConnectionStrings["CHFConnectionString"].ConnectionString;

            List<ContentListItem> contentList = ContentListItem.GetContentList(ContentArea.Speech, connectionString);

            return PartialView("ContentLinksList", contentList);
        }

        public ActionResult OxfordMagazineLinksList()
        {
            HTMLContentView hTMLContentView = new HTMLContentView();
            string connectionString = ConfigurationManager.ConnectionStrings["CHFConnectionString"].ConnectionString;

            List<ContentListItem> contentList = ContentListItem.GetContentList(ContentArea.OxfordMagazine, connectionString);

            return PartialView("ContentLinksList", contentList);
        }

        [HttpPost]
        public ActionResult GetContent(int contentID)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["CHFConnectionString"].ConnectionString;
            string contentForDisplay = ContentListItem.GetContentForDisplay(contentID, connectionString);

            return PartialView("ContentDisplay", contentForDisplay);
        }
    }
}