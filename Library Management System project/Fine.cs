using System;
using System.Windows.Forms;
using Library_Management_System_project.Services;

namespace Library_Management_System_project
{
    public partial class Fine : UserControl
    {
        public Fine()
        {
            InitializeComponent();
        }

        private void fine_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            buttonPay.Enabled = false;
            numericUpDown1.Minimum = 0;
            numericUpDown1.Maximum = 1000;

            maskedTextBox1.TextChanged += CheckFormCompletion;
            maskedTextBox2.TextChanged += CheckFormCompletion;
            maskedTextBox3.TextChanged += CheckFormCompletion;
            comboBox1.SelectedIndexChanged += CheckFormCompletion;
            checkBoxAgree.CheckedChanged += CheckFormCompletion;
        }

        private void CheckFormCompletion(object sender, EventArgs e)
        {
            buttonPay.Enabled =
                !string.IsNullOrWhiteSpace(maskedTextBox1.Text) &&
                !string.IsNullOrWhiteSpace(maskedTextBox2.Text) &&
                !string.IsNullOrWhiteSpace(maskedTextBox3.Text) &&
                comboBox1.SelectedIndex != 0 &&
                checkBoxAgree.Checked;
        }

        public void ClearFields()
        {
            richTextBox1.Text = "";
            numericUpDown1.Value = 0;
            labelDisplay.Text = "";
            radioButtonCard.Checked = false;
            radioButtonCash.Checked = false;
            maskedTextBox1.Text = "";
            comboBox1.Text = "";
            maskedTextBox2.Text = "";
            maskedTextBox3.Text = "";
            checkBoxAgree.Checked = false;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void radioButtonCard_CheckedChanged(object sender, EventArgs e)
        {
            grpCardDetails.Enabled = true;
            buttonPay.Enabled = true;
        }

        private void radioButtonCash_CheckedChanged(object sender, EventArgs e)
        {
            grpCardDetails.Enabled = false;
            buttonPay.Enabled = true;
        }

        private void buttonPay_Click(object sender, EventArgs e)
        {
            if (radioButtonCash.Checked)
            {
                MessageBox.Show("Please make the payment at the counter",
                    "Cash", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (radioButtonCard.Checked)
            {
                if (string.IsNullOrWhiteSpace(maskedTextBox1.Text))
                {
                    MessageBox.Show("Card Details is required.",
                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                MessageBox.Show("Your payment is successful.",
                    "Payment Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            decimal fine = FineCalculator.Calculate((int)numericUpDown1.Value);
            labelDisplay.Text = $"Total Fine: RM {fine:F2}";
        }

        private void groupBoxCard_Enter(object sender, EventArgs e) { }
        private void richTextBox1_TextChanged(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
    }
}
