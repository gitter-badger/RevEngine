using System;
using Tao.OpenGl;
using Tao.FreeGlut;
using System.Windows.Forms;
using System.Threading;

namespace RevEngine
{
    class Program
    {
        public static bool boot = false;
        public static bool fullscreen = false;
        static void init_graphics()
        {
            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);
            float[] light_pos = new float[3] { 0, 1, 3F };
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, light_pos);
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glClearColor(0, 0, 0, 0);
        }

        static void on_display()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glLoadIdentity();
            Glu.gluLookAt(0, 0, 5, 0, 0, 1, 0, 5, 0);
            Glut.glutSolidIcosahedron();
            
            Glut.glutSwapBuffers();
        }

        static void on_reshape(int w, int h)
        {
            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            Gl.glViewport(0, 0, w, h);
            Glu.gluPerspective(40, (35*w) / (20*h), 1, 100);
            Gl.glMatrixMode(Gl.GL_MODELVIEW);
        }

        static void Main()
        {

                Form Form1 = new Form1();
                Application.Run(Form1);
            Console.WriteLine(@"  _____            ______             _            ");
                Console.WriteLine(@" |  __ \          |  ____|           (_)           ");
                Console.WriteLine(@" | |__) |_____   _| |__   _ __   __ _ _ _ __   ___ ");
                Console.WriteLine(@" |  _  // _ \ \ / /  __| | '_ \ / _` | | '_ \ / _ \");
                Console.WriteLine(@" | | \ \  __/\ V /| |____| | | | (_| | | | | |  __/");
                Console.WriteLine(@" |_|  \_\___| \_/ |______|_| |_|\__, |_|_| |_|\___|");
                Console.WriteLine(@"                                 __/ |             ");
                Console.WriteLine(@"                                |___/              ");
                Console.WriteLine(@"             RevEngine (debug version) by Naamloos!");
                Console.WriteLine(@" ");
                Console.WriteLine(@" ");
                Console.WriteLine("Initializing GLUT");
                Glut.glutInit();
                Console.WriteLine("Setting Window Size");
                Glut.glutInitWindowSize(1080, 720);
                Console.WriteLine("Creating Window");
                Glut.glutCreateWindow("Rev");
                Console.WriteLine("Initializing Graphics");
                init_graphics();
                Console.WriteLine("Rendering Screen");
                Glut.glutDisplayFunc(on_display);
                Console.WriteLine("Setting Perspective etc");
                Glut.glutReshapeFunc(on_reshape);
                Console.WriteLine("Starting Key Reader");
                Glut.glutKeyboardFunc(keyfunc);
                Console.WriteLine("Entering Main Loop");
                Glut.glutMainLoop();

        }

        private static void keyfunc(byte key, int x, int y)
        {
            // press space to exit!
            if (key == 'q')
            {
                Console.WriteLine("Stopping Program");
                Environment.Exit(0);
            }
            if (key == 'f')
            {
                if (!fullscreen)
                {
                    Glut.glutFullScreen();
                    fullscreen = true;
                }
                if (fullscreen)
                {
                    Glut.glutReshapeWindow(1080, 720);
                    fullscreen = false;
                }
            }
        }
    }
}