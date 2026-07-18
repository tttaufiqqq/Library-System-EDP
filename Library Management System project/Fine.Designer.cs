namespace Library_Management_System_project
{
    partial class Fine
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.groupBoxPayment = new System.Windows.Forms.GroupBox();
            this.radioButtonCard = new System.Windows.Forms.RadioButton();
            this.grpCardDetails = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.maskedTextBox3 = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox2 = new System.Windows.Forms.MaskedTextBox();
            this.checkBoxAgree = new System.Windows.Forms.CheckBox();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.labelCvC = new System.Windows.Forms.Label();
            this.labelCountry = new System.Windows.Forms.Label();
            this.labelExpiry = new System.Windows.Forms.Label();
            this.labelCard = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonPay = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.buttonCalculate = new System.Windows.Forms.Button();
            this.labelDisplay = new System.Windows.Forms.Label();
            this.comboBoxIssueId = new System.Windows.Forms.ComboBox();
            this.labelDays = new System.Windows.Forms.Label();
            this.labelCount = new System.Windows.Forms.Label();
            this.labelBook = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButtonCash = new System.Windows.Forms.RadioButton();
            this.groupBoxPayment.SuspendLayout();
            this.grpCardDetails.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxPayment
            // 
            this.groupBoxPayment.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBoxPayment.Controls.Add(this.radioButtonCash);
            this.groupBoxPayment.Controls.Add(this.radioButtonCard);
            this.groupBoxPayment.Location = new System.Drawing.Point(51, 189);
            this.groupBoxPayment.Name = "groupBoxPayment";
            this.groupBoxPayment.Size = new System.Drawing.Size(679, 88);
            this.groupBoxPayment.TabIndex = 0;
            this.groupBoxPayment.TabStop = false;
            this.groupBoxPayment.Text = "Payment  Method";
            // 
            // radioButtonCard
            // 
            this.radioButtonCard.AccessibleRole = System.Windows.Forms.AccessibleRole.OutlineButton;
            this.radioButtonCard.AutoSize = true;
            this.radioButtonCard.Location = new System.Drawing.Point(41, 36);
            this.radioButtonCard.Name = "radioButtonCard";
            this.radioButtonCard.Size = new System.Drawing.Size(57, 20);
            this.radioButtonCard.TabIndex = 0;
            this.radioButtonCard.TabStop = true;
            this.radioButtonCard.Text = "Card";
            this.radioButtonCard.UseVisualStyleBackColor = true;
            this.radioButtonCard.CheckedChanged += new System.EventHandler(this.radioButtonCard_CheckedChanged);
            // 
            // grpCardDetails
            // 
            this.grpCardDetails.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.grpCardDetails.Controls.Add(this.comboBox1);
            this.grpCardDetails.Controls.Add(this.maskedTextBox3);
            this.grpCardDetails.Controls.Add(this.maskedTextBox2);
            this.grpCardDetails.Controls.Add(this.checkBoxAgree);
            this.grpCardDetails.Controls.Add(this.maskedTextBox1);
            this.grpCardDetails.Controls.Add(this.labelCvC);
            this.grpCardDetails.Controls.Add(this.labelCountry);
            this.grpCardDetails.Controls.Add(this.labelExpiry);
            this.grpCardDetails.Controls.Add(this.labelCard);
            this.grpCardDetails.Location = new System.Drawing.Point(51, 283);
            this.grpCardDetails.Name = "grpCardDetails";
            this.grpCardDetails.Size = new System.Drawing.Size(679, 168);
            this.grpCardDetails.TabIndex = 1;
            this.grpCardDetails.TabStop = false;
            this.grpCardDetails.Text = "Card  Details";
            this.grpCardDetails.Enter += new System.EventHandler(this.groupBoxCard_Enter);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Afghanistan",
            "Albania",
            "Algeria",
            "Andorra",
            "Angola",
            "Antigua and Barbuda",
            "Argentina",
            "Armenia",
            "Australia",
            "Austria",
            "Azerbaijan",
            "Bahamas",
            "Bahrain",
            "Bangladesh",
            "Barbados",
            "Belarus",
            "Belgium",
            "Belize",
            "Benin",
            "Bhutan",
            "Bolivia",
            "Bosnia and Herzegovina",
            "Botswana",
            "Brazil",
            "Brunei",
            "Bulgaria",
            "Burkina Faso",
            "Burundi",
            "Cabo Verde",
            "Cambodia",
            "Cameroon",
            "Canada",
            "Central African Republic",
            "Chad",
            "Chile",
            "China",
            "Colombia",
            "Comoros",
            "Congo Democratic Republic of the",
            "Congo Republic of the",
            "Costa Rica",
            "Croatia",
            "Cuba",
            "Cyprus",
            "Czech Republic",
            "Denmark",
            "Djibouti",
            "Dominica",
            "Dominican Republic",
            "East Timor (Timor-Leste)",
            "Ecuador",
            "Egypt",
            "El Salvador",
            "Equatorial Guinea",
            "Eritrea",
            "Estonia",
            "Eswatini",
            "Ethiopia",
            "Fiji",
            "Finland",
            "France",
            "Gabon",
            "Gambia",
            "Georgia",
            "Germany",
            "Ghana",
            "Greece",
            "Grenada",
            "Guatemala",
            "Guinea",
            "Guinea-Bissau",
            "Guyana",
            "Haiti",
            "Honduras",
            "Hungary",
            "Iceland",
            "India",
            "Indonesia",
            "Iran",
            "Iraq",
            "Ireland",
            "Italy",
            "Jamaica",
            "Japan",
            "Jordan",
            "Kazakhstan",
            "Kenya",
            "Kiribati",
            "Korea North",
            "Korea South",
            "Kosovo",
            "Kuwait",
            "Kyrgyzstan",
            "Laos",
            "Latvia",
            "Lebanon",
            "Lesotho",
            "Liberia",
            "Libya",
            "Liechtenstein",
            "Lithuania",
            "Luxembourg",
            "Madagascar",
            "Malawi",
            "Malaysia",
            "Maldives",
            "Mali",
            "Malta",
            "Marshall Islands",
            "Mauritania",
            "Mauritius",
            "Mexico",
            "Micronesia",
            "Moldova",
            "Monaco",
            "Mongolia",
            "Montenegro",
            "Morocco",
            "Mozambique",
            "Myanmar (Burma)",
            "Namibia",
            "Nauru",
            "Nepal",
            "Netherlands",
            "New Zealand",
            "Nicaragua",
            "Niger",
            "Nigeria",
            "North Macedonia",
            "Norway",
            "Oman",
            "Pakistan",
            "Palau",
            "Palestine",
            "Panama",
            "Papua New Guinea",
            "Paraguay",
            "Peru",
            "Philippines",
            "Poland",
            "Portugal",
            "Qatar",
            "Romania",
            "Russia",
            "Rwanda",
            "Saint Kitts and Nevis",
            "Saint Lucia",
            "Saint Vincent and the Grenadines",
            "Samoa",
            "San Marino",
            "Sao Tome and Principe",
            "Saudi Arabia",
            "Senegal",
            "Serbia",
            "Seychelles",
            "Sierra Leone",
            "Singapore",
            "Slovakia",
            "Slovenia",
            "Solomon Islands",
            "Somalia",
            "South Africa",
            "South Sudan",
            "Spain",
            "Sri Lanka",
            "Sudan",
            "Suriname",
            "Sweden",
            "Switzerland",
            "Syria",
            "Taiwan",
            "Tajikistan",
            "Tanzania",
            "Thailand",
            "Togo",
            "Tonga",
            "Trinidad and Tobago",
            "Tunisia",
            "Turkey",
            "Turkmenistan",
            "Uganda",
            "Ukraine",
            "United Arab Emirates",
            "United Kingdom",
            "United States",
            "Uruguay",
            "Uzbekistan",
            "Vanuatu",
            "Vatican City (Holy See)",
            "Venezuela",
            "Vietnam",
            "Yemen",
            "Zambia",
            "Zimbabwe"});
            this.comboBox1.Location = new System.Drawing.Point(41, 93);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(187, 24);
            this.comboBox1.TabIndex = 4;
            // 
            // maskedTextBox3
            // 
            this.maskedTextBox3.Location = new System.Drawing.Point(299, 95);
            this.maskedTextBox3.Mask = "000";
            this.maskedTextBox3.Name = "maskedTextBox3";
            this.maskedTextBox3.Size = new System.Drawing.Size(79, 22);
            this.maskedTextBox3.TabIndex = 23;
            // 
            // maskedTextBox2
            // 
            this.maskedTextBox2.Location = new System.Drawing.Point(400, 43);
            this.maskedTextBox2.Mask = "00/00";
            this.maskedTextBox2.Name = "maskedTextBox2";
            this.maskedTextBox2.Size = new System.Drawing.Size(128, 22);
            this.maskedTextBox2.TabIndex = 22;
            this.maskedTextBox2.ValidatingType = typeof(System.DateTime);
            // 
            // checkBoxAgree
            // 
            this.checkBoxAgree.AutoSize = true;
            this.checkBoxAgree.Location = new System.Drawing.Point(41, 134);
            this.checkBoxAgree.Name = "checkBoxAgree";
            this.checkBoxAgree.Size = new System.Drawing.Size(207, 20);
            this.checkBoxAgree.TabIndex = 5;
            this.checkBoxAgree.Text = "I agree to terms and condition.";
            this.checkBoxAgree.UseVisualStyleBackColor = true;
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(41, 43);
            this.maskedTextBox1.Mask = "0000 0000 0000 0000";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(310, 22);
            this.maskedTextBox1.TabIndex = 4;
            // 
            // labelCvC
            // 
            this.labelCvC.AutoSize = true;
            this.labelCvC.Location = new System.Drawing.Point(296, 76);
            this.labelCvC.Name = "labelCvC";
            this.labelCvC.Size = new System.Drawing.Size(34, 16);
            this.labelCvC.TabIndex = 3;
            this.labelCvC.Text = "CVC";
            // 
            // labelCountry
            // 
            this.labelCountry.AutoSize = true;
            this.labelCountry.Location = new System.Drawing.Point(38, 76);
            this.labelCountry.Name = "labelCountry";
            this.labelCountry.Size = new System.Drawing.Size(52, 16);
            this.labelCountry.TabIndex = 2;
            this.labelCountry.Text = "Country";
            // 
            // labelExpiry
            // 
            this.labelExpiry.AutoSize = true;
            this.labelExpiry.Location = new System.Drawing.Point(397, 24);
            this.labelExpiry.Name = "labelExpiry";
            this.labelExpiry.Size = new System.Drawing.Size(44, 16);
            this.labelExpiry.TabIndex = 1;
            this.labelExpiry.Text = "Expiry";
            // 
            // labelCard
            // 
            this.labelCard.AutoSize = true;
            this.labelCard.Location = new System.Drawing.Point(38, 24);
            this.labelCard.Name = "labelCard";
            this.labelCard.Size = new System.Drawing.Size(87, 16);
            this.labelCard.TabIndex = 0;
            this.labelCard.Text = "Card Number";
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonCancel.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonCancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonCancel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.ForeColor = System.Drawing.Color.White;
            this.buttonCancel.Location = new System.Drawing.Point(642, 457);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(88, 41);
            this.buttonCancel.TabIndex = 25;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = false;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonPay
            // 
            this.buttonPay.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonPay.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonPay.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonPay.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonPay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPay.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonPay.ForeColor = System.Drawing.Color.White;
            this.buttonPay.Location = new System.Drawing.Point(536, 457);
            this.buttonPay.Name = "buttonPay";
            this.buttonPay.Size = new System.Drawing.Size(88, 41);
            this.buttonPay.TabIndex = 21;
            this.buttonPay.Text = "Pay";
            this.buttonPay.UseVisualStyleBackColor = false;
            this.buttonPay.Click += new System.EventHandler(this.buttonPay_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Control;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.groupBox1);
            this.panel2.Controls.Add(this.buttonCancel);
            this.panel2.Controls.Add(this.grpCardDetails);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.groupBoxPayment);
            this.panel2.Controls.Add(this.buttonPay);
            this.panel2.Location = new System.Drawing.Point(28, 17);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(784, 505);
            this.panel2.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox1.Controls.Add(this.buttonCalculate);
            this.groupBox1.Controls.Add(this.labelDisplay);
            this.groupBox1.Controls.Add(this.comboBoxIssueId);
            this.groupBox1.Controls.Add(this.labelCount);
            this.groupBox1.Controls.Add(this.labelBook);
            this.groupBox1.Controls.Add(this.labelDays);
            this.groupBox1.Location = new System.Drawing.Point(51, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(679, 122);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Book  Fine";
            // 
            // buttonCalculate
            // 
            this.buttonCalculate.BackColor = System.Drawing.Color.SteelBlue;
            this.buttonCalculate.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonCalculate.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonCalculate.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSkyBlue;
            this.buttonCalculate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCalculate.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCalculate.ForeColor = System.Drawing.Color.White;
            this.buttonCalculate.Location = new System.Drawing.Point(525, 22);
            this.buttonCalculate.Name = "buttonCalculate";
            this.buttonCalculate.Size = new System.Drawing.Size(100, 30);
            this.buttonCalculate.TabIndex = 22;
            this.buttonCalculate.Text = "Refresh";
            this.buttonCalculate.UseVisualStyleBackColor = false;
            this.buttonCalculate.Click += new System.EventHandler(this.buttonCalculate_Click);
            //
            // labelDisplay
            //
            this.labelDisplay.AutoSize = true;
            this.labelDisplay.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDisplay.Location = new System.Drawing.Point(300, 68);
            this.labelDisplay.Name = "labelDisplay";
            this.labelDisplay.Size = new System.Drawing.Size(0, 17);
            this.labelDisplay.TabIndex = 7;
            //
            // comboBoxIssueId
            //
            this.comboBoxIssueId.FormattingEnabled = true;
            this.comboBoxIssueId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxIssueId.Location = new System.Drawing.Point(115, 25);
            this.comboBoxIssueId.Name = "comboBoxIssueId";
            this.comboBoxIssueId.Size = new System.Drawing.Size(390, 24);
            this.comboBoxIssueId.TabIndex = 6;
            this.comboBoxIssueId.SelectedIndexChanged += new System.EventHandler(this.comboBoxIssueId_SelectedIndexChanged);
            //
            // labelCount
            //
            this.labelCount.AutoSize = true;
            this.labelCount.Location = new System.Drawing.Point(51, 70);
            this.labelCount.Name = "labelCount";
            this.labelCount.Size = new System.Drawing.Size(56, 16);
            this.labelCount.TabIndex = 5;
            this.labelCount.Text = "Overdue:";
            //
            // labelBook
            //
            this.labelBook.AutoSize = true;
            this.labelBook.Location = new System.Drawing.Point(51, 28);
            this.labelBook.Name = "labelBook";
            this.labelBook.Size = new System.Drawing.Size(58, 16);
            this.labelBook.TabIndex = 4;
            this.labelBook.Text = "Issue ID:";
            //
            // labelDays
            //
            this.labelDays.AutoSize = true;
            this.labelDays.Location = new System.Drawing.Point(115, 70);
            this.labelDays.Name = "labelDays";
            this.labelDays.Size = new System.Drawing.Size(0, 16);
            this.labelDays.TabIndex = 2;
            //
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(25, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(213, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Payment Confirmation";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // radioButtonCash
            // 
            this.radioButtonCash.AutoSize = true;
            this.radioButtonCash.Location = new System.Drawing.Point(128, 36);
            this.radioButtonCash.Name = "radioButtonCash";
            this.radioButtonCash.Size = new System.Drawing.Size(59, 20);
            this.radioButtonCash.TabIndex = 1;
            this.radioButtonCash.TabStop = true;
            this.radioButtonCash.Text = "Cash";
            this.radioButtonCash.UseVisualStyleBackColor = true;
            this.radioButtonCash.CheckedChanged += new System.EventHandler(this.radioButtonCash_CheckedChanged);
            // 
            // Fine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.Controls.Add(this.panel2);
            this.Name = "Fine";
            this.Size = new System.Drawing.Size(849, 536);
            this.Load += new System.EventHandler(this.fine_Load);
            this.groupBoxPayment.ResumeLayout(false);
            this.groupBoxPayment.PerformLayout();
            this.grpCardDetails.ResumeLayout(false);
            this.grpCardDetails.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxPayment;
        private System.Windows.Forms.GroupBox grpCardDetails;
        private System.Windows.Forms.RadioButton radioButtonCard;
        private System.Windows.Forms.CheckBox checkBoxAgree;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.Label labelCvC;
        private System.Windows.Forms.Label labelCountry;
        private System.Windows.Forms.Label labelExpiry;
        private System.Windows.Forms.Label labelCard;
        private System.Windows.Forms.Button buttonPay;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.MaskedTextBox maskedTextBox3;
        private System.Windows.Forms.MaskedTextBox maskedTextBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label labelCount;
        private System.Windows.Forms.ComboBox comboBoxIssueId;
        private System.Windows.Forms.Label labelDays;
        private System.Windows.Forms.Label labelBook;
        private System.Windows.Forms.Button buttonCalculate;
        private System.Windows.Forms.Label labelDisplay;
        private System.Windows.Forms.RadioButton radioButtonCash;
    }
}
