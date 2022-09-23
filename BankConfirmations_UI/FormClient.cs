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
    public partial class FormClient : Form
    {
        public FormClient()
        {
            InitializeComponent();
        }

        private void buttonGetAll_Click(object sender, EventArgs e)
        {
            ClientBLL clientBll = new();
            dataGridViewClient.DataSource = clientBll.GetAll().Select(x => new
            { x.Id, x.FirstName, x.LastName, x.IdNumber, x.ClientDetailsId }).ToList();
        }

        private void buttonGetById_Click(object sender, EventArgs e)
        {
            ClientBLL clientBll = new();
            BindingSource bindingSource = new();
            if (textId.Text.Length>0)
            {
                try
                {
                    bindingSource.Add(clientBll.GetById(int.Parse(textId.Text)));
                    foreach (Client column in bindingSource)
                    {
                        textId.Text = column.Id.ToString();
                        textName.Text = column.FirstName.ToString();
                        textLastName.Text = column.LastName.ToString();
                        textIdNumber.Text = column.IdNumber.ToString();
                        textClientDetailsId.Text = column.ClientDetailsId.ToString();
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
            ClientBLL clientBll = new();
            Client client = new();
            if (textName.Text.Length>0&textLastName.Text.Length>0&textIdNumber.Text.Length>0&textClientDetailsId.Text.Length>0&textId.Text.Length==0)
            {
                try
                {
                    client.FirstName = textName.Text.ToString();
                    client.LastName = textLastName.Text.ToString();
                    client.IdNumber = textIdNumber.Text.ToString();
                    client.ClientDetailsId = int.Parse(textClientDetailsId.Text);
                    clientBll.Insert(client);
                    MessageBox.Show("well done");
                    dataGridViewClient.DataSource = clientBll.GetAll().Select(x => new
                    { x.Id, x.FirstName, x.LastName, x.IdNumber, x.ClientDetailsId }).ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (textId.Text.Length>0)
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
            ClientBLL clientBll = new();
            Client client = new();
            if (textId.Text.Length>0&textName.Text.Length > 0 & textLastName.Text.Length > 0 & textIdNumber.Text.Length > 0 & textClientDetailsId.Text.Length > 0)
            {
                try
                {
                    client.Id = int.Parse(textId.Text);
                    client.FirstName = textName.Text.ToString();
                    client.LastName = textLastName.Text.ToString();
                    client.IdNumber = textIdNumber.Text.ToString();
                    client.ClientDetailsId = int.Parse(textClientDetailsId.Text);
                    clientBll.Update(client);
                    MessageBox.Show("well done");
                    dataGridViewClient.DataSource = clientBll.GetAll().Select(x => new
                    { x.Id, x.FirstName, x.LastName, x.IdNumber, x.ClientDetailsId }).ToList();
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
            ClientBLL clientBll = new();
            if (textId.Text.Length>0)
            {
                try
                {
                    clientBll.Delete(int.Parse(textId.Text));
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
            textId.Text = "";
            textName.Text = "";
            textLastName.Text = "";
            textIdNumber.Text = "";
            textClientDetailsId.Text = "";
        }
    }
}
