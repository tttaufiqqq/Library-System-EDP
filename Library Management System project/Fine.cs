using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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

            maskedTextBox1.TextChanged += new EventHandler(CheckFormCompletion);
            maskedTextBox2.TextChanged += new EventHandler(CheckFormCompletion);
            maskedTextBox3.TextChanged += new EventHandler(CheckFormCompletion);
            comboBox1.SelectedIndexChanged += new EventHandler(CheckFormCompletion);
            checkBoxAgree.CheckedChanged += new EventHandler(CheckFormCompletion);

            numericUpDown1.Minimum = 0;
            numericUpDown1.Maximum = 1000;
        }

        private void CheckFormCompletion(object sender, EventArgs e)
        {
            bool isFormComplete =
                !string.IsNullOrWhiteSpace(maskedTextBox1.Text) &&
                !string.IsNullOrWhiteSpace(maskedTextBox2.Text) &&
                !string.IsNullOrWhiteSpace(maskedTextBox3.Text) &&
                comboBox1.SelectedIndex != 0 &&
                checkBoxAgree.Checked;

            buttonPay.Enabled = isFormComplete;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBoxCard_Enter(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        public void clearFields()
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
            clearFields();
        }

        private void radioButtonCard_CheckedChanged(object sender, EventArgs e)
        {
            grpCardDetails.Enabled = true;
            buttonPay.Enabled = true;
        }

        private void buttonPay_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioButtonCash.Checked)
                    MessageBox.Show("Please make the payment at the counter", "Cash", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (radioButtonCard.Checked)
                {
                    if (string.IsNullOrWhiteSpace(maskedTextBox1.Text))
                    {
                        throw new Exception("Card Details is required.");
                    }
                    MessageBox.Show("Your payment is successful.", "Payment Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void radioButtonCash_CheckedChanged(object sender, EventArgs e)
        {
            grpCardDetails.Enabled = false;
            buttonPay.Enabled = true;
        }

        public delegate decimal FineCalculatorDelegate(decimal value);

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            FineCalculatorDelegate calculateFine = CalculateFine;
            decimal value = numericUpDown1.Value;
            decimal fine = calculateFine(value);
            labelDisplay.Text = $"Total Fine: RM {fine:F2}";
        }

        private decimal CalculateFine(decimal value)
        {
            decimal rate = 5m;
            return value * rate;
        }
    }
}

