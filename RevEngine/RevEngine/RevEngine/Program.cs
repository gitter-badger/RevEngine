using System;
using System.Windows;
using OpenGL4NET;
using System.Windows.Forms;

namespace RevEngine
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            Program engine = new Program();
            engine.Init();
            */
            Console.WriteLine("Hello world!");
            Console.Beep();
            //Lets get started!!

        }
        void Init()
        {
            Form window = new Form();
            RenderingContext rc = RenderingContext.CreateContext(window);
            window.Show();
            //this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }
    }
}
