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
            this.SuspendLayout();
            // 
            // genbtn
            // 
            this.genbtn.Location = new System.Drawing.Point(398, 253);
            this.genbtn.Name = "genbtn";
            this.genbtn.Size = new System.Drawing.Size(85, 23);
            this.genbtn.TabIndex = 0;
            this.genbtn.Text = "Generate";
            this.genbtn.UseVisualStyleBackColor = true;
            this.genbtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1751, 445);
            this.Controls.Add(this.genbtn);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button genbtn;
    }
}

