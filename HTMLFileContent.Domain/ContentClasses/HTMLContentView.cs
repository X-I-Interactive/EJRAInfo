using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using System.Collections.ObjectModel;
using System.Xml;
using HTMLFileContent.Repository.HTMLFileContentClasses;
using HTMLFileContent.RepositoryDatabase;

namespace HTMLFileContent.Domain
{
    public class HTMLContentView : IHTMLContent
    {
        public int HTMLContentID { get; set; }
        public int DisplayOrder { get; set; }
        public string MainTitle { get; set; }
        public string SecondaryTitle { get; set; }
        public ContentArea ContentArea { get; set; }
        public ICollection<ContentItem> ContentItems { get; set; }

        public List<ContentItemView> ContentItemsView { get; set; }

        public HTMLContentView()
        {
            ContentItemsView = new List<ContentItemView>();
            ContentItems = new Collection<ContentItem>();

        }

        public static void SaveContentItemView(HTMLContentView hTMLContentView, string connectionString)
        {
            using (HTMLFileContentDbContext dbContext = new HTMLFileContentDbContext(connectionString))
            {
                Mapper.CreateMap<HTMLContentView, HTMLContent>();
                Mapper.CreateMap<ContentItemView, ContentItem>();
                var hTMLContent = Mapper.Map<HTMLContentView, HTMLContent>(hTMLContentView);
                foreach (var item in hTMLContentView.ContentItemsView)
                {
                    hTMLContent.ContentItems.Add(Mapper.Map<ContentItemView, ContentItem>(item));
                }


                dbContext.HTMLContent.Add(hTMLContent);

                dbContext.SaveChanges();
            }
        }

        public static List<ContentItemView> MakeFileItem(string content)
        {
            List<ContentItemView> contentItems = new List<ContentItemView>();
            XmlDocument document = new XmlDocument();
            document.LoadXml(content);
            XmlElement documentRoot = document.DocumentElement;
            XmlNodeList baseNodes = documentRoot.SelectNodes("div");

            foreach (XmlNode baseItem in baseNodes)
            {
                XmlNodeList paragraphNodes = baseItem.SelectNodes("p");

                foreach (XmlNode paragraph in paragraphNodes)
                {
                    if (paragraph.InnerText.Trim() != string.Empty)
                    {
                        // replace the paragraph marks
                        string contentItem = paragraph.OuterXml;
                        contentItem = ReplaceSpecialCharacters(contentItem);
                        contentItems.Add(new ContentItemView { Content = contentItem, ContentType = ContentType.Paragraph });
                    }
                }


            }

            return contentItems;
        }

        public static string ReplaceSpecialCharacters(string content)
        {
            content = content.Replace("Â", " ");    // UTF-8 for nbsp

            content = content.Replace("\u0092", "'");
            content = content.Replace("\u0093", "\"");
            content = content.Replace("\u0094", "\"");
            content = content.Replace("\u0096", "-");
            content = content.Replace("\u0097", " ");
            content = content.Replace("\u00A0", " ");
            if (content.Contains(@"\u"))
            {
                Console.WriteLine(content);
            }
            //content = content.Replace("\x4F4", "'");    //92
            //content = content.Replace("\x5A0", "-");    //96

            //content = content.Replace("\uFFFD","");
            return content;
        }

    }


    
public class ContentItemView : IContentItem
    {
        public string Content { get; set; }
        public int ContentItemID { get; set; }
        public ContentType ContentType { get; set; }
    }

    public class ContentListItem
    {
        public string MainTitle { get; set; }
        public string SecondaryTitle { get; set; }
        public int HTMLContentID { get; set; }

        public ContentListItem()
        {

        }

        public static List<ContentListItem> GetContentList(ContentArea contentArea, string connectionString)
        {
            List<ContentListItem> contentList = new List<ContentListItem>();

            using (HTMLFileContentDbContext dbContext = new HTMLFileContentDbContext(connectionString))
            {
                contentList = dbContext.HTMLContent.Where(x => x.ContentArea == contentArea)
                    .OrderBy(x => x.DisplayOrder).ThenBy(x => x.MainTitle)
                    .Select(x => new ContentListItem
                    {
                        MainTitle = x.MainTitle,
                        SecondaryTitle = x.SecondaryTitle,
                        HTMLContentID = x.HTMLContentID
                    }).ToList();
            }

            return contentList;
        }

        public static string GetContentForDisplay(int contentID, string connectionString)
        {
            StringBuilder sb = new StringBuilder();
            using (HTMLFileContentDbContext dbContext = new HTMLFileContentDbContext(connectionString))
            {
                var hTMLContent = dbContext.HTMLContent.FirstOrDefault(x => x.HTMLContentID == contentID);
                foreach( var item in hTMLContent.ContentItems)
                {
                    sb.AppendLine(item.Content);
                }
            }
            return sb.ToString();
        }

    }

}
