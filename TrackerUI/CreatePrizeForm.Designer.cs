namespace TrackerUI
{
    partial class CreatePrizeForm
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
            this.headerLabel = new System.Windows.Forms.Label();
            this.placeNumbertext = new System.Windows.Forms.TextBox();
            this.placeNumberLabel = new System.Windows.Forms.Label();
            this.placeNameText = new System.Windows.Forms.TextBox();
            this.placeNameLabel = new System.Windows.Forms.Label();
            this.prizePercentageText = new System.Windows.Forms.TextBox();
            this.prizePercentageLabel = new System.Windows.Forms.Label();
            this.prizeAmountText = new System.Windows.Forms.TextBox();
            this.prizeAmountLabel = new System.Windows.Forms.Label();
            this.orLabel = new System.Windows.Forms.Label();
            this.createPrizeButton = new System.Windows.Forms.Button();
            this.selectPrizeHeader = new System.Windows.Forms.Label();
            this.existingPrizeListBox = new System.Windows.Forms.ListBox();
            this.selectExistingPrizeButton = new System.Windows.Forms.Button();
            this.orSelectLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.headerLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.headerLabel.Location = new System.Drawing.Point(37, 23);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(189, 45);
            this.headerLabel.TabIndex = 11;
            this.headerLabel.Text = "Create Prize";
            // 
            // placeNumbertext
            // 
            this.placeNumbertext.Location = new System.Drawing.Point(242, 106);
            this.placeNumbertext.Name = "placeNumbertext";
            this.placeNumbertext.Size = new System.Drawing.Size(186, 35);
            this.placeNumbertext.TabIndex = 13;
            // 
            // placeNumberLabel
            // 
            this.placeNumberLabel.AutoSize = true;
            this.placeNumberLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.placeNumberLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.placeNumberLabel.Location = new System.Drawing.Point(69, 106);
            this.placeNumberLabel.Name = "placeNumberLabel";
            this.placeNumberLabel.Size = new System.Drawing.Size(149, 30);
            this.placeNumberLabel.TabIndex = 12;
            this.placeNumberLabel.Text = "Place Number:";
            // 
            // placeNameText
            // 
            this.placeNameText.Location = new System.Drawing.Point(242, 158);
            this.placeNameText.Name = "placeNameText";
            this.placeNameText.Size = new System.Drawing.Size(186, 35);
            this.placeNameText.TabIndex = 15;
            // 
            // placeNameLabel
            // 
            this.placeNameLabel.AutoSize = true;
            this.placeNameLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.placeNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.placeNameLabel.Location = new System.Drawing.Point(69, 158);
            this.placeNameLabel.Name = "placeNameLabel";
            this.placeNameLabel.Size = new System.Drawing.Size(129, 30);
            this.placeNameLabel.TabIndex = 14;
            this.placeNameLabel.Text = "Place Name:";
            // 
            // prizePercentageText
            // 
            this.prizePercentageText.Location = new System.Drawing.Point(242, 315);
            this.prizePercentageText.Name = "prizePercentageText";
            this.prizePercentageText.Size = new System.Drawing.Size(186, 35);
            this.prizePercentageText.TabIndex = 19;
            this.prizePercentageText.Text = "0";
            // 
            // prizePercentageLabel
            // 
            this.prizePercentageLabel.AutoSize = true;
            this.prizePercentageLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.prizePercentageLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.prizePercentageLabel.Location = new System.Drawing.Point(69, 315);
            this.prizePercentageLabel.Name = "prizePercentageLabel";
            this.prizePercentageLabel.Size = new System.Drawing.Size(172, 30);
            this.prizePercentageLabel.TabIndex = 18;
            this.prizePercentageLabel.Text = "Prize Percentage:";
            // 
            // prizeAmountText
            // 
            this.prizeAmountText.Location = new System.Drawing.Point(242, 211);
            this.prizeAmountText.Name = "prizeAmountText";
            this.prizeAmountText.Size = new System.Drawing.Size(186, 35);
            this.prizeAmountText.TabIndex = 17;
            this.prizeAmountText.Text = "0";
            // 
            // prizeAmountLabel
            // 
            this.prizeAmountLabel.AutoSize = true;
            this.prizeAmountLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.prizeAmountLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.prizeAmountLabel.Location = new System.Drawing.Point(69, 211);
            this.prizeAmountLabel.Name = "prizeAmountLabel";
            this.prizeAmountLabel.Size = new System.Drawing.Size(141, 30);
            this.prizeAmountLabel.TabIndex = 16;
            this.prizeAmountLabel.Text = "Prize amount:";
            // 
            // orLabel
            // 
            this.orLabel.AutoSize = true;
            this.orLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.orLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.orLabel.Location = new System.Drawing.Point(242, 265);
            this.orLabel.Name = "orLabel";
            this.orLabel.Size = new System.Drawing.Size(60, 30);
            this.orLabel.TabIndex = 20;
            this.orLabel.Text = "- or -";
            // 
            // createPrizeButton
            // 
            this.createPrizeButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.createPrizeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.createPrizeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.createPrizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createPrizeButton.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.createPrizeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.createPrizeButton.Location = new System.Drawing.Point(164, 386);
            this.createPrizeButton.Name = "createPrizeButton";
            this.createPrizeButton.Size = new System.Drawing.Size(179, 38);
            this.createPrizeButton.TabIndex = 21;
            this.createPrizeButton.Text = "Create Prize";
            this.createPrizeButton.UseVisualStyleBackColor = true;
            this.createPrizeButton.Click += new System.EventHandler(this.createPrizeButton_Click);
            // 
            // selectPrizeHeader
            // 
            this.selectPrizeHeader.AutoSize = true;
            this.selectPrizeHeader.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.selectPrizeHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.selectPrizeHeader.Location = new System.Drawing.Point(517, 23);
            this.selectPrizeHeader.Name = "selectPrizeHeader";
            this.selectPrizeHeader.Size = new System.Drawing.Size(300, 45);
            this.selectPrizeHeader.TabIndex = 22;
            this.selectPrizeHeader.Text = "Select Existing Prize";
            // 
            // existingPrizeListBox
            // 
            this.existingPrizeListBox.FormattingEnabled = true;
            this.existingPrizeListBox.ItemHeight = 30;
            this.existingPrizeListBox.Location = new System.Drawing.Point(530, 106);
            this.existingPrizeListBox.Name = "existingPrizeListBox";
            this.existingPrizeListBox.Size = new System.Drawing.Size(297, 244);
            this.existingPrizeListBox.TabIndex = 23;
            // 
            // selectExistingPrizeButton
            // 
            this.selectExistingPrizeButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.selectExistingPrizeButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.selectExistingPrizeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(242)))), ((int)(((byte)(242)))), ((int)(((byte)(242)))));
            this.selectExistingPrizeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.selectExistingPrizeButton.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.selectExistingPrizeButton.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.selectExistingPrizeButton.Location = new System.Drawing.Point(591, 386);
            this.selectExistingPrizeButton.Name = "selectExistingPrizeButton";
            this.selectExistingPrizeButton.Size = new System.Drawing.Size(179, 38);
            this.selectExistingPrizeButton.TabIndex = 24;
            this.selectExistingPrizeButton.Text = "Select Prize";
            this.selectExistingPrizeButton.UseVisualStyleBackColor = true;
            // 
            // orSelectLabel
            // 
            this.orSelectLabel.AutoSize = true;
            this.orSelectLabel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.orSelectLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.orSelectLabel.Location = new System.Drawing.Point(453, 35);
            this.orSelectLabel.Name = "orSelectLabel";
            this.orSelectLabel.Size = new System.Drawing.Size(23, 30);
            this.orSelectLabel.TabIndex = 25;
            this.orSelectLabel.Text = "||";
            // 
            // CreatePrizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(871, 480);
            this.Controls.Add(this.orSelectLabel);
            this.Controls.Add(this.selectExistingPrizeButton);
            this.Controls.Add(this.existingPrizeListBox);
            this.Controls.Add(this.selectPrizeHeader);
            this.Controls.Add(this.createPrizeButton);
            this.Controls.Add(this.orLabel);
            this.Controls.Add(this.prizePercentageText);
            this.Controls.Add(this.prizePercentageLabel);
            this.Controls.Add(this.prizeAmountText);
            this.Controls.Add(this.prizeAmountLabel);
            this.Controls.Add(this.placeNameText);
            this.Controls.Add(this.placeNameLabel);
            this.Controls.Add(this.placeNumbertext);
            this.Controls.Add(this.placeNumberLabel);
            this.Controls.Add(this.headerLabel);
            this.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "CreatePrizeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Prize";
            this.Load += new System.EventHandler(this.CreatePrizeForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label headerLabel;
        private TextBox placeNumbertext;
        private Label placeNumberLabel;
        private TextBox placeNameText;
        private Label placeNameLabel;
        private TextBox prizePercentageText;
        private Label prizePercentageLabel;
        private TextBox prizeAmountText;
        private Label prizeAmountLabel;
        private Label orLabel;
        private Button createPrizeButton;
        private Label selectPrizeHeader;
        private ListBox existingPrizeListBox;
        private Button selectExistingPrizeButton;
        private Label orSelectLabel;
    }
}