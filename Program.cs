using System;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace CPU
{
    class Program
    {
        //C:\\Users\\danil\\Desktop\\CPU.TXT
        static void Main()
        {
            Process process = Process.Start("C:\\Program Files\\Google\\Chrome\\Application\\chrome.exe", "https://www.youtube.com/watch?v=EEKpuo3jH0E&ab_channel=HideakiUtsumi");
            PerformanceCounter cpuCounter = new("Process", "% Processor Time", process.ProcessName);

            double CPU1, CPU2;
            long RAM1, RAM2;
            int Handle;

            Console.WriteLine("Enter file path: ");
            string path = Console.ReadLine();
            Console.WriteLine("Enter time span: ");
            int time = Console.Read();
            StreamWriter sw = new(path);

            for(; ; )
            {
                CPU1 = Math.Round(cpuCounter.NextValue(), 1);
                Thread.Sleep(1000);
                CPU2 = Math.Round(cpuCounter.NextValue(), 1);
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