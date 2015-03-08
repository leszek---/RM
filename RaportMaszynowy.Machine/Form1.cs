using RaportManager.Domian;
using System;
using System.Windows.Forms;

namespace RaportMaszynowy.Machine
{
    public partial class Form1 : Form
    {
        public const int Interval = 10000;

        public ShiftManager ShiftManager { get; set; }

        public ApiManager ApiManager { get; set; }


        public Form1()
        {
            InitializeComponent();
            ShiftManager = new ShiftManager();
            ApiManager = new ApiManager();
       
            timer1.Interval = Interval;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text += @"Maszyna - Start";
            textBox1.Text += Environment.NewLine;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox1.Text += @"Maszyna - Nowa sztuka";
            textBox1.Text += Environment.NewLine;
            var item = new Item();
            item.DateCreated = DateTime.Now; 
            item.ShiftNumber = ShiftManager.GetShiftNumber();
            ApiManager.SendItem(item);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text += @"Maszyna - Stop";
            textBox1.Text += Environment.NewLine;
            timer1.Stop();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text += @"Maszyna - Wystąpił bład";
            timer1.Stop();
            textBox1.Text += @"Maszyna - Stop";

            textBox1.Text += Environment.NewLine;
            ApiManager.ReportError();
        }
    };
}