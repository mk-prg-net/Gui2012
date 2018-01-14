using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCrawler
{
    class PageDownloadJob : DMS.Job
    {
        public string Url
        {
            get;
            set;
        }

        /// <summary>
        /// Tiefe, bis zu der Links verfolgt werden sollen
        /// </summary>
        public int ActDeept
        {
            get;
            set;
        }
    }
}
