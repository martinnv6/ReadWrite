using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace NationalInstruments.Examples.SimpleReadWrite
{
    public static class Log
    {
        public static void WriteLog(string command,string message)
        {
            using (StreamWriter w = File.AppendText("log.txt"))
            {
                Logw(command, message, w);
               
            }

           
        }

        public static void dumpLine()
        {
            using (StreamReader r = File.OpenText("log.txt"))
            {
                DumpLog(r);
            }
        }

        public static void Logw(string command, string logMessage, TextWriter w)
        {
            w.Write("\r\nEntrada de Log : ");
            w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                DateTime.Now.ToLongDateString());
            w.WriteLine("  :");
            w.WriteLine("  :Commando ejecutado -> {0}", command);
            w.WriteLine("  :{0}", logMessage);
            w.WriteLine("-------------------------------");
        }

        public static void DumpLog(StreamReader r)
        {
            string line;
            while ((line = r.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }
    }
}
