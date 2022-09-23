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
    public class ClientDetails
    {
        public int Id { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [JsonIgnore]
        public Client Client { get; set; }
        public void GetXml() 
        {
            using (var stream = new FileStream("xmlClientDetails",FileMode.Create))
            {
                var xml = new XmlSerializer(typeof(ClientDetails));
                xml.Serialize(stream, this);
            }
        }
        public override string ToString()
        {
            return String.Format("City: {0}, Address: {1}, Date: {2}, Client: {3}", Client, Address, Date, Client);
        }
    }
}
