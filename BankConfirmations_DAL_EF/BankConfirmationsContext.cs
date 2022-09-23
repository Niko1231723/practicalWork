using BankConfirmations_DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Text;

namespace BankConfirmations_DAL_EF
{
    public class BankConfirmationsContext : DbContext
    {
        private static string GetPath()
        {
            string path = "appsettings.json";

            using (FileStream fileStream = File.Open(path, FileMode.Open, FileAccess.Read))
            {
                byte[] bt = new byte[1024];
                UTF8Encoding end = new(true);

                while (fileStream.Read(bt, 0, bt.Length) > 0)
                {
                    return end.GetString(bt);
                }
            }
            return null;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            dynamic json = JsonConvert.DeserializeObject(GetPath());
            builder.UseSqlServer((string)json["ConnectionStrings"]["SqlConnection"]);
        }
        public virtual DbSet<Account> Account { get; set; }
        public virtual DbSet<AccountClosed> AccountClosed { get; set; }
        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<ClientDetails> ClientDetails { get; set; }
        public virtual DbSet<Credit> Credit { get; set; }
        public virtual DbSet<CreditCard> CreditCard { get; set; }
        public virtual DbSet<Deposit> Deposit { get; set; }
        public virtual DbSet<OverDraft> OverDraft { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<PaymentDetails> PaymentDetails { get; set; }
        public virtual DbSet<ProductDetails> ProductDetails { get; set; }
        protected override void  OnModelCreating(ModelBuilder modelbuilder) 
        {
            modelbuilder.Entity<Client>().Property("FirstName").HasColumnName("first_name");
            modelbuilder.Entity<Client>().Property("LastName").HasColumnName("last_name");
            modelbuilder.Entity<Client>().Property("IdNumber").HasColumnName("id_number");
            modelbuilder.Entity<Client>().Property("ClientDetailsId").HasColumnName("clientDetails_id");
            modelbuilder.Entity<ClientDetails>().Property(i=>i.Date).HasColumnType("date");
        }
    }
}