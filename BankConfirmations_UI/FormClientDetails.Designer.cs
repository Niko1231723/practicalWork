namespace BankConfirmations_UI
{
    partial class FormClientDetails
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormClientDetails));
            this.dataGridViewClientDetails = new System.Windows.Forms.DataGridView();
            this.groupBoxOperations = new System.Windows.Forms.GroupBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonUpdate = new System.Windows.Forms.Button();
            this.buttonInsert = new System.Windows.Forms.Button();
            this.buttonGetById = new System.Windows.Forms.Button();
            this.buttonGetAll = new System.Windows.Forms.Button();
            this.groupBoxClientDetails = new System.Windows.Forms.GroupBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.buttonClear = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textAddress = new System.Windows.Forms.TextBox();
            this.textCity = new System.Windows.Forms.TextBox();
            this.textId = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClientDetails)).BeginInit();
            this.groupBoxOperations.SuspendLayout();
            this.groupBoxClientDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewClientDetails
            // 
            this.dataGridViewClientDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewClientDetails.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewClientDetails.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewClientDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewClientDetails.Location = new System.Drawing.Point(3, 274);
            this.dataGridViewClientDetails.Name = "dataGridViewClientDetails";
            this.dataGridViewClientDetails.RowTemplate.Height = 25;
            this.dataGridViewClientDetails.Size = new System.Drawing.Size(614, 175);
            this.dataGridViewClientDetails.TabIndex = 0;
            // 
            // groupBoxOperations
            // 
            this.groupBoxOperations.Controls.Add(this.buttonDelete);
            this.groupBoxOperations.Controls.Add(this.buttonUpdate);
            this.groupBoxOperations.Controls.Add(this.buttonInsert);
            this.groupBoxOperations.Controls.Add(this.buttonGetById);
            this.groupBoxOperations.Controls.Add(this.buttonGetAll);
            this.groupBoxOperations.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBoxOperations.Location = new System.Drawing.Point(625, 0);
            this.groupBoxOperations.Name = "groupBoxOperations";
            this.groupBoxOperations.Size = new System.Drawing.Size(175, 450);
            this.groupBoxOperations.TabIndex = 1;
            this.groupBoxOperations.TabStop = false;
            this.groupBoxOperations.Text = "Operations";
            // 
            // buttonDelete
            // 
            this.buttonDelete.AutoSize = true;
            this.buttonDelete.BackColor = System.Drawing.Color.Red;
            this.buttonDelete.Location = new System.Drawing.Point(40, 375);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(107, 47);
            this.buttonDelete.TabIndex = 4;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.BackColor = System.Drawing.Color.Red;
            this.buttonUpdate.Location = new System.Drawing.Point(40, 306);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(107, 43);
            this.buttonUpdate.TabIndex = 3;
            this.buttonUpdate.Text = "Update";
            this.buttonUpdate.UseVisualStyleBackColor = false;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // buttonInsert
            // 
            this.buttonInsert.BackColor = System.Drawing.Color.Red;
            this.buttonInsert.Location = new System.Drawing.Point(40, 227);
            this.buttonInsert.Name = "buttonInsert";
            this.buttonInsert.Size = new System.Drawing.Size(107, 45);
            this.buttonInsert.TabIndex = 2;
            this.buttonInsert.Text = "Insert";
            this.buttonInsert.UseVisualStyleBackColor = false;
            this.buttonInsert.Click += new System.EventHandler(this.buttonInsert_Click);
            // 
            // buttonGetById
            // 
            this.buttonGetById.BackColor = System.Drawing.Color.Red;
            this.buttonGetById.Location = new System.Drawing.Point(40, 148);
            this.buttonGetById.Name = "buttonGetById";
            this.buttonGetById.Size = new System.Drawing.Size(107, 45);
            this.buttonGetById.TabIndex = 1;
            this.buttonGetById.Text = "Get by ID";
            this.buttonGetById.UseVisualStyleBackColor = false;
            this.buttonGetById.Click += new System.EventHandler(this.buttonGetById_Click);
            // 
            // buttonGetAll
            // 
            this.buttonGetAll.BackColor = System.Drawing.Color.Cyan;
            this.buttonGetAll.Location = new System.Drawing.Point(19, 61);
            this.buttonGetAll.Name = "buttonGetAll";
            this.buttonGetAll.Size = new System.Drawing.Size(146, 47);
            this.buttonGetAll.TabIndex = 0;
            this.buttonGetAll.Text = "Client detaiils list";
            this.buttonGetAll.UseVisualStyleBackColor = false;
            this.buttonGetAll.Click += new System.EventHandler(this.buttonGetAll_Click);
            // 
            // groupBoxClientDetails
            // 
            this.groupBoxClientDetails.Controls.Add(this.dateTimePicker1);
            this.groupBoxClientDetails.Controls.Add(this.buttonClear);
            this.groupBoxClientDetails.Controls.Add(this.label4);
            this.groupBoxClientDetails.Controls.Add(this.label3);
            this.groupBoxClientDetails.Controls.Add(this.label2);
            this.groupBoxClientDetails.Controls.Add(this.label1);
            this.groupBoxClientDetails.Controls.Add(this.textAddress);
            this.groupBoxClientDetails.Controls.Add(this.textCity);
            this.groupBoxClientDetails.Controls.Add(this.textId);
            this.groupBoxClientDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBoxClientDetails.Location = new System.Drawing.Point(0, 0);
            this.groupBoxClientDetails.Name = "groupBoxClientDetails";
            this.groupBoxClientDetails.Size = new System.Drawing.Size(625, 213);
            this.groupBoxClientDetails.TabIndex = 2;
            this.groupBoxClientDetails.TabStop = false;
            this.groupBoxClientDetails.Text = "Client Details";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(358, 93);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 23);
            this.dateTimePicker1.TabIndex = 9;
            // 
            // buttonClear
            // 
            this.buttonClear.BackColor = System.Drawing.Color.Lime;
            this.buttonClear.Location = new System.Drawing.Point(393, 148);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(100, 45);
            this.buttonClear.TabIndex = 8;
            this.buttonClear.Text = "Clear result";
            this.buttonClear.UseVisualStyleBackColor = false;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(295, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Date:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(277, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Address:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "City:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(42, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 15);
            this.label1.TabIndex = 4;
            this.label1.Text = "ID:";
            // 
            // textAddress
            // 
            this.textAddress.Location = new System.Drawing.Point(358, 44);
            this.textAddress.Name = "textAddress";
            this.textAddress.Size = new System.Drawing.Size(200, 23);
            this.textAddress.TabIndex = 2;
            // 
            // textCity
            // 
            this.textCity.Location = new System.Drawing.Point(106, 90);
            this.textCity.Name = "textCity";
            this.textCity.Size = new System.Drawing.Size(139, 23);
            this.textCity.TabIndex = 1;
            // 
            // textId
            // 
            this.textId.Location = new System.Drawing.Point(106, 45);
            this.textId.Name = "textId";
            this.textId.Size = new System.Drawing.Size(139, 23);
            this.textId.TabIndex = 0;
            // 
            // FormClientDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBoxClientDetails);
            this.Controls.Add(this.groupBoxOperations);
            this.Controls.Add(this.dataGridViewClientDetails);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormClientDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Addiko Bank";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewClientDetails)).EndInit();
            this.groupBoxOperations.ResumeLayout(false);
            this.groupBoxOperations.PerformLayout();
            this.groupBoxClientDetails.ResumeLayout(false);
            this.groupBoxClientDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dataGridViewClientDetails;
        private GroupBox groupBoxOperations;
        private Button buttonDelete;
        private Button buttonUpdate;
        private Button buttonInsert;
        private Button buttonGetById;
        private Button buttonGetAll;
        private GroupBox groupBoxClientDetails;
        private Button buttonClear;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox textAddress;
        private TextBox textCity;
        private TextBox textId;
        private DateTimePicker dateTimePicker1;
    }
}