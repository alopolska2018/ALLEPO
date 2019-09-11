using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace PHONE_RESEARCH_NEW
{
    class debug
    {
        //for handling errors in threat mode
        static ReaderWriterLock _locker = new ReaderWriterLock();
        static string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        public static void print_phone(string pattern)
        {
            if(pattern!="")
            {
                bool is_number = pattern.Any(c => char.IsDigit(c));
                if(is_number)
                {
                   
                    if (pattern.Contains("-"))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(DateTime.Now.ToString() + " [+] PHONE_NUMBER -> FOREIGN -> : " + pattern);
                     write_DATA(desktop + "\\foreign_phones.csv", pattern);
                    }
                    if (pattern.Contains("+48"))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(DateTime.Now.ToString() + " [+] PHONE_NUMBER -> POLISH -> : " + pattern);
                        write_DATA(desktop + "\\polish_phones.csv", pattern);
                    }
                    if(!pattern.Contains("+48"))
                    {
                        pattern = "+48 " + pattern;
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(DateTime.Now.ToString() + " [+] PHONE_NUMBER -> POLISH -> : " + pattern);
                        write_DATA(desktop + "\\polish_phones.csv", pattern);
                    }
                     
                }
               
              
            }
            pattern = string.Empty;
             
        }

        public static void print_mail(string mail)
        {
            if(mail!="")
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine(DateTime.Now.ToString() + " [+] ACCEPTED -> MAIL_ADDRESS -> : " + mail);
                write_DATA(desktop + "\\mails.csv", mail);
            }
        }

        public static void print_host(string host)
        {
            if(host!="")
            {
                string[] split_link = Regex.Split(host, "/");
                string shortLink = split_link[0].ToString() + "/" +
                    split_link[1].ToString() + "/" + split_link[2].ToString()
                  + "/" + split_link[3].ToString() + "/" + split_link[4].ToString();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine(DateTime.Now.ToString() + "[+] HOST -> URL -> : " + shortLink);
                host = "";
            }
        }
        public static void write_DATA(string file, string extracted_data)
        {
             
            try
            {

              lock(_locker)
                {
                    string _db = string.Empty;
                     using (FileStream _readStream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        using (StreamReader _stReader = new StreamReader(_readStream))
                        {
                            _db = _stReader.ReadToEnd();
                        }
                    }

                    if (!_db.Contains(extracted_data))
                    {
                        File.AppendAllText(file, "\r\n" + extracted_data);

                    }
                }

            }
            finally
            {
                Console.WriteLine("[+] ADDED TO THE -> " + file);
            }
        }
    }
}
