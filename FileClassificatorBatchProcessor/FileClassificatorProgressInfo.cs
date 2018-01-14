using System;
using System.Collections.Generic;
using System.Text;

namespace DMS.FC.BP
{
    [Serializable]
    public class FileClassificatorProgressInfo : DMS.JobProgressInfo
    {
        public FileClassificatorProgressInfo(int jobId, DMS.Job.JobStates jobState, long CountDirs, long CountFiles, long CountResults) 
            : base(jobId, jobState)
        {
            this.CountDirs = CountDirs;
            this.CountFiles = CountFiles;
            this.CountResults = CountResults;
        }

        public long CountDirs;
        public long CountFiles;
        public long CountResults;
    }
}
