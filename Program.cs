using System;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace CPU
{
    class Program
    {
        //C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe
        static void Main()
        {
            Console.WriteLine("enter process path: ");
            string path = Console.ReadLine();
            Process process = Process.Start(path);
            PerformanceCounter cpuCounter = new("Process", "% Processor Time", process.ProcessName);

            double CPU1, CPU2;
            long RAM1, RAM2;
            int Handle;

            Console.WriteLine("Enter period: ");
            int time = Console.Read();
            StreamWriter sw = new("C:\\Users\\danil\\Desktop\\CPU.TXT");

            for(; ; )
            {
                CPU1 = Math.Round(cpuCounter.NextValue(), 2);
                Thread.Sleep(1000);
                CPU2 = Math.Round(cpuCounter.NextValue(), 2);
                RAM1 = process.WorkingSet64;
                RAM2 = process.PrivateMemorySize64;
                Handle = process.HandleCount;
                Console.WriteLine("\n" + "CPU: " + CPU2+ "\n" +
                    "WorkingSet: " + RAM1 + "\n" +
                    "MemorySize: " + RAM2 + "\n" +
                    "HandleCount: " + Handle);
                sw.WriteLine(CPU2 + ";" + RAM1 + ";" + RAM2 + ";" + Handle + ";");
                Thread.Sleep(time);
            }
        }
    }
}