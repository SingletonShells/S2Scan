using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2ScanEngine.Scans
{

    public class Scan
    {

        // Scan All Files in PC
        public void FullScan(string directoryPath)
        {
            try
            {
                // Check if the directory exists
                if (!Directory.Exists(directoryPath))
                {
                    Console.WriteLine("Directory does not exist.");
                    return;
                }

                // Scan all files in the directory and its subdirectories
                ScanFilesInPath(directoryPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }


        // Scans Directories Selected By User
        public void userDefinedScan(string[] arrPath)
        {
            foreach (string path in arrPath)
            {
                try
                {
                    // Check if the directory exists
                    if (!Directory.Exists(path))
                    {
                        Console.WriteLine("Directory does not exist.");
                        return;
                    }

                    // Scan all files in the directory and its subdirectories
                    ScanFilesInPath(path);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
            
        }


        // Go Through Files In A Specific Directory
        private void ScanFilesInPath(string directoryPath)
        {
            try
            {
                // Scan all files in the current directory
                string[] files = Directory.GetFiles(directoryPath);
                foreach (string file in files)
                {
                    Console.WriteLine($"Found file: {file}");
                }

                // Recursively scan subdirectories
                string[] subDirectories = Directory.GetDirectories(directoryPath);
                foreach (string subDirectory in subDirectories)
                {
                    ScanFilesInPath(subDirectory);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
