using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCrawler
{
    public class PageDownloadJobProgressInfo : DMS.JobProgressInfo
    {
        public PageDownloadJobProgressInfo(
            string Url, 
            long VistedSitesCount,
            int JobId, 
            DMS.Job.JobStates state)
            : base(JobId, state)
        {
            this.Url = Url;
            this.VisitedSitesCount = VisitedSitesCount;
        }

        public string Url { get; set; }
        public long VisitedSitesCount { get; set; }
    }
}
