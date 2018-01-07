using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTMLFileContent.Repository.HTMLFileContentClasses
{
    [Table("W3SVCLogFile")]
    public class W3SVCLogFile : IW3SVCLogFile
    {
        [Key]
        public int W3SVCLogFileID { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public string SourceSitename { get; set; }
        public string SourceIP { get; set; }
        public string CSMethod { get; set; }
        public string CSUriStem { get; set; }
        public string CSUriQuery { get; set; }
        public int SPort { get; set; }
        public string CsUsername { get; set; }
        public string ClientIP { get; set; }
        public string CsVersion { get; set; }
        public string CsUserAgent { get; set; }
        public string CsCookie { get; set; }
        public string CsReferer { get; set; }
        public int ScStatus { get; set; }
        public int ScSubStatus { get; set; }
        public int ScWin32Status { get; set; }
        public int ScBytes { get; set; }
        public int CsBytes { get; set; }
        public int TimeTaken { get; set; }
    }
}
