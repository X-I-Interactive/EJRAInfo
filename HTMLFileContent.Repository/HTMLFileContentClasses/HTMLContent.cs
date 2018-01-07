using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLFileContent.Repository.HTMLFileContentClasses
{
    [Table("HTMLContent")]
    public class HTMLContent : IHTMLContent
    {
        public int HTMLContentID { get; set; }
        public int DisplayOrder { get; set; }
        public string MainTitle { get; set; }
        public string SecondaryTitle { get; set; }
        public ContentArea ContentArea { get; set; }
        public virtual ICollection<ContentItem> ContentItems { get; set; }
        
    }

    public enum ContentArea
    {
        Speech = 1,
        OxfordMagazine = 2
    }
}
