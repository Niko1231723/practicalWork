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
    public partial class FormDeposit : Form
    {
        public FormDeposit()
        {
            InitializeComponent();
        }

        private void buttonDepositList_Click(object sender, EventArgs e)
        {
            DepositBLL depositBll = new();
            dataGridViewDeposit.DataSource = depositBll.GetAll().Select(x => new
            { x.Id, x.Number, x.Balance, x.Interest }).ToList();
        }

        private void buttonGetById_Click(object sender, EventArgs e)
        {
            DepositBLL depositBll = new();
            BindingSource bindingSource = new();
            if (textBoxId.Text.Length > 0)
            {
                try
                {
                    bindingSource.Add(depositBll.GetById(int.Parse(textBoxId.Text)));
                    foreach (Deposit column in bindingSource)
                    {
                        textBoxId.Text = column.Id.ToString();
                        textBoxNumber.Text = column.Number.ToString();
                        textBoxBalance.Text = column.Balance.ToString();
                        textBoxInterest.Text = column.Interest.ToString();
                        textClientID.Text = column.ClientId.ToString();
                        textBoxProductDetailsID.Text = column.ProductDetailsId.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else
            {
                MessageBox.Show("please enter id");
            }
        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            DepositBLL depositBll = new();
            Deposit deposit = new();
            if (textBoxNumber.Text.Length > 0 & textBoxBalance.Text.Length > 0 & textBoxInterest.Text.Length > 0&textBoxId.Text.Length==0)
            {
                try
                {
                    deposit.Number = textBoxNumber.Text.ToString();
                    deposit.Balance = decimal.Parse(textBoxBalance.Text);
                    deposit.Interest = decimal.Parse(textBoxInterest.Text);
                    deposit.ClientId = int.Parse(textBoxProductDetailsID.Text);
                    deposit.ProductDetailsId = int.Parse(textBoxProductDetailsID.Text);
                    depositBll.Insert(deposit);
                    MessageBox.Show("well done");
                    dataGridViewDeposit.DataSource = depositBll.GetAll().Select(x => new
                    { x.Id, x.Number, x.Balance, x.Interest }).ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
            else if (textBoxId.Text.Length>0)
            {
                MessageBox.Show("please clear Id first");
            }
            else
            {
                MessageBox.Show("please enter all fields");
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            DepositBLL depositBll = new();
            Deposit deposit = new();
            if (textBoxId.Text.Length > 0 & textBoxNumber.Text.Length > 0 & textBoxBalance.Text.Length > 0 & textBoxInterest.Text.Length > 0)
            {
                try
                {
                    deposit.Id = int.Parse(textBoxId.Text);
                    deposit.Number = textBoxNumber.Text.ToString();
                    deposit.Balance = decimal.Parse(textBoxBalance.Text);
                    deposit.Interest = decimal.Parse(textBoxInterest.Text);
                    deposit.ClientId = int.Parse(textBoxProductDetailsID.Text);
                    deposit.ProductDetailsId = int.Parse(textBoxProductDetailsID.Text);
                    depositBll.Update(deposit);
                    MessageBox.Show("well done");
                    dataGridViewDeposit.DataSource = depositBll.GetAll().Select(x => new
                    { x.Id, x.Number, x.Balance, x.Interest }).ToList();
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

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            DepositBLL depositBll = new();
            if (textBoxId.Text.Length > 0)
            {
                try
                {
                    depositBll.Delete(int.Parse(textBoxId.Text));
                    MessageBox.Show("well done");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("please enter id");
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxId.Text = "";
            textBoxNumber.Text = "";
            textBoxBalance.Text = "";
            textBoxInterest.Text = "";
            textBoxProductDetailsID.Text="";
            textClientID.Text="";
        }
    }
}
