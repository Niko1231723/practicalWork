using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;
using System.Collections;
using System.Text.Json.Serialization;
using System.Web.Mvc;

namespace BankConfirmations_DTO
{
    public class Account
    {
        public int Id { get; set; }
        [Required]
        [StringLength(10,MinimumLength =10)]
        public string Number { get; set; }
        [Required]
        public decimal Balance { get; set; }
        [Column("open_date")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime OpenDate { get; set; }
        [Required]
        public string Type { get; set; }
        [Column("client_id")]
        [Required]
        public int ClientId { get; set; }
        [ForeignKey("ClientId")]
        public Client Client { get; set; }
        [JsonIgnore]
        public AccountClosed AccountClosed { get; set; }
        [XmlIgnore]
        [JsonIgnore]
        public ICollection<Payment> Payment { get; set; }
        public void GetXml() 
        {
            using (var stream = new FileStream("xmlAccount",FileMode.Create))
            {
                var xml = new XmlSerializer(typeof(Account));
                xml.Serialize(stream,this);
            }
        }
        public override string ToString() => String.Format("number: {0}, balance: {1}, open date: {2}, type: {3}",Number,Balance,OpenDate,Type);
    }
    public enum AccountType 
    {
        domestic,
        foreign
    }
}
