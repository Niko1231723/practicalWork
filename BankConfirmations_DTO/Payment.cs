using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BankConfirmations_DTO
{
    public class Payment
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime CurrencyDate { get; set; }
        public DateTime EntryDate { get; set; }
        public string Type { get; set; }

        [ForeignKey("PaymentDetailsId")]
        public int PaymentDetailsId { get; set; }
        public PaymentDetails PaymentDetails { get; set; }
        [XmlIgnore]
        public ICollection<Account> Account { get; set; }
        public void GetXml()
        {
            using (var stream = new FileStream("xmlPayment", FileMode.Create))
            {
                var xml = new XmlSerializer(typeof(Payment));
                xml.Serialize(stream, this);
            }
        }
    }
}
