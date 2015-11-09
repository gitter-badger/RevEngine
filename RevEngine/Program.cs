using System;
using Tao.OpenGl;
using Tao.FreeGlut;

namespace RevEngine
{
    class Program
    {
        static void init_graphics()
        {
            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);
            float[] light_pos = new float[3] { 1, 0.5F, 1 };
            Gl.glLightfv(Gl.GL_LIGHT0, Gl.GL_POSITION, light_pos);
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glClearColor(1, 1, 1, 1);
        }

        static void on_display()
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);
            Gl.glLoadIdentity();
            Glu.gluLookAt(0, 0, 5, 0, 0, 1, 0, 1, 0);
            Glut.glutSolidTeapot(1);
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
            Console.WriteLine("I am the console! i love bacon and boobies! ghehehe");
            Console.WriteLine("initializing...");
            Glut.glutInit();
            Console.WriteLine("setting window size...");
            Glut.glutInitWindowSize(1080, 720);
            Console.WriteLine("creating window...");
            Glut.glutCreateWindow("RevEngine TEST PHASE");
            Console.WriteLine("initializing graphics...");
            init_graphics();
            Console.WriteLine("displaying stuff...");
            Glut.glutDisplayFunc(on_display);
            Console.WriteLine("reshaping stuff...");
            Glut.glutReshapeFunc(on_reshape);
            Console.WriteLine("entering main loop...");
            Glut.glutMainLoop();
        }
    }
}