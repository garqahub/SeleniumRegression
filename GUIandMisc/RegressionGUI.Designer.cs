namespace SeleniumRegression
{
    partial class RegressionGUI
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
            this.IEBox = new System.Windows.Forms.CheckBox();
            this.FFBox = new System.Windows.Forms.CheckBox();
            this.Cromebox = new System.Windows.Forms.CheckBox();
            this.BrowserLabel = new System.Windows.Forms.Label();
            this.ProjectLabel = new System.Windows.Forms.Label();
            this.radioButtonmyGarmin = new System.Windows.Forms.RadioButton();
            this.radioButtonConnect = new System.Windows.Forms.RadioButton();
            this.radioButtonBuyGarmin = new System.Windows.Forms.RadioButton();
            this.scriptlabel = new System.Windows.Forms.Label();
            this.ReportingBox = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.startbutton = new System.Windows.Forms.Button();
            this.ScriptBox = new System.Windows.Forms.ListBox();
            this.labelTestCount = new System.Windows.Forms.Label();
            this.labelPassedCount = new System.Windows.Forms.Label();
            this.labelTotalFailed = new System.Windows.Forms.Label();
            this.BoxTotalTests = new System.Windows.Forms.TextBox();
            this.BoxTotalPassed = new System.Windows.Forms.TextBox();
            this.BoxTotalFailed = new System.Windows.Forms.TextBox();
            this.URLBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButtonElastic = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.BoxTotalWarning = new System.Windows.Forms.TextBox();
            this.SaveFileBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.radioButtonAutoOEM = new System.Windows.Forms.RadioButton();
            this.listBoxTests = new System.Windows.Forms.ListBox();
            this.getTestBtn = new System.Windows.Forms.Button();
            this.startIndBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // IEBox
            // 
            this.IEBox.AutoSize = true;
            this.IEBox.Location = new System.Drawing.Point(89, 90);
            this.IEBox.Name = "IEBox";
            this.IEBox.Size = new System.Drawing.Size(103, 17);
            this.IEBox.TabIndex = 0;
            this.IEBox.Text = "Internet Explorer";
            this.IEBox.UseVisualStyleBackColor = true;
            this.IEBox.CheckedChanged += new System.EventHandler(this.IEBox_CheckedChanged);
            // 
            // FFBox
            // 
            this.FFBox.AutoSize = true;
            this.FFBox.Location = new System.Drawing.Point(89, 124);
            this.FFBox.Name = "FFBox";
            this.FFBox.Size = new System.Drawing.Size(60, 17);
            this.FFBox.TabIndex = 1;
            this.FFBox.Text = "FireFox";
            this.FFBox.UseVisualStyleBackColor = true;
            this.FFBox.CheckedChanged += new System.EventHandler(this.FFBox_CheckedChanged);
            // 
            // Cromebox
            // 
            this.Cromebox.AutoSize = true;
            this.Cromebox.Location = new System.Drawing.Point(89, 158);
            this.Cromebox.Name = "Cromebox";
            this.Cromebox.Size = new System.Drawing.Size(62, 17);
            this.Cromebox.TabIndex = 2;
            this.Cromebox.Text = "Chrome";
            this.Cromebox.UseVisualStyleBackColor = true;
            this.Cromebox.CheckedChanged += new System.EventHandler(this.Cromebox_CheckedChanged);
            // 
            // BrowserLabel
            // 
            this.BrowserLabel.AutoSize = true;
            this.BrowserLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BrowserLabel.Location = new System.Drawing.Point(86, 56);
            this.BrowserLabel.Name = "BrowserLabel";
            this.BrowserLabel.Size = new System.Drawing.Size(66, 13);
            this.BrowserLabel.TabIndex = 3;
            this.BrowserLabel.Text = "Browser(s)";
            // 
            // ProjectLabel
            // 
            this.ProjectLabel.AutoSize = true;
            this.ProjectLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProjectLabel.Location = new System.Drawing.Point(236, 56);
            this.ProjectLabel.Name = "ProjectLabel";
            this.ProjectLabel.Size = new System.Drawing.Size(47, 13);
            this.ProjectLabel.TabIndex = 4;
            this.ProjectLabel.Text = "Project";
            // 
            // radioButtonmyGarmin
            // 
            this.radioButtonmyGarmin.AutoSize = true;
            this.radioButtonmyGarmin.Location = new System.Drawing.Point(239, 85);
            this.radioButtonmyGarmin.Name = "radioButtonmyGarmin";
            this.radioButtonmyGarmin.Size = new System.Drawing.Size(72, 17);
            this.radioButtonmyGarmin.TabIndex = 5;
            this.radioButtonmyGarmin.TabStop = true;
            this.radioButtonmyGarmin.Text = "MyGarmin";
            this.radioButtonmyGarmin.UseVisualStyleBackColor = true;
            this.radioButtonmyGarmin.Click += new System.EventHandler(this.radioButtonmyGarmin_Click);
            // 
            // radioButtonConnect
            // 
            this.radioButtonConnect.AutoSize = true;
            this.radioButtonConnect.Location = new System.Drawing.Point(239, 131);
            this.radioButtonConnect.Name = "radioButtonConnect";
            this.radioButtonConnect.Size = new System.Drawing.Size(101, 17);
            this.radioButtonConnect.TabIndex = 6;
            this.radioButtonConnect.TabStop = true;
            this.radioButtonConnect.Text = "Garmin Connect";
            this.radioButtonConnect.UseVisualStyleBackColor = true;
            this.radioButtonConnect.Click += new System.EventHandler(this.radioButtonConnect_Click);
            // 
            // radioButtonBuyGarmin
            // 
            this.radioButtonBuyGarmin.AutoSize = true;
            this.radioButtonBuyGarmin.Location = new System.Drawing.Point(239, 108);
            this.radioButtonBuyGarmin.Name = "radioButtonBuyGarmin";
            this.radioButtonBuyGarmin.Size = new System.Drawing.Size(76, 17);
            this.radioButtonBuyGarmin.TabIndex = 7;
            this.radioButtonBuyGarmin.TabStop = true;
            this.radioButtonBuyGarmin.Text = "BuyGarmin";
            this.radioButtonBuyGarmin.UseVisualStyleBackColor = true;
            this.radioButtonBuyGarmin.Click += new System.EventHandler(this.radioButtonBuyGarmin_Click);
            // 
            // scriptlabel
            // 
            this.scriptlabel.AutoSize = true;
            this.scriptlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scriptlabel.Location = new System.Drawing.Point(350, 56);
            this.scriptlabel.Name = "scriptlabel";
            this.scriptlabel.Size = new System.Drawing.Size(77, 13);
            this.scriptlabel.TabIndex = 11;
            this.scriptlabel.Text = "Script Set(s)";
            // 
            // ReportingBox
            // 
            this.ReportingBox.Location = new System.Drawing.Point(72, 283);
            this.ReportingBox.Name = "ReportingBox";
            this.ReportingBox.ReadOnly = true;
            this.ReportingBox.Size = new System.Drawing.Size(653, 248);
            this.ReportingBox.TabIndex = 12;
            this.ReportingBox.Text = "";
            this.ReportingBox.TextChanged += new System.EventHandler(this.ReportingBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(310, 267);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Reporting";
            // 
            // startbutton
            // 
            this.startbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startbutton.Location = new System.Drawing.Point(528, 85);
            this.startbutton.Name = "startbutton";
            this.startbutton.Size = new System.Drawing.Size(72, 89);
            this.startbutton.TabIndex = 14;
            this.startbutton.Text = "Start Test Scenario";
            this.startbutton.UseVisualStyleBackColor = true;
            this.startbutton.Click += new System.EventHandler(this.startbutton_Click);
            // 
            // ScriptBox
            // 
            this.ScriptBox.AllowDrop = true;
            this.ScriptBox.FormattingEnabled = true;
            this.ScriptBox.Items.AddRange(new object[] {
            "Choose a Project First"});
            this.ScriptBox.Location = new System.Drawing.Point(353, 72);
            this.ScriptBox.Name = "ScriptBox";
            this.ScriptBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.ScriptBox.Size = new System.Drawing.Size(132, 108);
            this.ScriptBox.TabIndex = 15;
            // 
            // labelTestCount
            // 
            this.labelTestCount.AutoSize = true;
            this.labelTestCount.Location = new System.Drawing.Point(69, 544);
            this.labelTestCount.Name = "labelTestCount";
            this.labelTestCount.Size = new System.Drawing.Size(89, 13);
            this.labelTestCount.TabIndex = 16;
            this.labelTestCount.Text = "Total Test Count:";
            // 
            // labelPassedCount
            // 
            this.labelPassedCount.AutoSize = true;
            this.labelPassedCount.Location = new System.Drawing.Point(69, 573);
            this.labelPassedCount.Name = "labelPassedCount";
            this.labelPassedCount.Size = new System.Drawing.Size(111, 13);
            this.labelPassedCount.TabIndex = 17;
            this.labelPassedCount.Text = "Total Checks Passed:";
            // 
            // labelTotalFailed
            // 
            this.labelTotalFailed.AutoSize = true;
            this.labelTotalFailed.Location = new System.Drawing.Point(69, 607);
            this.labelTotalFailed.Name = "labelTotalFailed";
            this.labelTotalFailed.Size = new System.Drawing.Size(104, 13);
            this.labelTotalFailed.TabIndex = 18;
            this.labelTotalFailed.Text = "Total Checks Failed:";
            // 
            // BoxTotalTests
            // 
            this.BoxTotalTests.Location = new System.Drawing.Point(194, 537);
            this.BoxTotalTests.Name = "BoxTotalTests";
            this.BoxTotalTests.ReadOnly = true;
            this.BoxTotalTests.Size = new System.Drawing.Size(72, 20);
            this.BoxTotalTests.TabIndex = 19;
            // 
            // BoxTotalPassed
            // 
            this.BoxTotalPassed.Location = new System.Drawing.Point(194, 573);
            this.BoxTotalPassed.Name = "BoxTotalPassed";
            this.BoxTotalPassed.ReadOnly = true;
            this.BoxTotalPassed.Size = new System.Drawing.Size(72, 20);
            this.BoxTotalPassed.TabIndex = 20;
            // 
            // BoxTotalFailed
            // 
            this.BoxTotalFailed.Location = new System.Drawing.Point(194, 607);
            this.BoxTotalFailed.Name = "BoxTotalFailed";
            this.BoxTotalFailed.ReadOnly = true;
            this.BoxTotalFailed.Size = new System.Drawing.Size(72, 20);
            this.BoxTotalFailed.TabIndex = 21;
            // 
            // URLBox
            // 
            this.URLBox.Location = new System.Drawing.Point(242, 214);
            this.URLBox.Name = "URLBox";
            this.URLBox.Size = new System.Drawing.Size(358, 20);
            this.URLBox.TabIndex = 22;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(182, 217);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 23;
            this.label2.Text = "URL:";
            // 
            // radioButtonElastic
            // 
            this.radioButtonElastic.AutoSize = true;
            this.radioButtonElastic.Location = new System.Drawing.Point(239, 154);
            this.radioButtonElastic.Name = "radioButtonElastic";
            this.radioButtonElastic.Size = new System.Drawing.Size(81, 17);
            this.radioButtonElastic.TabIndex = 24;
            this.radioButtonElastic.TabStop = true;
            this.radioButtonElastic.Text = "Elastic Path";
            this.radioButtonElastic.UseVisualStyleBackColor = true;
            this.radioButtonElastic.Click += new System.EventHandler(this.radioButtonElastic_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(69, 641);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Total Check Warnings:";
            // 
            // BoxTotalWarning
            // 
            this.BoxTotalWarning.Location = new System.Drawing.Point(191, 638);
            this.BoxTotalWarning.Name = "BoxTotalWarning";
            this.BoxTotalWarning.ReadOnly = true;
            this.BoxTotalWarning.Size = new System.Drawing.Size(72, 20);
            this.BoxTotalWarning.TabIndex = 26;
            // 
            // SaveFileBox
            // 
            this.SaveFileBox.Location = new System.Drawing.Point(293, 566);
            this.SaveFileBox.Name = "SaveFileBox";
            this.SaveFileBox.Size = new System.Drawing.Size(358, 20);
            this.SaveFileBox.TabIndex = 27;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(419, 550);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 13);
            this.label4.TabIndex = 28;
            this.label4.Text = "Save File Name";
            // 
            // radioButtonAutoOEM
            // 
            this.radioButtonAutoOEM.AutoSize = true;
            this.radioButtonAutoOEM.Location = new System.Drawing.Point(239, 177);
            this.radioButtonAutoOEM.Name = "radioButtonAutoOEM";
            this.radioButtonAutoOEM.Size = new System.Drawing.Size(74, 17);
            this.radioButtonAutoOEM.TabIndex = 29;
            this.radioButtonAutoOEM.TabStop = true;
            this.radioButtonAutoOEM.Text = "Auto OEM";
            this.radioButtonAutoOEM.UseVisualStyleBackColor = true;
            this.radioButtonAutoOEM.Click += new System.EventHandler(this.radioButtonAutoOEM_Click);
            // 
            // listBoxTests
            // 
            this.listBoxTests.AllowDrop = true;
            this.listBoxTests.FormattingEnabled = true;
            this.listBoxTests.Items.AddRange(new object[] {
            "Choose Script Set before hitting Get Tests"});
            this.listBoxTests.Location = new System.Drawing.Point(635, 72);
            this.listBoxTests.Name = "listBoxTests";
            this.listBoxTests.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBoxTests.Size = new System.Drawing.Size(222, 108);
            this.listBoxTests.TabIndex = 30;
            // 
            // getTestBtn
            // 
            this.getTestBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.getTestBtn.Location = new System.Drawing.Point(695, 44);
            this.getTestBtn.Name = "getTestBtn";
            this.getTestBtn.Size = new System.Drawing.Size(89, 25);
            this.getTestBtn.TabIndex = 31;
            this.getTestBtn.Text = "Get Tests";
            this.getTestBtn.UseVisualStyleBackColor = true;
            this.getTestBtn.Click += new System.EventHandler(this.getTestBtn_Click);
            // 
            // startIndBtn
            // 
            this.startIndBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startIndBtn.Location = new System.Drawing.Point(875, 80);
            this.startIndBtn.Name = "startIndBtn";
            this.startIndBtn.Size = new System.Drawing.Size(76, 91);
            this.startIndBtn.TabIndex = 32;
            this.startIndBtn.Text = "Start Individual Test";
            this.startIndBtn.UseVisualStyleBackColor = true;
            this.startIndBtn.Click += new System.EventHandler(this.startIndBtn_Click);
            // 
            // RegressionGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 688);
            this.Controls.Add(this.startIndBtn);
            this.Controls.Add(this.getTestBtn);
            this.Controls.Add(this.listBoxTests);
            this.Controls.Add(this.radioButtonAutoOEM);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SaveFileBox);
            this.Controls.Add(this.BoxTotalWarning);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.radioButtonElastic);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.URLBox);
            this.Controls.Add(this.BoxTotalFailed);
            this.Controls.Add(this.BoxTotalPassed);
            this.Controls.Add(this.BoxTotalTests);
            this.Controls.Add(this.labelTotalFailed);
            this.Controls.Add(this.labelPassedCount);
            this.Controls.Add(this.labelTestCount);
            this.Controls.Add(this.ScriptBox);
            this.Controls.Add(this.startbutton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ReportingBox);
            this.Controls.Add(this.scriptlabel);
            this.Controls.Add(this.radioButtonBuyGarmin);
            this.Controls.Add(this.radioButtonConnect);
            this.Controls.Add(this.radioButtonmyGarmin);
            this.Controls.Add(this.ProjectLabel);
            this.Controls.Add(this.BrowserLabel);
            this.Controls.Add(this.Cromebox);
            this.Controls.Add(this.FFBox);
            this.Controls.Add(this.IEBox);
            this.Name = "RegressionGUI";
            this.Text = "QA Regression";
            this.Load += new System.EventHandler(this.RegressionGUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox IEBox;
        private System.Windows.Forms.CheckBox FFBox;
        private System.Windows.Forms.CheckBox Cromebox;
        private System.Windows.Forms.Label BrowserLabel;
        private System.Windows.Forms.Label ProjectLabel;
        private System.Windows.Forms.RadioButton radioButtonmyGarmin;
        private System.Windows.Forms.RadioButton radioButtonConnect;
        private System.Windows.Forms.RadioButton radioButtonBuyGarmin;
        private System.Windows.Forms.Label scriptlabel;
        private System.Windows.Forms.RichTextBox ReportingBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button startbutton;
        public System.Windows.Forms.ListBox ScriptBox;
        private System.Windows.Forms.Label labelTestCount;
        private System.Windows.Forms.Label labelPassedCount;
        private System.Windows.Forms.Label labelTotalFailed;
        private System.Windows.Forms.TextBox BoxTotalTests;
        private System.Windows.Forms.TextBox BoxTotalPassed;
        private System.Windows.Forms.TextBox BoxTotalFailed;
        private System.Windows.Forms.TextBox URLBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButtonElastic;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox BoxTotalWarning;
        private System.Windows.Forms.TextBox SaveFileBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton radioButtonAutoOEM;
        public System.Windows.Forms.ListBox listBoxTests;
        private System.Windows.Forms.Button getTestBtn;
        private System.Windows.Forms.Button startIndBtn;
    }
}

