using BankConfirmations_BLL;
using BankConfirmations_DAL;
using BankConfirmations_DTO;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Diagnostics;
using System.Xml;
using System.Xml.Serialization;
using BankConfirmations_DAL_EF;
using BankConfirmations_Interfaces;
using System.Text.Json;
using BankConfirmations_DAL_ADO;
using Newtonsoft.Json;
using System.Configuration;
using System.Net.Http.Json;
using System.Net.Http.Headers;
using System.Net;
using System.Text;



//--------BLL GetAllAccount------

//AccountBLL accountBll = new();
//List<Account> account = accountBll.GetAll();

//foreach (Account column in account)
//{
//    Console.WriteLine(column.ToString());
//}

//ClientBLL clientBll = new();
//List<Client> client = clientBll.GetAll();

//foreach (Client column in client)
//{
//    Console.WriteLine(column.ToString());
//}

//--------BLL GetByIdAccount------

//AccountBLL accountBll = new();
//Console.WriteLine("Enter account id to see the result:");
//int id = int.Parse(Console.ReadLine());

//Account account = accountBll.GetById(id);
//Console.WriteLine(account.ToString());

//--------BLL Insert/UpdateAccount------

//Account account = new();
//Console.WriteLine("Update account, please enter account id");
//account.Id = int.Parse(Console.ReadLine());
//Console.WriteLine("Enter account number");
//account.Number = Console.ReadLine();
//Console.WriteLine("Enter account balance");
//account.Balance = decimal.Parse(Console.ReadLine());
//Console.WriteLine("Enter account date open");
//account.OpenDate = DateTime.Parse(Console.ReadLine());
//Console.WriteLine("Enter account type");
//account.Type = Console.ReadLine();
//Console.WriteLine("Enter client id");
//account.ClientId = int.Parse(Console.ReadLine());

//AccountBLL accountBLLInsert = new();
//accountBLLInsert.Insert(account);

//AccountBLL accountBLLUpdate = new();
//accountBLLUpdate.Update(account);

//--------BLL DeleteAccount------

//AccountBLL accountBll = new();
//Console.WriteLine("Insert id you want to delete");
//int id = int.Parse(Console.ReadLine());
//accountBll.Delete(id);

//static string GetPath()
//{
//    string path = "appsettings.json";

//    using (FileStream fileStream = File.Open(path, FileMode.Open, FileAccess.Read))
//    {
//        byte[] bt = new byte[1024];
//        UTF8Encoding end = new(true);

//        while (fileStream.Read(bt, 0, bt.Length) > 0)
//        {
//            return end.GetString(bt);
//        }
//    }
//    return null;
//}

//dynamic json = JsonConvert.DeserializeObject(GetPath());

//string BaseAddress = (string)(json["HostAPI"]);

//Console.WriteLine(BaseAddress+"/"+"account");

ClientBLL clientBll = new();

var client = clientBll.GetAll();

string search = Console.ReadLine();

var filter = from s in client
             where s.FirstName == search
             select new {s.FirstName, s.LastName};
Console.WriteLine(filter.ToList());

//foreach (var item in filter)
//{
//    Console.WriteLine(item);
//}













