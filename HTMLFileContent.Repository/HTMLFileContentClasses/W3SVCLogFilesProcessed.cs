using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HTMLFileContent.Repository.HTMLFileContentClasses

{
    [Table("W3SVCLogFilesProcessed")]
    public class W3SVCLogFilesProcessed : IW3SVCLogFilesProcessed
    {
        [Key]
        public int W3SVCLogFilesProcessedID { get; set; }
        public string fileName { get; set; }
        public DateTime DateProcessed { get; set; }
    }
}
