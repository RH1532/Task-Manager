using System;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace CPU
{
	class Program
	{
        public static dynamic GetCPU()
		{
            PerformanceCounter cpuCounter = new("Process", "% Processor Time", Process.GetCurrentProcess().ProcessName);
            dynamic firstValue = cpuCounter.NextValue();
			Thread.Sleep(1000);
            dynamic secondValue = cpuCounter.NextValue();
            return secondValue;
		}
        public static dynamic GetWorkingSet()
        {
			Process process = Process.GetCurrentProcess();
			long Value = process.WorkingSet64;
            return Value;
        }
        public static dynamic GetMemorySize()
        {
			Process process = Process.GetCurrentProcess();
			long Value = process.PrivateMemorySize64;
            return Value;
        }
        public static dynamic GetHandle()
		{
			Process process = Process.GetCurrentProcess();
			int Value = process.HandleCount;
            return Value;
        }
        static void Main() //C:\\Users\\danil\\Desktop\\CPU.TXT
        {
            Console.WriteLine("Enter file path: ");
            string path = Console.ReadLine();
            Console.WriteLine("Enter time span: ");
            int time = Console.Read();
            StreamWriter sw = new(path);
            ConsoleKeyInfo key;
            do
            {
                int CPU = (int)GetCPU();
                long RAM1 = GetWorkingSet();
                long RAM2 = GetMemorySize();
                int Handle = GetHandle();
                Console.WriteLine("\n" + "CPU: " + CPU + "\n" +
                    "WorkingSet: " + RAM1 + "\n" +
                    "MemorySize: " + RAM2 + "\n" +
                    "HandleCount: " + Handle);
                sw.WriteLine(CPU + "; " + RAM1 + "; " + RAM2 + "; " + Handle + ";");
                Thread.Sleep(time);
                key = Console.ReadKey();
            } while (key.Key != ConsoleKey.Escape);
            sw.Close();
        }
    }
}