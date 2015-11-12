using System;
using Tao.OpenGl;
using Tao.FreeGlut;
using Tao.OpenAl;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace RevEngine
{

    class Program
    {
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        public static string status;
        public static bool boot = false;
        public static bool fullscreen = true;

        //bools for konami code
        static bool up1konami = true;
        static bool up2konami = false;
        static bool down1konami = false;
        static bool down2konami = false;
        static bool left1konami = false;
        static bool right1konami = false;
        static bool left2konami = false;
        static bool right2konami = false;
        static bool bkonami = false;
        static bool akonami = false;
        static bool konamicomplete = false;
        // end of bools for konami code

        static void init_graphics()
        {
            Glut.glutFullScreen();
            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);
            float[] light_pos = new float[3] { 0, 1, 3F };
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, light_pos);
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glClearColor(0, 0, 0, 1);
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
            var currentProcess = System.Diagnostics.Process.GetCurrentProcess();
            IntPtr hWnd = currentProcess.MainWindowHandle;//FindWindow(null, "Your console windows caption"); //put your console window caption here
            ShowWindow(hWnd, 0); // 0 = SW_HIDE
            Console.Title = "Rev Debugging Console" + status;
                Form Form1 = new Form1();
            
                Application.Run(Form1);
            ShowWindow(hWnd, 3); // 0 = SW_HIDE
            
            Console.WriteLine(@"  _____            ______             _            ");
                Console.WriteLine(@" |  __ \          |  ____|           (_)           ");
                Console.WriteLine(@" | |__) |_____   _| |__   _ __   __ _ _ _ __   ___ ");
                Console.WriteLine(@" |  _  // _ \ \ / /  __| | '_ \ / _` | | '_ \ / _ \");
                Console.WriteLine(@" | | \ \  __/\ V /| |____| | | | (_| | | | | |  __/");
                Console.WriteLine(@" |_|  \_\___| \_/ |______|_| |_|\__, |_|_| |_|\___|");
                Console.WriteLine(@"                                 __/ |             ");
                Console.WriteLine(@"                                |___/              ");
                Console.WriteLine(@"                          RevEngine (debug version)");
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
                Glut.glutKeyboardUpFunc(keyupfunc);
            Console.WriteLine("Starting Secret Special Key Reader");
            Glut.glutSpecialUpFunc(SpecialUpKonamiKeys);
            Console.WriteLine("Starting Idle Loop");
            Glut.glutIdleFunc(Loop);
                Console.WriteLine("Entering Main Loop");
                Glut.glutMainLoop();

        }

        private static void Loop()
        {
            if (konamicomplete)
            {
                System.Diagnostics.Process.Start("http://www.nyan.cat");
                konamicomplete = false;
            }
        }

        private static void SpecialUpKonamiKeys(int key, int x, int y)
        {
            switch (key)
            {
                case 100:
                    //LEFT
                    Console.WriteLine("Left button pressed");
                    if (!left1konami && !left2konami)
                    {
                        up1konami = true;
                        up2konami = false;
                        down1konami = false;
                        down2konami = false;
                        left1konami = false;
                        right1konami = false;
                        left2konami = false;
                        right2konami = false;
                        bkonami = false;
                        akonami = false;
                        break;
                    }
                    if (left1konami && !left2konami)
                    {
                        left1konami = false;
                        right1konami = true;
                        break;
                    }
                    if (left2konami && !left1konami)
                    {
                        left2konami = false;
                        right2konami = true;
                        break;
                    }

                    break;
                case 102:
                    //RIGHT
                    Console.WriteLine("Right button pressed");
                    if (!right1konami && !right2konami)
                    {
                        up1konami = true;
                        up2konami = false;
                        down1konami = false;
                        down2konami = false;
                        left1konami = false;
                        right1konami = false;
                        left2konami = false;
                        right2konami = false;
                        bkonami = false;
                        akonami = false;
                        break;
                    }
                    if (right1konami && !right2konami)
                    {
                        right1konami = false;
                        left2konami = true;
                        break;
                    }
                    if (right2konami && !right1konami)
                    {
                        right2konami = false;
                        bkonami = true;
                        break;
                    }
                    break;
                case 101:
                    //UP
                    Console.WriteLine("Up button pressed");
                    if(!up1konami && !up2konami)
                    {
                        up1konami = true;
                        up2konami = false;
                        down1konami = false;
                        down2konami = false;
                        left1konami = false;
                        right1konami = false;
                        left2konami = false;
                        right2konami = false;
                        bkonami = false;
                        akonami = false;
                        break;
                    }
                    if (up1konami && !up2konami)
                    {
                        up1konami = false;
                        up2konami = true;
                        break;
                    }
                    if (up2konami && !up1konami)
                    {
                        up2konami = false;
                        down1konami = true;
                        break;
                    }
                    break;
                case 103:
                    //DOWN
                    Console.WriteLine("Down button pressed");
                    if (!down1konami && !down2konami)
                    {
                        up1konami = true;
                        up2konami = false;
                        down1konami = false;
                        down2konami = false;
                        left1konami = false;
                        right1konami = false;
                        left2konami = false;
                        right2konami = false;
                        bkonami = false;
                        akonami = false;
                        break;
                    }
                    if (down1konami && !down2konami)
                    {
                        down1konami = false;
                        down2konami = true;
                        break;
                    }
                    if (down2konami && !down1konami)
                    {
                        down2konami = false;
                        left1konami = true;
                        break;
                    }
                    break;
            }
        }

        private static void keyupfunc(byte key, int x, int y)
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
            if (key == 'b')
            {
                Console.WriteLine("B button pressed");
                if (!bkonami)
                {
                    up1konami = true;
                    up2konami = false;
                    down1konami = false;
                    down2konami = false;
                    left1konami = false;
                    right1konami = false;
                    left2konami = false;
                    right2konami = false;
                    bkonami = false;
                    akonami = false;
                }
                if (bkonami)
                {
                    bkonami = false;
                    akonami = true;
                }
            }
            if (key == 'a')
            {
                Console.WriteLine("A button pressed");
                if (!akonami)
                {
                    up1konami = true;
                    up2konami = false;
                    down1konami = false;
                    down2konami = false;
                    left1konami = false;
                    right1konami = false;
                    left2konami = false;
                    right2konami = false;
                    bkonami = false;
                    akonami = false;
                }
                if (akonami)
                {
                    akonami = false;
                    konamicomplete = true;
                    up1konami = true;
                    Console.WriteLine("thats the konami code!");
                }
            }
        }
    }
}