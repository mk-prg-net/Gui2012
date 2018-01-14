using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace WebCrawlerTest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                WebCrawler.Crawler myCrawler = new WebCrawler.Crawler();
                myCrawler.EndOfCrawl += new WebCrawler.Crawler.DgEventEndOfCrawl(myCrawler_EndOfCrawl);

                Debug.WriteLine("Scann geht los...");
                myCrawler.crawl(Properties.Settings.Default.StartUrl, Properties.Settings.Default.Deept);
                Debug.WriteLine("Scann beendet");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Debug.Fail("Fehler in WebCrawlerTest: " + ex.Message);
            }
        }

        static void myCrawler_EndOfCrawl(long VisitedSitesCount)
        {
            Debug.WriteLine("Crawl beendet. Es wurden " + VisitedSitesCount + " Webseiten heruntergeladen");
            Console.WriteLine("Crawl beendet. Es wurden " + VisitedSitesCount + " Webseiten heruntergeladen");
        }
    }
}
