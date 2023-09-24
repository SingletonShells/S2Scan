using S2ScanEngine.Algorithms.RealTimeScan;
using S2ScanEngine.Scans;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace S2ScanEngine
{
    public class EngineController
    {
        private readonly Scan _scan;
        private readonly ProcessMonitor _processMonitor;
        private readonly CommandMonitor _commandMonitor;

        public EngineController()
        {
            _scan = new Scan();
            _processMonitor = new ProcessMonitor();
            _commandMonitor = new CommandMonitor();

            _commandMonitor.CommandExecuted += (sender, commandLine) =>
            {
                // Call your custom method here.
            };
        }


        // Turn on real time protection (Default)
        public void turnOnRealTimeProtection()
        {
            _processMonitor.ProcessStarted += ProcessMonitor_ProcessStarted;
            _commandMonitor.StartMonitoring();
        }


        //Turn off real time protection (Not Recomomended)
        public void turnOffRealTimeProtection()
        {
            _processMonitor.StopMonitoring();
        }

        // Perform Action When A New Process Is Started
        private static void ProcessMonitor_ProcessStarted(object sender, string processName)
        {
            // You can perform any action you want here when a new process is started.
        }


        // Start Scans
        public void scanPc(string typeOfScan)
        {
            // Evaluate What Type Of Scan User Wants To Perform
            if (typeOfScan == "Full")
            {
                _scan.FullScan(@"C:\");
            }
            else
            {

            }
        }
    }
}
