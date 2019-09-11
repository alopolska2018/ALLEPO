using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PHONE_RESEARCH_NEW.GUI
{
    public partial class Control : Form
    {
         public Control()
        {
            InitializeComponent();
        }

         private void Control_Load(object sender, EventArgs e)
        {
            
          // startstop();
        }
        public static void startstop(bool stop)
        {
           while(!stop)
            {
              
                foreach (string host in web.hosts_list())
                {

                    web.enumerate_links("allegro", host);
                    web.enumerate_links("autoline", host);
                    web.enumerate_links("traktorpool", host);
                    web.enumerate_links("gratka", host);
                }
            }
        }

        private void ActionBtn_Click(object sender, EventArgs e)
        {

            bool stop = false;
            Thread call = new Thread(() => startstop(stop));
            if(!stop)
            {
                actionBtn.Text = "Stop ACTION";
                stop = true;
                call.Abort();
                return;
            }
            if(stop)
            {
                actionBtn.Text = "Start ACTION";
                stop = false;
                call.Start();
                return;
            }
           
        }
    }
}
