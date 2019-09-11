using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Text.RegularExpressions;

namespace PHONE_RESEARCH_NEW
{
    class emails
    {
        
        public static void extract_mail(string html)
        {
            if(html!="")
            {
  
                MatchCollection coll = default(MatchCollection);
                string mail = "";
                int i = 0;
                coll = Regex.Matches(html, "([a-zA-Z0-9_\\-\\.]+)@([a-zA-Z0-9_\\-\\.]+)\\.([a-zA-Z]{2,5})");
                string[] results = new string[coll.Count];
                for (i = 0; i <= results.Length - 1; i++)
                {
                    results[i] = coll[i].Value;
                    mail = results[i];
                    debug.print_mail(mail);
                   
                }

            }
        }
    }
}
