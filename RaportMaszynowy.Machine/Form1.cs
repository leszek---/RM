using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace RaportMaszynowy.Machine
{
    public partial class Form1 : Form
    {



        public ShiftManager ShiftManager { get; set; }
        public ApiManager ApiManager { get; set; }

        public Form1()
        {
            InitializeComponent();
            ShiftManager = new ShiftManager();
            ApiManager = new ApiManager();
            timer1.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            //// tworzysz item 
            //// ustawiasz mu settings 
            //var task = new 
            //ApiManager.GetTaskSettings()
        }
    };
}
