using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2
{
    class TCircle
    {
        private double _R;

        public double R
        {
            get { return _R; }
            set
            {
                if (value > 0) _R = value;

            }
        }
        private double _S;

        public double S
        {
            get { return _S; }
            set
            {
                if (value > 0) _S = value;

            }
        }
        private double _L;

        public double L
        {
            get { return _L; }
            set
            {
                if (value > 0) _L = value;

            }
        }
        public TCircle()
        {
            this.R = 1;
            this.S = Square();
            this.L = Length();
            Print();
        }
        public TCircle(double r)
        {
            this.R = r;
            this.S = Square();
            this.L = Length();
            Print();
        }
        public TCircle(TCircle c)
        {
            this.R = c.R;
            this.S = Square();
            this.L = Length();
            Print();
        }

        protected double Square()
        {
            return Math.PI * Math.Pow(R, 2);
        }
        protected double Length()
        {
            return 2 * Math.PI * R;
        }

        public static TCircle operator +(TCircle c, double x) 
        {
            return new TCircle(c.R + x);
        }
        public static TCircle operator -(TCircle c, double x)
        {
            return new TCircle(c.R - x);
        }
        public static TCircle operator *(TCircle c, double x)
        {
            return new TCircle(c.R * x);
        }

        protected void Print()
        {
            Console.WriteLine("Radius:" + R);
            Console.WriteLine("Square:" + S);
            Console.WriteLine("Length:" + L);
        }
    }
    class TCone : TCircle
    {
        private double _H;

        public double H
        {
            get { return _H; }
            set
            {
                if (value > 0) _H = value;

            }
        }
        private double _V;

        public double V
        {
            get { return _V; }
            set
            {
                if (value > 0) _V = value;

            }
        }

        public TCone(double H)
        {
            IsHeight(H);
            this.H = H;
            this.V = Volume();
            this.L = Length();
            this.S = Square();
            Print();

        }

        public TCone(double R, double H) : base(R)
        {
            IsHeight(H);
            this.R = R;
            this.H = H;
            this.V = Volume();
            this.L = Length();
            this.S = Square();
            Print();
        }
        public TCone()
        {
            this.H = 10;
            this.V = Volume();
            this.L = Length();
            this.S = Square();
            Print();
        }

        private double Volume()
        {
            return 1 / 3 *base.S * H;
        }
        private new double Square()
        {
            return base.Square()+Math.PI*this.R*Math.Sqrt(this.R*this.R+this.H*this.H);
        }
        private new double Length()
        {
            return 2 * Math.PI * R;
        }
        private static void IsHeight(double H)
        {
            if (H <= 0)
                throw new Exception("Height can't be negative or equal 0!");
        }
        private new void Print()
        {
            Console.WriteLine("H = " + this.H);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                TCircle circle = new TCircle();
                Console.WriteLine();
                circle += 7;
                Console.WriteLine();
                circle *= 2;
                Console.WriteLine();
                circle -= 7;
                Console.WriteLine();
                TCone cone = new TCone(3);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
