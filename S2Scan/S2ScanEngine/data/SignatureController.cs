using FireSharp.Response;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2ScanEngine.data
{
    public class SignatureController
    {
        S2ScanDbConnection conn = new S2ScanDbConnection();

        //Add Signatures To Online DB
        public void SetData(string Name, string Surname, int age)
        {
            try
            {
                SignatureModel set = new SignatureModel()
                {
                    //Name = Name,
                    //Surname = Surname,
                    //age = age
                };
                var SetData = conn.client.Set("signature/" + Name, set);
            }
            catch (Exception)
            {
                Console.WriteLine("Encountered Error Adding New Signature");
            }

        }

        //Update Signatures From Online DB
        public void UpdateData(string Name, string Surname, int age)
        {
            try
            {
                SignatureModel set = new SignatureModel()
                {
                    //Name = Name,
                    //Surname = Surname,
                   // age = age
                };
                var SetData = conn.client.Update("signature/" + Name, set); ;
            }
            catch (Exception)
            {
                Console.WriteLine("Encountered Error Trying To Update Signature");
            }
        }


        //Get All Signatures From Online DB
        public List<SignatureModel> LoadData()
        {
            try
            {
                FirebaseResponse al = conn.client.Get("signature");
                List<SignatureModel> dataSugnatures = JsonConvert.DeserializeObject<List<SignatureModel>>(al.Body.ToString());
                return dataSugnatures;
            }
            catch (Exception)
            {
                Console.WriteLine("Encountered An Error Fetching Data");
                return null;
            }
        }
    }
}
