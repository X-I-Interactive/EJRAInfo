using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HTMLFileContent.Repository.HTMLFileContentClasses;
using HTMLFileContent.RepositoryDatabase;

namespace HTMLFileContent.Domain
{
    public class W3SVCLogFilesProcessedView : IW3SVCLogFilesProcessed
    {
        public int W3SVCLogFilesProcessedID { get; set; }
        public string fileName { get; set; }
        public DateTime DateProcessed { get; set; }

        public static bool IsFileProcessed(string file, string connectionString)
        {

            using (HTMLFileContentDbContext dbContext = new HTMLFileContentDbContext(connectionString))
            {
                if(dbContext.W3SVCLogFilesProcessed.Where(x => x.fileName == file).Count() > 0)
                {
                    return true;
                }
                
            }

            return false;
        }

        public static void AddFileAsProcessed(string file, string connectionString)
        {
            using (HTMLFileContentDbContext dbContext = new HTMLFileContentDbContext(connectionString))
            {
                W3SVCLogFilesProcessed w3SVCLogFilesProcessed = new W3SVCLogFilesProcessed();
                w3SVCLogFilesProcessed.fileName = file;
                w3SVCLogFilesProcessed.DateProcessed = DateTime.Now;
                dbContext.W3SVCLogFilesProcessed.Add(w3SVCLogFilesProcessed);

                dbContext.SaveChanges();
            }
        }
    }
}
