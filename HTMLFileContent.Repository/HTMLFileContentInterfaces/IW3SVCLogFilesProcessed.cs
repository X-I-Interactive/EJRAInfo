using System;

namespace HTMLFileContent.Repository.HTMLFileContentClasses
{
    public interface IW3SVCLogFilesProcessed
    {
        DateTime DateProcessed { get; set; }
        string fileName { get; set; }
        int W3SVCLogFilesProcessedID { get; set; }
    }
}