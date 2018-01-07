using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLFileContent.Repository.HTMLFileContentClasses
{
    public class ContentItem : IContentItem
    {
        public int ContentItemID { get; set; }
        public string Content { get; set; }
        public ContentType ContentType { get; set; }
    }

    public enum ContentType
    {
        Paragraph = 1
    }
}
