using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BankConfirmations_DTO
{
    public class AccountClosed
    {
        public int Id { get; set; }
        [Column("closure_date")]
        public DateTime ClosureDate { get; set; }
        [Column("account_id")]
        public int AccountId { get; set; }
        [ForeignKey("AccountId")]
        public Account Account { get; set; }
        public void GetXml() 
        {
            using (var stream = new FileStream("xmlAccountClosed",FileMode.Create))
            {
                var xml = new XmlSerializer(typeof(AccountClosed));
                xml.Serialize(stream, this);
            }
        }
    }
}
