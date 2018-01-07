using System.Collections.Generic;

namespace HTMLFileContent.Repository.HTMLFileContentClasses
{
    public interface IHTMLContent
    {
        ContentArea ContentArea { get; set; }
        ICollection<ContentItem> ContentItems { get; set; }
        int DisplayOrder { get; set; }
        int HTMLContentID { get; set; }
        string MainTitle { get; set; }
        string SecondaryTitle { get; set; }
    }
}