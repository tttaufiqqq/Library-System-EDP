using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Library_Management_System_project.Services;

namespace Library_Management_System_project
{
    public partial class Fine : UserControl
    {
        private readonly IssueService _issueService = new IssueService();
        private List<IssuesBook> _overdueIssues = new List<IssuesBook>();

        public Fine()
        {
            InitializeComponent();
            ComboBoxStyleHelper.Apply(comboBox1);
            ComboBoxStyleHelper.Apply(comboBoxIssueId);
            ArrowKeyNavigationHelper.Enable(this);
        }

        private void fine_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            buttonPay.Enabled = false;
            LoadOverdueIssues();

            maskedTextBox1.TextChanged += CheckFormCompletion;
            maskedTextBox2.TextChanged += CheckFormCompletion;
            maskedTextBox3.TextChanged += CheckFormCompletion;
            comboBox1.SelectedIndexChanged += CheckFormCompletion;
            checkBoxAgree.CheckedChanged += CheckFormCompletion;
        }

        public void RefreshData()
        {
            if (InvokeRequired) { Invoke((MethodInvoker)RefreshData); return; }
            LoadOverdueIssues();
        }

        private void LoadOverdueIssues()
        {
            try
            {
                _overdueIssues = _issueService.GetActiveIssues()
                    .Where(i => FineCalculator.ComputeFine(i) > 0)
                    .ToList();

                if (_overdueIssues.Count == 0)
                {
                    comboBoxIssueId.DataSource = null;
                    comboBoxIssueId.Items.Clear();
                    comboBoxIssueId.Enabled = false;
                    labelDays.Text = "No overdue fines at this time.";
                    labelDisplay.Text = "";
                    return;
                }

                var display = _overdueIssues
                    .Select(i => new
                    {
                        i.IssueID,
                        Display = $"{i.IssueID} - {i.Book_Title} (RM {FineCalculator.ComputeFine(i):F2})"
                    })
                    .ToList();

                comboBoxIssueId.Enabled = true;
                comboBoxIssueId.DataSource = display;
                comboBoxIssueId.DisplayMember = "Display";
                comboBoxIssueId.ValueMember = "IssueID";
                comboBoxIssueId.SelectedIndex = -1;
                labelDays.Text = "";
                labelDisplay.Text = "";
            }
            catch (Exception ex)
            {
                ErrorPresenter.Show("Error loading overdue fines", ex);
            }
        }

        private void comboBoxIssueId_SelectedIndexChanged(object sender, EventArgs e)
        {
            var issue = _overdueIssues.FirstOrDefault(i => i.IssueID == comboBoxIssueId.SelectedValue as string);

            if (issue == null)
            {
                labelDays.Text = "";
                labelDisplay.Text = "";
            }
            else
            {
                DateHelper.TryParse(issue.Return_Date, out DateTime dueDate);
                int overdueDays = (DateTime.Today - dueDate).Days;
                decimal fine = FineCalculator.ComputeFine(issue);

                labelDays.Text = $"{overdueDays} day(s) - {issue.Full_Name}";
                labelDisplay.Text = $"Total Fine: RM {fine:F2}";
            }

            CheckFormCompletion(sender, e);
        }

        private void CheckFormCompletion(object sender, EventArgs e)
        {
            buttonPay.Enabled =
                comboBoxIssueId.SelectedIndex != -1 &&
                !string.IsNullOrWhiteSpace(maskedTextBox1.Text) &&
                !string.IsNullOrWhiteSpace(maskedTextBox2.Text) &&
                !string.IsNullOrWhiteSpace(maskedTextBox3.Text) &&
                comboBox1.SelectedIndex != 0 &&
                checkBoxAgree.Checked;
        }

        public void ClearFields()
        {
            comboBoxIssueId.SelectedIndex = -1;
            labelDays.Text = "";
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
            CheckFormCompletion(sender, e);
        }

        private void radioButtonCash_CheckedChanged(object sender, EventArgs e)
        {
            grpCardDetails.Enabled = false;
            CheckFormCompletion(sender, e);
        }

        private void buttonPay_Click(object sender, EventArgs e)
        {
            if (radioButtonCash.Checked)
            {
                MessageBox.Show("Please make the payment at the counter",
                    "Cash", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ClearFields();
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
                ClearFields();
            }
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            LoadOverdueIssues();
        }

        private void groupBoxCard_Enter(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
    }
}
