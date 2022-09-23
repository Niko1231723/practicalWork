namespace BankConfirmations_UI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAccount_Click(object sender, EventArgs e)
        {
            FormAccount formAccount = new();
            formAccount.Show();
        }

        private void btnClient_Click(object sender, EventArgs e)
        {
            FormClient formClient = new();
            formClient.Show();
        }

        private void btnClientDetails_Click(object sender, EventArgs e)
        {
            FormClientDetails formClientDetails = new();
            formClientDetails.Show();
        }

        private void btnDeposit_Click(object sender, EventArgs e)
        {
            FormDeposit formDeposit = new();
            formDeposit.Show();
        }
    }
}