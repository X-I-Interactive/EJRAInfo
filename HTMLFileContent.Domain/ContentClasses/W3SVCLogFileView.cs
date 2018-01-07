using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HTMLFileContent.Repository.HTMLFileContentClasses;
using HTMLFileContent.RepositoryDatabase;

namespace HTMLFileContent.Domain
{
    public class W3SVCLogFileView : IW3SVCLogFile
    {
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

        public static void StoreLine(List<string> lines, string connectionString)
        {

            using (HTMLFileContentDbContext dbContext = new HTMLFileContentDbContext(connectionString))
            {
                foreach (string line in lines)
                {
                    string[] lineContent = line.Split(' ');
                    W3SVCLogFile w3SVCLogFile = new W3SVCLogFile();

                    w3SVCLogFile.Date = DateTime.ParseExact(lineContent[(int)W3SVCLogFileFields.Date], "yyyy-MM-dd", CultureInfo.InvariantCulture);
                    w3SVCLogFile.Time = DateTime.ParseExact(lineContent[(int)W3SVCLogFileFields.Time], "H:m:s", null);
                    w3SVCLogFile.CsBytes = Convert.ToInt32(lineContent[(int)W3SVCLogFileFields.CsBytes]);
                    w3SVCLogFile.CsCookie = lineContent[(int)W3SVCLogFileFields.CsCookie];
                    w3SVCLogFile.CSMethod = lineContent[(int)W3SVCLogFileFields.CSMethod];
                    w3SVCLogFile.CsReferer = lineContent[(int)W3SVCLogFileFields.CsReferer];
                    w3SVCLogFile.ClientIP = lineContent[(int)W3SVCLogFileFields.ClientIP];
                    w3SVCLogFile.CSUriQuery = lineContent[(int)W3SVCLogFileFields.CSUriQuery];
                    w3SVCLogFile.CSUriStem = lineContent[(int)W3SVCLogFileFields.CSUriStem];
                    w3SVCLogFile.CsUserAgent = lineContent[(int)W3SVCLogFileFields.CsUserAgent];
                    w3SVCLogFile.CsUsername = lineContent[(int)W3SVCLogFileFields.CsUsername];
                    w3SVCLogFile.CsVersion = lineContent[(int)W3SVCLogFileFields.CsVersion];
                    w3SVCLogFile.ScBytes = Convert.ToInt32(lineContent[(int)W3SVCLogFileFields.ScBytes]);
                    w3SVCLogFile.ScStatus = Convert.ToInt32(lineContent[(int)W3SVCLogFileFields.ScStatus]);
                    w3SVCLogFile.ScSubStatus = Convert.ToInt32(lineContent[(int)W3SVCLogFileFields.ScSubStatus]);
                    w3SVCLogFile.ScWin32Status = Convert.ToInt32(lineContent[(int)W3SVCLogFileFields.ScWin32Status]);
                    w3SVCLogFile.SourceIP = lineContent[(int)W3SVCLogFileFields.SourceIP];
                    w3SVCLogFile.SourceSitename = lineContent[(int)W3SVCLogFileFields.SourceSitename];
                    w3SVCLogFile.SPort = Convert.ToInt32(lineContent[(int)W3SVCLogFileFields.SPort]);
                    w3SVCLogFile.TimeTaken = Convert.ToInt32(lineContent[(int)W3SVCLogFileFields.TimeTaken]);

                    dbContext.W3SVCLogFile.Add(w3SVCLogFile);
                }

                dbContext.SaveChanges();
            }   
        }
    }


    public enum W3SVCLogFileFields
    {
        Date = 0,
        Time,
        SourceSitename,
        SourceIP,
        CSMethod,
        CSUriStem,
        CSUriQuery,
        SPort,
        CsUsername,
        ClientIP,
        CsVersion,
        CsUserAgent,
        CsCookie,
        CsReferer,
        ScStatus,
        ScSubStatus,
        ScWin32Status,
        ScBytes,
        CsBytes,
        TimeTaken
    }

}
