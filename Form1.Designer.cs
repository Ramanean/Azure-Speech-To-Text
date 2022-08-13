namespace SpeechToText
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Speak = new System.Windows.Forms.Button();
            this.StopTranslation = new System.Windows.Forms.Button();
            this.SpeechOutput = new System.Windows.Forms.RichTextBox();
            this.Label_SpeechServiceKey = new System.Windows.Forms.Label();
            this.SpeechKeyTextBox = new System.Windows.Forms.TextBox();
            this.Label_Region = new System.Windows.Forms.Label();
            this.SpeechRegionTextBox = new System.Windows.Forms.TextBox();
            this.Label_Language = new System.Windows.Forms.Label();
            this.LanguageSelect = new System.Windows.Forms.ComboBox();
            this.Label_Status = new System.Windows.Forms.Label();
            this.Label_CurrentStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Speak
            // 
            this.Speak.Location = new System.Drawing.Point(512, 92);
            this.Speak.Name = "Speak";
            this.Speak.Size = new System.Drawing.Size(243, 32);
            this.Speak.TabIndex = 0;
            this.Speak.Text = "Speak";
            this.Speak.UseVisualStyleBackColor = true;
            this.Speak.Click += new System.EventHandler(this.SpeakButton_ClickAsync);
            // 
            // StopTranslation
            // 
            this.StopTranslation.Location = new System.Drawing.Point(837, 93);
            this.StopTranslation.Name = "StopTranslation";
            this.StopTranslation.Size = new System.Drawing.Size(218, 32);
            this.StopTranslation.TabIndex = 1;
            this.StopTranslation.Text = "Stop";
            this.StopTranslation.UseVisualStyleBackColor = true;
            this.StopTranslation.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // SpeechOutput
            // 
            this.SpeechOutput.Location = new System.Drawing.Point(102, 192);
            this.SpeechOutput.Name = "SpeechOutput";
            this.SpeechOutput.Size = new System.Drawing.Size(1040, 367);
            this.SpeechOutput.TabIndex = 3;
            this.SpeechOutput.Text = "";
            this.SpeechOutput.TextChanged += new System.EventHandler(this.SpeechOutput_TextChanged);
            // 
            // Label_SpeechServiceKey
            // 
            this.Label_SpeechServiceKey.AutoSize = true;
            this.Label_SpeechServiceKey.Location = new System.Drawing.Point(88, 33);
            this.Label_SpeechServiceKey.Name = "Label_SpeechServiceKey";
            this.Label_SpeechServiceKey.Size = new System.Drawing.Size(178, 20);
            this.Label_SpeechServiceKey.TabIndex = 4;
            this.Label_SpeechServiceKey.Text = "Azure Speech Service Key";
            this.Label_SpeechServiceKey.Click += new System.EventHandler(this.label1_Click);
            // 
            // SpeechKeyTextBox
            // 
            this.SpeechKeyTextBox.Location = new System.Drawing.Point(302, 30);
            this.SpeechKeyTextBox.Name = "SpeechKeyTextBox";
            this.SpeechKeyTextBox.Size = new System.Drawing.Size(414, 27);
            this.SpeechKeyTextBox.TabIndex = 5;
            this.SpeechKeyTextBox.UseSystemPasswordChar = true;
            this.SpeechKeyTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // Label_Region
            // 
            this.Label_Region.AutoSize = true;
            this.Label_Region.Location = new System.Drawing.Point(780, 33);
            this.Label_Region.Name = "Label_Region";
            this.Label_Region.Size = new System.Drawing.Size(214, 20);
            this.Label_Region.TabIndex = 6;
            this.Label_Region.Text = "Azure Speech Resource Region";
            this.Label_Region.Click += new System.EventHandler(this.Label_Region_Click);
            // 
            // SpeechRegionTextBox
            // 
            this.SpeechRegionTextBox.Location = new System.Drawing.Point(1012, 30);
            this.SpeechRegionTextBox.Name = "SpeechRegionTextBox";
            this.SpeechRegionTextBox.Size = new System.Drawing.Size(111, 27);
            this.SpeechRegionTextBox.TabIndex = 7;
            this.SpeechRegionTextBox.Text = "centralus";
            this.SpeechRegionTextBox.TextChanged += new System.EventHandler(this.SpeechKeytextBox1_TextChanged);
            // 
            // Label_Language
            // 
            this.Label_Language.AutoSize = true;
            this.Label_Language.Location = new System.Drawing.Point(88, 92);
            this.Label_Language.Name = "Label_Language";
            this.Label_Language.Size = new System.Drawing.Size(175, 20);
            this.Label_Language.TabIndex = 9;
            this.Label_Language.Text = "Speech to Text Language";
            // 
            // LanguageSelect
            // 
            this.LanguageSelect.FormattingEnabled = true;
            this.LanguageSelect.Items.AddRange(new object[] {
            "en-US",
            "en-IN",
            "en-GB"});
            this.LanguageSelect.Location = new System.Drawing.Point(294, 93);
            this.LanguageSelect.Name = "LanguageSelect";
            this.LanguageSelect.Size = new System.Drawing.Size(151, 28);
            this.LanguageSelect.TabIndex = 10;
            this.LanguageSelect.TabStop = false;
            this.LanguageSelect.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Label_Status
            // 
            this.Label_Status.AutoSize = true;
            this.Label_Status.Location = new System.Drawing.Point(102, 156);
            this.Label_Status.Name = "Label_Status";
            this.Label_Status.Size = new System.Drawing.Size(49, 20);
            this.Label_Status.TabIndex = 11;
            this.Label_Status.Text = "Status";
            this.Label_Status.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // Label_CurrentStatus
            // 
            this.Label_CurrentStatus.AutoSize = true;
            this.Label_CurrentStatus.Location = new System.Drawing.Point(171, 156);
            this.Label_CurrentStatus.Name = "Label_CurrentStatus";
            this.Label_CurrentStatus.Size = new System.Drawing.Size(437, 20);
            this.Label_CurrentStatus.TabIndex = 12;
            this.Label_CurrentStatus.Text = "                                                                                 " +
    "                          ";
            this.Label_CurrentStatus.Click += new System.EventHandler(this.Label_CurrentStatus_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 571);
            this.Controls.Add(this.Label_CurrentStatus);
            this.Controls.Add(this.Label_Status);
            this.Controls.Add(this.LanguageSelect);
            this.Controls.Add(this.Label_Language);
            this.Controls.Add(this.SpeechRegionTextBox);
            this.Controls.Add(this.Label_Region);
            this.Controls.Add(this.SpeechKeyTextBox);
            this.Controls.Add(this.Label_SpeechServiceKey);
            this.Controls.Add(this.SpeechOutput);
            this.Controls.Add(this.StopTranslation);
            this.Controls.Add(this.Speak);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Name = "Form1";
            this.Text = "AST | Azure Speech to Text v1.0";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button Speak;
        private Button StopTranslation;
        private RichTextBox SpeechOutput;
        private Label Label_SpeechServiceKey;
        private TextBox SpeechKeyTextBox;
        private Label Label_Region;
        private TextBox SpeechRegionTextBox;
        private Label Label_Language;
        private ComboBox LanguageSelect;
        private Label Label_Status;
        private Label Label_CurrentStatus;
    }
}