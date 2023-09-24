using System;
using System.Collections.Generic;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;

namespace S2ScanEngine.Algorithms.RealTimeScan
{
    // Monitor processes in task Manager
    public class ProcessMonitor
    {
        private ManagementEventWatcher processStartWatcher;

        public event EventHandler<string> ProcessStarted;

        public ProcessMonitor()
        {
            // Create a WMI event query to monitor process creation events
            var query = new WqlEventQuery("SELECT * FROM Win32_ProcessStartTrace");

            // Initialize processStartWatcher
            processStartWatcher = new ManagementEventWatcher(query);
            processStartWatcher.EventArrived += ProcessStartWatcher_EventArrived;

            // Start monitoring
            processStartWatcher.Start();
        }

        private void ProcessStartWatcher_EventArrived(object sender, EventArrivedEventArgs e)
        {
            // Get the process name and send it as an event
            string processName = e.NewEvent.Properties["ProcessName"].Value.ToString();
            OnProcessStarted(processName);
        }

        protected virtual void OnProcessStarted(string processName)
        {
            ProcessStarted?.Invoke(this, processName);
        }

        public void StopMonitoring()
        {
            // Stop monitoring and release resources
            if (processStartWatcher != null)
            {
                processStartWatcher.Stop();
                processStartWatcher.Dispose();
                processStartWatcher = null;
            }
        }
    }
}
