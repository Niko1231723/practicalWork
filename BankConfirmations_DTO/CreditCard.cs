using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BankConfirmations_DTO
{
    public class CreditCard
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public decimal Debt { get; set; }
        [ForeignKey("ClientId")]
        public int ClientId { get; set; }
        [ForeignKey("ProductDetailsId")]
        public int ProductDetailsId { get; set; }
        public ProductDetails ProductDetails { get; set; }
        public void GetXml() 
        {
            using (var stream = new FileStream("xmlCreditCard",FileMode.Create))
            {
                var xml = new XmlSerializer(typeof(CreditCard));
                xml.Serialize(stream,this);
            }
        }
    }
}
