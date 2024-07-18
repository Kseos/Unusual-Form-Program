using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace lab2
{
    public partial class Form1 : Form
    {
        Point moveStart;
        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.White;
            Button button1 = new Button
            {
                Location = new Point(265, Height/20),
                Text = "Close"
            };
            button1.Click += Button1_Click;
            this.Controls.Add(button1);
            this.Load += Form1_Load;
            this.MouseDown += Form1_MouseDown;
            this.MouseMove += Form1_MouseMove;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GraphicsPath myPath = new GraphicsPath();
            int x = 0; int y = 0;
            int width = 600; int height = 600;
            int startAngle = 225; int sweepAngle = 90;
            myPath.AddPie(x, y, width, height, startAngle, sweepAngle);
            Region myRegion = new Region(myPath);
            this.Region = myRegion;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e){
            if (e.Button == MouseButtons.Left) {
                moveStart = new Point(e.X, e.Y);
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e){
            if ((e.Button & MouseButtons.Left) != 0){
                Point deltaPos = new Point(e.X - moveStart.X, e.Y - moveStart.Y);
                this.Location = new Point(this.Location.X + deltaPos.X,
                  this.Location.Y + deltaPos.Y);
            }
        }
    }
}
