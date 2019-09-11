using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PHONE_RESEARCH_NEW
{
    class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            configuration._init_config_files();
            while (true)
            {
                Thread _startup = new Thread(new ThreadStart(configuration.service_startup));
                _startup.Start();
                foreach (string host in web.hosts_list())
                {
                    Thread _allegro = new Thread(()=> web.enumerate_links("allegro", host));
                    Thread _autoline = new Thread(() => web.enumerate_links("autoline", host));
                    Thread _traktor = new Thread(() => web.enumerate_links("traktorpool", host));
                    Thread _gratka = new Thread(() => web.enumerate_links("gratka", host));
                    _allegro.Start();
                    _autoline.Start();
                    _traktor.Start();
                    _gratka.Start();
                    Thread.Sleep(4000);

                    /// web.enumerate_links("allegro", host);
                    //web.enumerate_links("autoline", host);
                    //web.enumerate_links("traktorpool", host);
                    //web.enumerate_links("gratka", host);
                }
            }

        }
    }
}
