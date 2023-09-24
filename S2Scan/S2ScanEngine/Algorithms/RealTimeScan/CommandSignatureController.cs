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
    public class CommandSignatureController
    {
        S2ScanDbConnection conn = new S2ScanDbConnection();
        public List<CommandModel> commandSignatureList = new List<CommandModel>();

        public CommandSignatureController()
        {
            commandSignatureList = LoadData();
        }


        // return known command signatures
        public List<CommandModel> LoadData()
        {
            try
            {
                FirebaseResponse al = conn.client.Get("commandSignatures");
                List<CommandModel> commandSignatures = JsonConvert.DeserializeObject<List<CommandModel>>(al.Body.ToString());
                return commandSignatures;
            }
            catch (Exception)
            {
                Console.WriteLine("Encountered An Error Fetching Data");
                return null;
            }
        }
    }
}
