using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BankConfirmations_DTO
{
    public class Credit
    {
        public int Id { get; set; }
        public string CreditNumber { get; set; }
        public string PaymentNumber { get; set; }
        public decimal Debt { get; set; }
        public decimal Fee { get; set; }

        [ForeignKey("ClientId")]
        public int ClientId { get; set; }

        [ForeignKey("ProductDetailsId")]
        public int ProductDetailsId { get; set; }
        public ProductDetails ProductDetails { get; set; }
        public void GetXml() 
        {
            using (var stream = new FileStream("xmlCredit",FileMode.Create))
            {
                var xml = new XmlSerializer(typeof(Credit));
                xml.Serialize(stream,this);
            }
        }
    }
}
