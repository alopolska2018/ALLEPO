using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PHONE_RESEARCH_NEW
{
    class phones
    {
        //Regex for phone numbers
        public static string phone_regex = @"(?<!\w)(\(?(\+|00)?48\)?)?[ -]?\d{3}[ -]?\d{3}[ -]?\d{3}(?!\w)";

        //Extract phones from the html source code
        public static void phone_regex_extractor(string html)
        {
            if(html!="")
            {
                
                Regex _rex = new Regex(phone_regex);
                MatchCollection _collection = _rex.Matches(html);
                if(_collection.Count>0)
                {
                    foreach(Match _phone_number in _collection)
                    {
                        if(_phone_number.Value !="")
                        {
                          debug.print_phone(_phone_number.Value);
                            
                        }
                    }
                }
            }
        }
    }
}
