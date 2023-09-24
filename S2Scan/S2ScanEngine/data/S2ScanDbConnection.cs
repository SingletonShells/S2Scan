using FireSharp.Config;
using FireSharp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2ScanEngine.data
{
    public class S2ScanDbConnection
    {
        //Firebase Connection Settings
        public IFirebaseConfig firebaseConfig = new FirebaseConfig()
        {
            AuthSecret = "pycvx92rQVGtOrTs76VEifGwE0qi4CifiUXIy2Tm",
            BasePath = "https://s2scan-default-rtdb.firebaseio.com/"
        };

        public IFirebaseClient client;

        // Try Connecting
        public S2ScanDbConnection()
        {
            try
            {
                client = new FireSharp.FirebaseClient(firebaseConfig);
            }
            catch (Exception)
            {
                Console.WriteLine("Error Occured While Connecting");
            }
        }
    }
}
