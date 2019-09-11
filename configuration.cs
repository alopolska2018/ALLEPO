using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PHONE_RESEARCH_NEW
{
    class configuration
    {
        public static void service_startup()
        {
            RegistryKey sKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (sKey.GetValue("ALLEPO") == null)
            {
                sKey.SetValue("ALLEPO", System.Reflection.Assembly.GetExecutingAssembly().Location);
                sKey.Close();

            }
        }
        public static void _init_config_files()
        {
              ReaderWriterLock _locker = new ReaderWriterLock();

            string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string[] _file_list = new string[] {desktop+ "\\foreign_phones.csv",
                desktop + "\\polish_phones.csv",
            desktop + "\\mails.csv"};

            foreach(string pathes in _file_list)
            {
                if(!File.Exists(pathes))
                {
                    Console.WriteLine(pathes);
                    File.AppendAllText(pathes, "");
                }
            }
        }
    }
}
