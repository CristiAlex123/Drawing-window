using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Proiect_final
{
    public abstract class Figura
    {
        protected int x1, y1, x2, y2;
        protected Point a, b, c, d;
        protected Rectangle e;
        protected Pen pen;
        public Figura(Point a, Point b, Pen pen)
        {
            this.a = a;
            this.b = b;
            this.pen = pen;
        }
        public Figura(Point a, Point b, Point c, Pen pen)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.pen = pen;
        }
        public Figura(Rectangle e, Pen pen)
        {
            this.e = e;
            this.pen = pen;
        }
        public Figura(Rectangle e, int fig, Pen pen)
        {
            this.e = e;
            this.pen = pen;
        }
        public Figura(Point a, Point b, Point c, Point d, Pen pen)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
            this.pen = pen;
        }
        public int X1
        {
            get { return x1; }
            set { this.x1 = value; }
        }
        public int Y1
        {
            get { return y1; }
            set { this.y1 = value; }
        }
        public int X2
        {
            get { return x2; }
            set { this.x2 = value; }
        }
        public int Y2
        {
            get { return y2; }
            set { this.y2 = value; }
        }

        public Point A
        {
            get { return a; }
            set { a = value; }
        }
        public Point B
        {
            get { return b; }
            set { b = value; }
        }

        public Point C
        {
            get { return c; }
            set { c = value; }
        }

        public Point D
        {
            get { return d; }
            set { d = value; }
        }
        public abstract void deseneaza(Graphics g);
        public abstract double daLungime();


    }
    public class Linie : Figura
    {
        public Linie(Point a, Point b, Pen p) : base(a, b, p)
        {


        }
        public override void deseneaza(Graphics g)
        {
            g.DrawLine(pen, a, b);
        }
        public override double daLungime()
        {
            return Lungime(a, b);
        }

        public double Lungime(Point a, Point b)
        {
            return Math.Sqrt((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y));
        }
    }
    public class Triunghi : Figura
    {
        public Triunghi(Point a, Point b, Point c, Pen p) : base(a, b, c, p)
        {


        }
        public override void deseneaza(Graphics g)
        {

            g.DrawLine(pen, a, b);
            g.DrawLine(pen, b, c);
            g.DrawLine(pen, c, a);

        }

        public override double daLungime()
        {
            return Lungime(a, b) + Lungime(b, c) + Lungime(c, a);
        }
        public double Lungime(Point a, Point b)
        {
            return Math.Sqrt((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y));
        }
    }
    public class Elipsa : Figura
    {
        public Elipsa(Rectangle a, Pen p) : base(a, p)
        {


        }
        public override void deseneaza(Graphics g)
        {

            g.DrawEllipse(pen, e);

        }
        public override double daLungime()
        {
            return 2 * e.Height + 2 * e.Width;
        }
        public double Lungime(Point a, Point b)
        {
            return Math.Sqrt((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y));
        }
    }
    public class Dreptunghi : Figura
    {
        public Dreptunghi(Rectangle a, Pen p) : base(a, 1, p)
        {


        }
        public override void deseneaza(Graphics g)
        {

            g.DrawRectangle(pen, e);

        }
        public override double daLungime()
        {
            return 2 * e.Height + 2 * e.Width;
        }
        public double Lungime(Point a, Point b)
        {
            return Math.Sqrt((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y));
        }
    }
    public class CurbaB : Figura
    {
        public CurbaB(Point a, Point b, Point c, Point d, Pen p) : base(a, b, c, d, p)
        {


        }
        public override void deseneaza(Graphics g)
        {
            g.DrawBezier(pen, a, b, c, d);
        }
        public override double daLungime()
        {
            return Lungime(a, b);
        }
        public double Lungime(Point a, Point b)
        {
            return Math.Sqrt((a.X - b.X) * (a.X - b.X) + (a.Y - b.Y) * (a.Y - b.Y));
        }
    }
}
