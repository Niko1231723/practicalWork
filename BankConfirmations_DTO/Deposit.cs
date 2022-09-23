using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BankConfirmations_DTO
{
    public class Deposit 
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public decimal Balance { get; set; }
        public decimal Interest { get; set; }
        [Column("client_id")]
        [ForeignKey("ClientId")]
        public int ClientId { get; set; }
        [Column("details_id")]
        public int ProductDetailsId { get; set; }
        [ForeignKey("ProductDetailsId")]
        [JsonIgnore]
        public ProductDetails ProductDetails { get; set; }
        public void GetXml() 
        {
            using (var stream = new FileStream("xmlDeposit", FileMode.Create))
            {
                var xml = new XmlSerializer(typeof(Deposit));
                xml.Serialize(stream, this);
            }
        }
        public override string ToString()
        {
            return String.Format("Number: {0}, Balance: {1}, Interest: {2}",Number,Balance,Interest);
        }
    }
}
