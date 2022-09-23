using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConfirmations_DAL
{
    public class Connections
    {
        protected dynamic json = JsonConvert.DeserializeObject(File.ReadAllText(@"C:\Users\DELL\Documents\NEW\IT\Ognjen Radovic\C#\BankConfirmations\BankConfirmations_UI_MVC\appsettings.json"));

        protected string ConString = @"Server=(localdb)\ProjectsV13; Database=BankConfirmations; Trusted_Connection=true; MultipleActiveResultSets=true";
    }
}
