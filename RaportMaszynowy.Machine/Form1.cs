using RaportManager.Domian;
using System;
using System.Windows.Forms;

namespace RaportMaszynowy.Machine
{
    public partial class Form1 : Form
    {
        public const int Interval = 5000;

        public ShiftManager ShiftManager { get; set; }

        public ApiManager ApiManager { get; set; }

        public Settings Settings { get; set; }

        public Form1()
        {
            InitializeComponent();
            ShiftManager = new ShiftManager();
            ApiManager = new ApiManager();
            Settings = ApiManager.GetTaskSettings();
            timer1.Start();
            timer1.Interval = Interval;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            var item = new Item();
            item.DateCreated = DateTime.Now;
            item.Settings.Add(Settings);
            item.ShiftNumber = ShiftManager.GetShiftNumber();
            ApiManager.SendItem(item);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ApiManager.ReportError();
        }
    };
}