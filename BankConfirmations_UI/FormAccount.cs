using BankConfirmations_BLL;
using BankConfirmations_DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankConfirmations_UI
{
    public partial class FormAccount : Form
    {
        public FormAccount()
        {
            InitializeComponent();
        }

        private void btnListAccount_Click(object sender, EventArgs e)
        {
            AccountBLL accountBll = new();

            dataGridViewAccount.DataSource = accountBll.GetAll().Select(x => new
            { x.Id, x.Number, x.Balance, x.OpenDate, x.Type }).ToList();
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            AccountBLL accountBll = new();
            BindingSource bindingSource = new();
            if (txtId.Text.Length>0)
            {
                try
                {
                    bindingSource.Add(accountBll.GetById(int.Parse(txtId.Text)));
                    foreach (Account item in bindingSource)
                    {
                        txtId.Text = item.Id.ToString();
                        txtNumber.Text = item.Number.ToString();
                        txtBalance.Text = item.Balance.ToString();
                        dateTimePickerOpenDate.Value = (DateTime)item.OpenDate;
                        txtType.Text = item.Type.ToString();
                        txtClientId.Text = item.ClientId.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("please enter Id");
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (txtNumber.Text.Length>0&txtBalance.Text.Length>0&txtType.Text.Length>0&txtClientId.Text.Length>0&txtId.Text.Length==0)
            {
                try
                {
                    AccountBLL accountBll = new();
                    Account account = new();
                    account.Number = txtNumber.Text.ToString();
                    account.Balance = decimal.Parse(txtBalance.Text);
                    account.OpenDate = dateTimePickerOpenDate.Value;
                    account.Type = txtType.Text.ToString();
                    account.ClientId = int.Parse(txtClientId.Text);
                    accountBll.Insert(account);
                    MessageBox.Show("well done");
                    dataGridViewAccount.DataSource = accountBll.GetAll().Select(x => new
                    { x.Id, x.Number, x.Balance, x.OpenDate, x.Type }).ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (txtId.Text.Length != 0)
            {
                MessageBox.Show("please clear Id first");
            }
            else
            {
                MessageBox.Show("please enter all fields");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtId.Text.Length>0&txtNumber.Text.Length > 0 & txtBalance.Text.Length > 0 & txtType.Text.Length > 0 & txtClientId.Text.Length > 0)
            {
                try
                {
                    AccountBLL accountBll = new();
                    Account account = new();
                    account.Id = int.Parse(txtId.Text);
                    account.Number = txtNumber.Text.ToString();
                    account.Balance = decimal.Parse(txtBalance.Text);
                    account.OpenDate = dateTimePickerOpenDate.Value;
                    account.Type = txtType.Text.ToString();
                    account.ClientId = int.Parse(txtClientId.Text);
                    accountBll.Update(account);
                    MessageBox.Show("well done");
                    dataGridViewAccount.DataSource = accountBll.GetAll().Select(x => new
                    { x.Id, x.Number, x.Balance, x.OpenDate, x.Type }).ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("please enter all fields");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (txtId.Text.Length>0)
            {
                try
                {
                    AccountBLL accountBll = new();
                    accountBll.Delete(int.Parse(txtId.Text));
                    MessageBox.Show("well done");
                    dataGridViewAccount.DataSource = accountBll.GetAll().Select(x => new
                    { x.Id, x.Number, x.Balance, x.OpenDate, x.Type }).ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("please enter Id");
            }
        }

        private void buttonClearResult_Click(object sender, EventArgs e)
        {
            txtId.Text="";
            txtNumber.Text="";
            txtBalance.Text="";
            txtType.Text="";
            txtClientId.Text="";
            dateTimePickerOpenDate.Value = DateTime.Now;
        }
    }
}
