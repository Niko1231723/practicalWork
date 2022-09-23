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
    public partial class FormClientDetails : Form
    {
        //private Rectangle formOriginalRectangle;
        //private Rectangle buttonDeleteOriginalRectangle;
        //private Rectangle buttonGetAllOriginalRectangle;
        //private Rectangle buttonGetByIdOriginalRectangle;
        //private Rectangle buttonInsertOriginalRectangle;
        //private Rectangle buttonUpdateOriginalRectangle;
        //private Rectangle buttonClearOriginalRectangle;
        //private Rectangle groupboxOperationsOriginalRectangle;
        //private Rectangle groupboxClientDetailsOriginalRectangle;
        public FormClientDetails()
        { 
            InitializeComponent();
        }
        private void FormClientDetails_Load(object sender, EventArgs e)
        {
            //formOriginalRectangle = new Rectangle(this.Location.X, this.Location.Y, this.Width, this.Height);
            //    buttonDeleteOriginalRectangle = new Rectangle(buttonDelete.Location.X, buttonDelete.Location.Y, buttonDelete.Width, buttonDelete.Height);
            //buttonGetAllOriginalRectangle = new Rectangle(buttonGetAll.Location.X, buttonGetAll.Location.Y, buttonGetAll.Width, buttonGetAll.Height);
            //    buttonGetByIdOriginalRectangle = new Rectangle(buttonGetById.Location.X, buttonGetById.Location.Y, buttonGetById.Width, buttonGetById.Height);
            //    buttonInsertOriginalRectangle = new Rectangle(buttonInsert.Location.X, buttonInsert.Location.Y, buttonInsert.Width, buttonInsert.Height);
            //    buttonUpdateOriginalRectangle = new Rectangle(buttonUpdate.Location.X, buttonUpdate.Location.Y, buttonUpdate.Width, buttonUpdate.Height);
            //    buttonClearOriginalRectangle = new Rectangle(buttonClear.Location.X, buttonClear.Location.Y, buttonClear.Width, buttonClear.Height);
            //groupboxOperationsOriginalRectangle = new Rectangle(groupBoxOperations.Location.X, groupBoxOperations.Location.Y, groupBoxOperations.Width, groupBoxOperations.Height);
            //groupboxClientDetailsOriginalRectangle = new Rectangle(groupBoxClientDetails.Location.X, groupBoxClientDetails.Location.Y, groupBoxClientDetails.Width, groupBoxClientDetails.Height);
        }
        //private void ResizeControl(Rectangle r, Control c)
        //{
        //    float xRatio = (float)(this.Width) / (float)(formOriginalRectangle.Width);
        //    float yRatio = (float)(this.Height) / (float)(formOriginalRectangle.Height);

        //    int xNew = (int)(r.Width * xRatio);
        //    int yNew = (int)(r.Height * yRatio);

        //    int newWidth = (int)(r.Width * xRatio);
        //    int newHigh = (int)(r.Height * yRatio);

        //    c.Location = new Point(xNew, yNew);
        //    c.Size = new Size(newWidth, newHigh);
        //}
        private void FormClientDetails_Resize(object sender, EventArgs e)
        {
            //ResizeControl(buttonDeleteOriginalRectangle, buttonDelete);
            //ResizeControl(buttonGetAllOriginalRectangle, buttonGetAll);
            //ResizeControl(buttonGetByIdOriginalRectangle, buttonGetById);
            //ResizeControl(buttonInsertOriginalRectangle, buttonInsert);
            //ResizeControl(buttonUpdateOriginalRectangle, buttonUpdate);
            //ResizeControl(buttonClearOriginalRectangle, buttonClear);
            //ResizeControl(groupboxOperationsOriginalRectangle, groupBoxOperations);
            //ResizeControl(groupboxClientDetailsOriginalRectangle, groupBoxClientDetails);
        }

        private void buttonGetAll_Click(object sender, EventArgs e)
        {
            ClientDetailsBLL clientDetailsBll = new();
            dataGridViewClientDetails.DataSource = clientDetailsBll.GetAll().Select(x => new
            { x.Id, x.City, x.Address, x.Date }).ToList();
        }

        private void buttonGetById_Click(object sender, EventArgs e)
        {
            ClientDetailsBLL clientDetailsBll = new();
            BindingSource bindingSource = new();
            if (textId.Text.Length > 0)
            {
                try
                {
                    bindingSource.Add(clientDetailsBll.GetById(int.Parse(textId.Text)));
                    foreach (ClientDetails column in bindingSource)
                    {
                        textId.Text = column.Id.ToString();
                        textCity.Text = column.City.ToString();
                        textAddress.Text = column.Address.ToString();
                        dateTimePicker1.Value = (DateTime)column.Date;
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
            ClientDetailsBLL clientDetailsBll = new();
            ClientDetails clientDetails = new();
            if (textCity.Text.Length > 0 & textAddress.Text.Length > 0 & dateTimePicker1.Text.Length > 0&textId.Text.Length==0)
            {
                try
                {
                    clientDetails.City = textCity.Text.ToString();
                    clientDetails.Address = textAddress.Text.ToString();
                    clientDetails.Date = dateTimePicker1.Value;
                    clientDetailsBll.Insert(clientDetails);
                    MessageBox.Show("well done");
                    dataGridViewClientDetails.DataSource = clientDetailsBll.GetAll().Select(x => new
                    { x.Id, x.City, x.Address, x.Date }).ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else if (textId.Text.Length>0)
            {
                MessageBox.Show("please clear id");
            }
            else
            {
                MessageBox.Show("please enter all fields");
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            ClientDetailsBLL clientDetailsBll = new();
            ClientDetails clientDetails = new();
            if (textId.Text.Length > 0 & textCity.Text.Length > 0 & textAddress.Text.Length > 0)
            {
                try
                {
                    clientDetails.Id = int.Parse(textId.Text);
                    clientDetails.City = textCity.Text.ToString();
                    clientDetails.Address = textAddress.Text.ToString();
                    clientDetails.Date = (DateTime)dateTimePicker1.Value;
                    clientDetailsBll.Update(clientDetails);
                    MessageBox.Show("well done");
                    dataGridViewClientDetails.DataSource = clientDetailsBll.GetAll().Select(x => new
                    { x.Id, x.City, x.Address, x.Date }).ToList();
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
            ClientDetailsBLL clientDetailsBll = new();
            if (textId.Text.Length > 0)
            {
                try
                {
                    clientDetailsBll.Delete(int.Parse(textId.Text));
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
            textCity.Text = "";
            textAddress.Text ="";
            dateTimePicker1.Value = DateTime.Now;
        }
    }
}
