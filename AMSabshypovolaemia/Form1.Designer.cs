namespace AMSabshypovolaemia
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblHr = new System.Windows.Forms.Label();
            this.lblBp = new System.Windows.Forms.Label();
            this.lblPv = new System.Windows.Forms.Label();
            this.txtHr = new System.Windows.Forms.TextBox();
            this.txtBp = new System.Windows.Forms.TextBox();
            this.txtPv = new System.Windows.Forms.TextBox();
            this.btnDiagnose = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            //
            // lblHr
            //
            this.lblHr.AutoSize = true;
            this.lblHr.Location = new System.Drawing.Point(20, 23);
            this.lblHr.Name = "lblHr";
            this.lblHr.Size = new System.Drawing.Size(160, 15);
            this.lblHr.TabIndex = 0;
            this.lblHr.Text = "Heart Rate (normalised):";
            //
            // lblBp
            //
            this.lblBp.AutoSize = true;
            this.lblBp.Location = new System.Drawing.Point(20, 55);
            this.lblBp.Name = "lblBp";
            this.lblBp.Size = new System.Drawing.Size(178, 15);
            this.lblBp.TabIndex = 1;
            this.lblBp.Text = "Blood Pressure (normalised):";
            //
            // lblPv
            //
            this.lblPv.AutoSize = true;
            this.lblPv.Location = new System.Drawing.Point(20, 87);
            this.lblPv.Name = "lblPv";
            this.lblPv.Size = new System.Drawing.Size(160, 15);
            this.lblPv.TabIndex = 2;
            this.lblPv.Text = "Pulse Volume (normalised):";
            //
            // txtHr
            //
            this.txtHr.Location = new System.Drawing.Point(210, 20);
            this.txtHr.Name = "txtHr";
            this.txtHr.Size = new System.Drawing.Size(120, 23);
            this.txtHr.TabIndex = 3;
            //
            // txtBp
            //
            this.txtBp.Location = new System.Drawing.Point(210, 52);
            this.txtBp.Name = "txtBp";
            this.txtBp.Size = new System.Drawing.Size(120, 23);
            this.txtBp.TabIndex = 4;
            //
            // txtPv
            //
            this.txtPv.Location = new System.Drawing.Point(210, 84);
            this.txtPv.Name = "txtPv";
            this.txtPv.Size = new System.Drawing.Size(120, 23);
            this.txtPv.TabIndex = 5;
            //
            // btnDiagnose
            //
            this.btnDiagnose.Location = new System.Drawing.Point(210, 120);
            this.btnDiagnose.Name = "btnDiagnose";
            this.btnDiagnose.Size = new System.Drawing.Size(120, 30);
            this.btnDiagnose.TabIndex = 6;
            this.btnDiagnose.Text = "Diagnose";
            this.btnDiagnose.UseVisualStyleBackColor = true;
            this.btnDiagnose.Click += new System.EventHandler(this.btnDiagnose_Click);
            //
            // txtOutput
            //
            this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutput.Font = new System.Drawing.Font("Consolas", 9F);
            this.txtOutput.Location = new System.Drawing.Point(20, 165);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(540, 380);
            this.txtOutput.TabIndex = 7;
            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.btnDiagnose);
            this.Controls.Add(this.txtPv);
            this.Controls.Add(this.txtBp);
            this.Controls.Add(this.txtHr);
            this.Controls.Add(this.lblPv);
            this.Controls.Add(this.lblBp);
            this.Controls.Add(this.lblHr);
            this.MinimumSize = new System.Drawing.Size(500, 400);
            this.Name = "Form1";
            this.Text = "Absolute Hypovolaemia FLC - AMSabshypovolaemia";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblHr;
        private System.Windows.Forms.Label lblBp;
        private System.Windows.Forms.Label lblPv;
        private System.Windows.Forms.TextBox txtHr;
        private System.Windows.Forms.TextBox txtBp;
        private System.Windows.Forms.TextBox txtPv;
        private System.Windows.Forms.Button btnDiagnose;
        private System.Windows.Forms.TextBox txtOutput;
    }
}