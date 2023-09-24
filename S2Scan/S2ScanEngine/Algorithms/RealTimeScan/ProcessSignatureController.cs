using FireSharp.Response;
using Newtonsoft.Json;
using S2ScanEngine.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2ScanEngine.Algorithms.RealTimeScan
{
    public class ProcessSignatureController
    {
        S2ScanDbConnection conn = new S2ScanDbConnection();
        public List<ProcessModel> processSignatureList = new List<ProcessModel>();

        public ProcessSignatureController()
        {
            
        }

        public List<ProcessModel> LoadData()
        {
            try
            {
                FirebaseResponse al = conn.client.Get("processSignatures");
                List<ProcessModel> processSignatures = JsonConvert.DeserializeObject<List<ProcessModel>>(al.Body.ToString());
                return processSignatures;
            }
            catch (Exception)
            {
                Console.WriteLine("Encountered An Error Fetching Data");
                return null;
            }
        }
    }
}
