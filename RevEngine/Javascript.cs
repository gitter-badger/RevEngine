using System;
using System.IO;
using System.Text;
using Jint;

namespace RevEngine
{
    class Javascript
    {
       public void loop()
        {
            string loopscript = File.ReadAllText("scripts/loop.js");
            Jint.Engine jsint = new Jint.Engine();
            jsint.SetValue("debuglog", new Action<object>(Console.WriteLine));
            jsint.Execute(loopscript);
        }
    }
}
