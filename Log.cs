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
        public static void WriteLog(string command,string message, string file = null)
        {
            using (StreamWriter w = File.AppendText(file ?? "log.txt"))
            {
                Logw(command, message, w);
               
            }

           
        }

        public static void SimpleWriteLog(string message, string file = null)
        {
            using (StreamWriter w = File.AppendText(file ?? "log.txt"))
            {
                SimpleLogw(message, w);

            }


        }

        private static void SimpleLogw(string message, StreamWriter w)
        {
            w.Write(message + ',');
        }

        public static string dumpLine(string file = null)
        {
            using (StreamReader r = File.OpenText(file ?? "log.txt"))
            {
                return DumpLog(r);
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



        public static string DumpLog(StreamReader r)
        {
            string line;
            while ((line = r.ReadLine()) != null)
            {
                return line;
            }
            return null;
        }
    }
}
