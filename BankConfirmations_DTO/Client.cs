using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace BankConfirmations_DTO
{
    public class Client 
    {
        [Column("id")]
        [Required]
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [StringLength(13,MinimumLength =13)]
        public string IdNumber { get; set; }
        [Column("clientDetails_Id")]
        [Required]
        public int ClientDetailsId { get; set; }
        [ForeignKey("ClientDetailsId")]
        public ClientDetails ClientDetails { get; set; }
        [XmlIgnore]
        [JsonIgnore]
        public ICollection<Account> Account { get; set; }
        [XmlIgnore]
        [JsonIgnore]
        public ICollection<Credit> Credit { get; set; }
        [XmlIgnore]
        [JsonIgnore]
        public ICollection<CreditCard> CreditCard { get; set; }
        [XmlIgnore]
        [JsonIgnore]
        public ICollection<Deposit> Deposit { get; set; }
        [XmlIgnore]
        [JsonIgnore]
        public ICollection<OverDraft> OverDraft { get; set; }
        public void GetXml() 
        {
            using (var stream = new FileStream("xmlClient",FileMode.Create))
            {
                var xml = new XmlSerializer(typeof(Client));
                xml.Serialize(stream,this);
            }
        }
        public override string ToString() => String.Format("first name: {0}, last name: {1}, id number: {2}", FirstName, LastName,IdNumber);
    }
}