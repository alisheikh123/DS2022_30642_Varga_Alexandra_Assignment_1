namespace Smart_Metering_Device_Simulator
{
    partial class Form1
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
            this.genbtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cboUserName = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblValue = new System.Windows.Forms.Label();
            this.cboDevice = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblDevice = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // genbtn
            // 
            this.genbtn.Location = new System.Drawing.Point(398, 290);
            this.genbtn.Name = "genbtn";
            this.genbtn.Size = new System.Drawing.Size(85, 23);
            this.genbtn.TabIndex = 0;
            this.genbtn.Text = "Generate";
            this.genbtn.UseVisualStyleBackColor = true;
            this.genbtn.Click += new System.EventHandler(this.genbtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(284, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "User Name";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(282, 182);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Device Name";
            // 
            // cboUserName
            // 
            this.cboUserName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboUserName.FormattingEnabled = true;
            this.cboUserName.Items.AddRange(new object[] {
            "Alexendra Loana",
            "Ali"});
            this.cboUserName.Location = new System.Drawing.Point(378, 121);
            this.cboUserName.Name = "cboUserName";
            this.cboUserName.Size = new System.Drawing.Size(214, 24);
            this.cboUserName.TabIndex = 5;
            this.cboUserName.SelectedIndexChanged += new System.EventHandler(this.cboUserName_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(731, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Selected Value:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // lblValue
            // 
            this.lblValue.AutoSize = true;
            this.lblValue.Location = new System.Drawing.Point(850, 129);
            this.lblValue.Name = "lblValue";
            this.lblValue.Size = new System.Drawing.Size(14, 16);
            this.lblValue.TabIndex = 8;
            this.lblValue.Text = "?";
            // 
            // cboDevice
            // 
            this.cboDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDevice.FormattingEnabled = true;
            this.cboDevice.Items.AddRange(new object[] {
            "Alexendra Loana",
            "Ali"});
            this.cboDevice.Location = new System.Drawing.Point(378, 182);
            this.cboDevice.Name = "cboDevice";
            this.cboDevice.Size = new System.Drawing.Size(214, 24);
            this.cboDevice.TabIndex = 9;
            this.cboDevice.SelectedIndexChanged += new System.EventHandler(this.cboDevice_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(731, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "Selected Value:";
            // 
            // lblDevice
            // 
            this.lblDevice.AutoSize = true;
            this.lblDevice.Location = new System.Drawing.Point(850, 182);
            this.lblDevice.Name = "lblDevice";
            this.lblDevice.Size = new System.Drawing.Size(14, 16);
            this.lblDevice.TabIndex = 11;
            this.lblDevice.Text = "?";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1751, 445);
            this.Controls.Add(this.lblDevice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cboDevice);
            this.Controls.Add(this.lblValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboUserName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.genbtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.button1_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button genbtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboUserName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblValue;
        private System.Windows.Forms.ComboBox cboDevice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblDevice;
    }
}

