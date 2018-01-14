using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WebCrawler
{
    class PickLinksJob : DMS.Job
    {
        public string  HtmlText { get; set; }

        public int ActDeept { get; set; }
    }
}
