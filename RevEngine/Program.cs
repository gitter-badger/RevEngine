using System;
using Tao.OpenGl;
using Tao.FreeGlut;
using Tao.OpenAl;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections.Generic;
//OpenGL datatypes
using GLbitfield = System.UInt32;
using GLboolean = System.Boolean;
using GLbyte = System.SByte;
using GLclampf = System.Single;
using GLdouble = System.Double;
using GLenum = System.UInt32;
using GLfloat = System.Single;
using GLint = System.Int32;
using GLshort = System.Int16;
using GLsizei = System.Int32;
using GLubyte = System.Byte;
using GLuint = System.UInt32;
using GLushort = System.UInt16;
using GLvoid = System.IntPtr;
//DO NOT REMOVE

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
        static GLfloat rotqube = 0.0f;

        static void init_graphics()
        {
            Glut.glutFullScreen();
            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);
            float[] light_pos = new float[3] { 8, 8, 10F };
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, light_pos);
            float[] light_pos2 = new float[3] { -8F, -8F, 10F };
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_POSITION, light_pos2);
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glClearColor(0, 0, 0, 1);
        }

        static void on_display()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glLoadIdentity();
            Glu.gluLookAt(0, 0, 5, 0, 0, 1, 0, 5, 0);
            //Glut.glutSolidIcosahedron();
                //NEW//////////////////NEW//////////////////NEW//////////////////NEW/////////////
                Gl.glTranslatef(0.0f, 0.0f, -7.0f);    // Translate Into The Screen 7.0 Units
                Gl.glRotatef(rotqube, 0.0f, 1.0f, 0.0f);   // Rotate The cube around the Y axis
                Gl.glRotatef(rotqube, 1.0f, 1.0f, 3.0f);
                Gl.glBegin(Gl.GL_QUADS);      // Draw The Cube Using quads
                Gl.glColor3f(0.0f, 1.0f, 0.0f);    // Color Blue
                Gl.glVertex3f(1.0f, 1.0f, -1.0f);  // Top Right Of The Quad (Top)
                Gl.glVertex3f(-1.0f, 1.0f, -1.0f); // Top Left Of The Quad (Top)
                Gl.glVertex3f(-1.0f, 1.0f, 1.0f);  // Bottom Left Of The Quad (Top)
                Gl.glVertex3f(1.0f, 1.0f, 1.0f);   // Bottom Right Of The Quad (Top)
                Gl.glColor3f(1.0f, 0.5f, 0.0f);    // Color Orange
                Gl.glVertex3f(1.0f, -1.0f, 1.0f);  // Top Right Of The Quad (Bottom)
                Gl.glVertex3f(-1.0f, -1.0f, 1.0f); // Top Left Of The Quad (Bottom)
                Gl.glVertex3f(-1.0f, -1.0f, -1.0f);    // Bottom Left Of The Quad (Bottom)
                Gl.glVertex3f(1.0f, -1.0f, -1.0f); // Bottom Right Of The Quad (Bottom)
                Gl.glColor3f(1.0f, 0.0f, 0.0f);    // Color Red	
                Gl.glVertex3f(1.0f, 1.0f, 1.0f);   // Top Right Of The Quad (Front)
                Gl.glVertex3f(-1.0f, 1.0f, 1.0f);  // Top Left Of The Quad (Front)
                Gl.glVertex3f(-1.0f, -1.0f, 1.0f); // Bottom Left Of The Quad (Front)
                Gl.glVertex3f(1.0f, -1.0f, 1.0f);  // Bottom Right Of The Quad (Front)
                Gl.glColor3f(1.0f, 1.0f, 0.0f);    // Color Yellow
                Gl.glVertex3f(1.0f, -1.0f, -1.0f); // Top Right Of The Quad (Back)
                Gl.glVertex3f(-1.0f, -1.0f, -1.0f);    // Top Left Of The Quad (Back)
                Gl.glVertex3f(-1.0f, 1.0f, -1.0f); // Bottom Left Of The Quad (Back)
                Gl.glVertex3f(1.0f, 1.0f, -1.0f);  // Bottom Right Of The Quad (Back)
                Gl.glColor3f(0.0f, 0.0f, 1.0f);    // Color Blue
                Gl.glVertex3f(-1.0f, 1.0f, 1.0f);  // Top Right Of The Quad (Left)
                Gl.glVertex3f(-1.0f, 1.0f, -1.0f); // Top Left Of The Quad (Left)
                Gl.glVertex3f(-1.0f, -1.0f, -1.0f);    // Bottom Left Of The Quad (Left)
                Gl.glVertex3f(-1.0f, -1.0f, 1.0f); // Bottom Right Of The Quad (Left)
                Gl.glColor3f(1.0f, 0.0f, 1.0f);    // Color Violet
                Gl.glVertex3f(1.0f, 1.0f, -1.0f);  // Top Right Of The Quad (Right)
                Gl.glVertex3f(1.0f, 1.0f, 1.0f);   // Top Left Of The Quad (Right)
                Gl.glVertex3f(1.0f, -1.0f, 1.0f);  // Bottom Left Of The Quad (Right)
                Gl.glVertex3f(1.0f, -1.0f, -1.0f); // Bottom Right Of The Quad (Right)
                Gl.glEnd();            // End Drawing The Cube
                                       //NEW//////////////////NEW//////////////////NEW//////////////////NEW/////////////
                Glut.glutSwapBuffers();
            return;
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
            Console.WriteLine("Starting Key held reader");
            Glut.glutKeyboardFunc(keyfunc);
                Console.WriteLine("Starting Key Up Reader");
                Glut.glutKeyboardUpFunc(keyupfunc);
            Console.WriteLine("Starting Secret Special Key Reader");
            Glut.glutSpecialUpFunc(SpecialUpKonamiKeys);
            Console.WriteLine("Starting Idle Function");
            Glut.glutIdleFunc(Idle);
            Console.WriteLine("Entering Main Loop");
            Glut.glutMainLoopEvent();
                Glut.glutMainLoop();
        }

        private static void Idle()
        {
            if (konamicomplete)
            {
                List<string> myList = new List<string>();
                // add items to the list
                myList.Add("http://www.nyan.cat");
                myList.Add("http://www.nyan.cat/dub");
                myList.Add("http://www.nyan.cat/gb");
                myList.Add("http://www.nyan.cat/pikanyan");
                myList.Add("http://www.nyan.cat/404");
                myList.Add("http://www.nyan.cat/daft");
                myList.Add("http://www.nyan.cat/tacnayn");
                myList.Add("http://www.nyan.cat/daft");
                Random r = new Random();
                int index = r.Next(myList.Count);
                string randomString = myList[index];
                System.Diagnostics.Process.Start(randomString);
                konamicomplete = false;
                if (fullscreen)
                {
                    Glut.glutReshapeWindow(1080, 720);
                    fullscreen = false;
                }
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
        private static void keyfunc(byte key, int x, int y)
        {
            if (key == 'r')
            {
                rotqube += 8f;
                Glut.glutPostRedisplay();
                return;
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