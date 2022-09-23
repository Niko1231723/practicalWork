using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BankConfirmations_DTO
{
    public class PaymentDetails
    {
        public int Id { get; set; }
        public string Merchant { get; set; }
        public string Description { get; set; }
        public string Trans_Id { get; set; }
        public string User_Id { get; set; }
        public Payment Payment { get; set; }
        public void GetXml() 
        {
            using (var stream = new FileStream("xmlPaymentDetails", FileMode.Create))
            {
                var xml = new XmlSerializer(typeof(PaymentDetails));
                xml.Serialize(stream, this);
            }
        }
    }
}
