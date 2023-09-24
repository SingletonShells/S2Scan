using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace S2ScanEngine.Algorithms.RealTimeScan
{
    public class CommandMonitor
    {
        private static DateTime lastCheckTime = DateTime.MinValue;

        public event EventHandler<string> CommandExecuted;

        public void StartMonitoring()
        {
            while (true)
            {
                var processes = Process.GetProcesses();
                foreach (var process in processes)
                {
                    try
                    {
                        var createTime = process.StartTime;
                        if (createTime > lastCheckTime)
                        {
                            lastCheckTime = createTime;
                            string commandLine = GetCommandLine(process);
                            OnCommandExecuted(commandLine);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }
                }

                // Adjust the interval as needed (e.g., every second).
                Thread.Sleep(1000);
            }
        }

        private string GetCommandLine(Process process)
        {
            try
            {
                string commandLine = process.GetCommandLine();
                return commandLine;
            }
            catch
            {
                // Handle exceptions when accessing command line.
                return "Unavailable";
            }
        }

        protected virtual void OnCommandExecuted(string commandLine)
        {
            CommandExecuted?.Invoke(this, commandLine);
        }
    }

    public static class ProcessExtensions
    {
        public static string GetCommandLine(this Process process)
        {
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT CommandLine FROM Win32_Process WHERE ProcessId = " + process.Id))
            using (ManagementObjectCollection objects = searcher.Get())
            {
                return objects.Cast<ManagementBaseObject>().SingleOrDefault()?["CommandLine"]?.ToString();
            }
        }
    }
}
