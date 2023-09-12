using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proiect_final
{
    public partial class Form1 : Form
    {
        public static Bitmap btm2;
        Bitmap btm;
        Graphics g;
        ColorDialog cd = new ColorDialog();
        Color new_colr = Color.Black;
        Pen p = new Pen(Brushes.Black);
        int index = 0;

        public Form1()
        {
            InitializeComponent();
            this.Width = 900;
            this.Height = 900;
            btm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(btm);
            g.Clear(Color.White);
            pictureBox1.Image = btm;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Print_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
                printDocument1.Print();
        }

        private void Colors_Click(object sender, EventArgs e)
        {
            cd.ShowDialog();
            new_colr = cd.Color;
            p.Color = cd.Color;
        }

        private void Play_Click(object sender, EventArgs e)
        {
            if (Nr_fig.Text == "") Nr_fig.Text = "0";
            Random r = new Random();
                int caz = 0;
                if (Figuri.Text == "Linie") caz = 1;
                if (Figuri.Text == "Triunghi") caz = 2;
                if (Figuri.Text == "Dreptunghi") caz = 3;
                if (Figuri.Text == "Elipsa") caz = 4;
                if (Figuri.Text == "Curba Bezier") caz = 5;
                switch (caz)
                {
                    case 1:
                        Linie l;
                        for (int i = 0; i < Convert.ToInt32(Nr_fig.Text); i++)
                        {
                            int z = r.Next(100);
                            if (z % 6 == 0)
                            {
                                l = new Linie(new Point(0, r.Next(pictureBox1.Height)), new Point(r.Next(pictureBox1.Width), 0), p);
                            }
                            else if (z % 6 == 1)
                            {
                                l = new Linie(new Point(pictureBox1.Width, r.Next(pictureBox1.Height)), new Point(r.Next(pictureBox1.Width), pictureBox1.Height), p);
                            }
                            else if (z % 6 == 2)
                            {
                                l = new Linie(new Point(r.Next(pictureBox1.Width), 0), new Point(r.Next(pictureBox1.Width), pictureBox1.Height), p);
                            }
                            else if (z % 6 == 3)
                            {
                                l = new Linie(new Point(pictureBox1.Width, r.Next(pictureBox1.Height)), new Point(0, r.Next(pictureBox1.Height)), p);
                            }
                            else if (z % 6 == 4)
                            {
                                l = new Linie(new Point(0, r.Next(pictureBox1.Height)), new Point(pictureBox1.Width, r.Next(pictureBox1.Height)), p);
                            }
                            else
                            {
                                l = new Linie(new Point(0, r.Next(pictureBox1.Height)), new Point(r.Next(pictureBox1.Width), pictureBox1.Height), p);
                            }
                            l.deseneaza(g);
                        }
                        break;
                    case 2:
                        Triunghi t;
                        for (int i = 0; i < Convert.ToInt32(Nr_fig.Text); i++)
                        {
                            t = new Triunghi(new Point(r.Next(pictureBox1.Width), r.Next(pictureBox1.Height)), new Point(r.Next(pictureBox1.Width), r.Next(pictureBox1.Height)), new Point(r.Next(pictureBox1.Width), r.Next(pictureBox1.Height)), p);
                            t.deseneaza(g);
                        }
                        break;
                    case 3:
                        Dreptunghi d;
                        for (int i = 0; i < Convert.ToInt32(Nr_fig.Text); i++)
                        {
                            d = new Dreptunghi(new Rectangle(r.Next(pictureBox1.Width), r.Next(pictureBox1.Height), r.Next(pictureBox1.Width), r.Next(pictureBox1.Height)), p);
                            d.deseneaza(g);
                        }
                        break;
                    case 4:
                        Elipsa el;
                        for (int i = 0; i < Convert.ToInt32(Nr_fig.Text); i++)
                        {
                            el = new Elipsa(new Rectangle(r.Next(pictureBox1.Width), r.Next(pictureBox1.Height), r.Next(pictureBox1.Width), r.Next(pictureBox1.Height)), p);
                            el.deseneaza(g);
                        }
                        break;
                    case 5:
                        CurbaB cb;
                        for (int i = 0; i < Convert.ToInt32(Nr_fig.Text); i++)
                        {

                            cb = new CurbaB(new Point(r.Next(pictureBox1.Width), r.Next(pictureBox1.Height)), new Point(r.Next(pictureBox1.Width), r.Next(pictureBox1.Height)), new Point(r.Next(pictureBox1.Width), r.Next(pictureBox1.Height)), new Point(r.Next(pictureBox1.Width), r.Next(pictureBox1.Height)), p);
                            cb.deseneaza(g);
                        }
                        break;
                    case 0: break;

                }
            pictureBox1.Refresh();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            btm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            g = Graphics.FromImage(btm);
            g.Clear(Color.White);
            pictureBox1.Image = btm;
        }

        
        private void Save_Click(object sender, EventArgs e)
            {
                saveFileDialog1.Filter = "Jpeg Image|*.jpg|Bitmap Image|*.bmp|Gif Image|*.gif";
                saveFileDialog1.Title = "Salvati Imagine ca";
                saveFileDialog1.ShowDialog();
                System.IO.FileStream fs = (System.IO.FileStream)saveFileDialog1.OpenFile();
                String Name = "ABCDEF" + DateTime.Now.Ticks.ToString();
                switch (saveFileDialog1.FilterIndex)
                {
                    case 1:
                        saveFileDialog1.FileName = Name + ".jpeg";
                        saveFileDialog1.DefaultExt = "*jpeg";
                        btm.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);
                        break;
                    case 2:
                        saveFileDialog1.FileName = Name + ".bmp";
                        saveFileDialog1.DefaultExt = "*bmp";
                        btm.Save(fs, System.Drawing.Imaging.ImageFormat.Bmp);
                        break;
                    case 3:
                        saveFileDialog1.FileName = Name + ".gif";
                        saveFileDialog1.DefaultExt = "*gif";
                        btm.Save(fs, System.Drawing.Imaging.ImageFormat.Gif);
                        break;
                }
         }
        private void Info_Click(object sender, EventArgs e)
        {
                    MessageBox.Show(" Informatii :) ","Info");
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
                    e.Graphics.DrawImage(btm, 0, 0);
        }
        private void printDocument1_EndPrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            MessageBox.Show("Imprimare", "Imprimare");
        }
        private void Ink_Click(object sender, EventArgs e)
        {
            btm2 = btm;
            Form2 popup = new Form2();
            popup.ShowDialog();
        }
        private void valideaza(Bitmap btm, Stack<Point> sp, int x, int y, Color old_color, Color new_color)
        {
            Color cx = btm.GetPixel(x, y);
            if (cx == old_color)
            {
                sp.Push(new Point(x, y));
                btm.SetPixel(x, y, new_color);
            }
        }
        private void Fill_Click(object sender, EventArgs e)
        {
            if (index == 0)
            {
                index = 1;
                
            }
            else
            {
                index = 0;

            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (index == 1)
            {
                Point point = new Point();
                point.X = e.X;
                point.Y = e.Y;
                fill(btm, point.X, point.Y, new_colr);
                pictureBox1.Refresh();
            }
        }

        public void fill(Bitmap btm, int x, int y, Color new_clr)
        {
            Color old_color = btm.GetPixel(x, y);
            Stack<Point> pixel = new Stack<Point>();
            pixel.Push(new Point(x, y));
            btm.SetPixel(x, y, new_clr);
            if (old_color == new_clr) return;
            while (pixel.Count > 0)
            {
                Point pt = (Point)pixel.Pop();
                if (pt.X > 0 && pt.Y > 0 && pt.X < btm.Width - 1 && pt.Y < btm.Height - 1)
                {
                    valideaza(btm, pixel, pt.X - 1, pt.Y, old_color, new_clr);
                    valideaza(btm, pixel, pt.X + 1, pt.Y, old_color, new_clr);
                    valideaza(btm, pixel, pt.X, pt.Y - 1, old_color, new_clr);
                    valideaza(btm, pixel, pt.X, pt.Y + 1, old_color, new_clr);
                }
            }
        }

    }
}
