using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHONE_RESEARCH_NEW
{
    class web
    {
        //there must be links 
        //for scrapper
        public static string[] hosts_list()
        {
            string[] hosts = new string[] {
            "https://allegro.pl/kategoria/motoryzacja-maszyny-252942?bmatch=baseline-n-dict4-eyesa-bp-adv-1-5-0619",
             "https://autoline.com.pl/",
              "https://www.traktorpool.pl",
              "https://gratka.pl/motoryzacja/maszyny-budowlane",
              "https://www.mascus.pl/budownictwo,1,relevance,sprzedaz.html",

            };
            return hosts;
        }
        public static string[] prefix_list()
        {
            string[] host = new string[] { "https://allegro.pl/ogloszenie/", "https://autoline.com.pl", "https://traktorpool.com", "https://gratka.pl", "https://mascus.pl" };
            return host;
        }
        public static void enumerate_links(string certain, string host)
        {
            if (certain != "" && host != "")
            {
                string href_xpath = string.Empty;
                string prefix = string.Empty;
                switch (certain)
                {
                    case "allegro":
                        href_xpath = "/html/body/div[2]/div[*]/div/div/div/div/div/div[2]/div[1]/div[3]/div/div/div/div[2]/div[1]/div/section[2]/section/article[*]/div/div/div[2]/div[1]/h2";
                        break;
                    case "autoline":
                        href_xpath = "//*[@id=\"content\"]/div[*]/div/div[*]/article/span";
                        break;
                    case "traktorpool":
                        href_xpath = "//*[@id=\"specialOffers\"]/div/div/div[*]";
                        break;
                    case "gratka":
                        href_xpath = "//*[@class=\"teaser__infoBox\"]/h2";

                        break;
                    case "mascus":
                        prefix = "https://www.mascus.pl";
                        href_xpath = "//*[@id=\"search-results\"]/div[2]/ul/li[*]/div[*]/table/tbody/tr/td[*]/span";
                        break;
                }

                var WebSite = new HtmlWeb();
                var Document = WebSite.Load(host);
                if (Document != null)
                {
                    var SelectDiv = Document.DocumentNode.SelectNodes(href_xpath);
                    if (SelectDiv != null)
                    {
                        foreach (var enumHref in SelectDiv)
                        {
                            if (enumHref != null)
                            {
                                var link = enumHref.Descendants("a").ToList()[0].GetAttributeValue("href", null);

                                //PRINT THE LINK
                                debug.print_host(link);

                                //EXTRACT THE PHONE NUMBER
                               phones.phone_regex_extractor(client.downloadpage(link));
                                emails.extract_mail(client.downloadpage(link));
                            }
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("ONE OF PARAMS IS EMPTY");
            }
        }
    }
}




 