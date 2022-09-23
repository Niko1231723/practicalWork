using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BankConfirmations_DTO
{
    public class ProductDetails
    {
        public int Id { get; set; }
        public string Agreement { get; set; }
        public decimal Amount { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime ClosureDate { get; set; }
        public string Type { get; set; }
        public Credit Credit { get; set; }
        public CreditCard CreditCard { get; set; }
        public Deposit Deposit { get; set; }
        public OverDraft OverDraft { get; set; }
        public void GetXml()
        {
            using (var stream = new FileStream("xmlProductDetails", FileMode.Create))
            {
                var xml = new XmlSerializer(typeof(ProductDetails));
                xml.Serialize(stream, this);
            }
        }
    }
}
