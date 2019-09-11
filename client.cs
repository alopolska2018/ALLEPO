using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Threading;

namespace PHONE_RESEARCH_NEW
{
    class client
    {
        //Function for downloading page to the local disk
        //Then load it from the HTMLWEBLOAD
        //AND EXTRACT EMAILS WITH REGEX from another class
        public static string downloadpage(string host)
        {
            string html = string.Empty;
            if(host!="")
            {
                try
                {
                    Thread.Sleep(4000);
                    WebClient _client = new WebClient();                    
                    html = _client.DownloadString(host);

                }
                catch(WebException ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
            return html;
        }
 
    }
}
