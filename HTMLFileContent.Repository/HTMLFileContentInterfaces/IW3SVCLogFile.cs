using System;

namespace HTMLFileContent.Repository.HTMLFileContentClasses
{
    public interface IW3SVCLogFile
    {
        string ClientIP { get; set; }
        int CsBytes { get; set; }
        string CsCookie { get; set; }
        string CSMethod { get; set; }
        string CsReferer { get; set; }
        string CSUriQuery { get; set; }
        string CSUriStem { get; set; }
        string CsUserAgent { get; set; }
        string CsUsername { get; set; }
        string CsVersion { get; set; }
        DateTime Date { get; set; }
        int ScBytes { get; set; }
        int ScStatus { get; set; }
        int ScSubStatus { get; set; }
        int ScWin32Status { get; set; }
        string SourceIP { get; set; }
        string SourceSitename { get; set; }
        int SPort { get; set; }
        DateTime Time { get; set; }
        int TimeTaken { get; set; }
        int W3SVCLogFileID { get; set; }
    }
}