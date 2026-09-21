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
            this.lblTitle = new System.Windows.Forms.Label();

            this.pnlHrCard = new System.Windows.Forms.Panel();
            this.lblHrTitle = new System.Windows.Forms.Label();
            this.txtHr = new System.Windows.Forms.TextBox();
            this.lblHrUnit = new System.Windows.Forms.Label();
            this.pnlHrBar = new System.Windows.Forms.Panel();
            this.lblHrMembership = new System.Windows.Forms.Label();

            this.pnlBpCard = new System.Windows.Forms.Panel();
            this.lblBpTitle = new System.Windows.Forms.Label();
            this.txtBp = new System.Windows.Forms.TextBox();
            this.lblBpUnit = new System.Windows.Forms.Label();
            this.pnlBpBar = new System.Windows.Forms.Panel();
            this.lblBpMembership = new System.Windows.Forms.Label();

            this.pnlPvCard = new System.Windows.Forms.Panel();
            this.lblPvTitle = new System.Windows.Forms.Label();
            this.txtPv = new System.Windows.Forms.TextBox();
            this.lblPvUnit = new System.Windows.Forms.Label();
            this.pnlPvBar = new System.Windows.Forms.Panel();
            this.lblPvMembership = new System.Windows.Forms.Label();

            this.lblLegend = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();

            this.pnlDiagnosisBanner = new System.Windows.Forms.Panel();
            this.lblDiagnosisText = new System.Windows.Forms.Label();
            this.lblScoreText = new System.Windows.Forms.Label();

            this.btnDetails = new System.Windows.Forms.Button();

            this.pnlHrCard.SuspendLayout();
            this.pnlBpCard.SuspendLayout();
            this.pnlPvCard.SuspendLayout();
            this.pnlDiagnosisBanner.SuspendLayout();
            this.SuspendLayout();

            //
            // lblTitle
            //
            this.lblTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right));
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(0, 15);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(900, 32);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "ABSOLUTE HYPOVOLAEMIA MONITOR";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            //
            // pnlHrCard
            //
            this.pnlHrCard.BackColor = System.Drawing.Color.FromArgb(28, 30, 34);
            this.pnlHrCard.Controls.Add(this.lblHrTitle);
            this.pnlHrCard.Controls.Add(this.txtHr);
            this.pnlHrCard.Controls.Add(this.lblHrUnit);
            this.pnlHrCard.Controls.Add(this.pnlHrBar);
            this.pnlHrCard.Controls.Add(this.lblHrMembership);
            this.pnlHrCard.Location = new System.Drawing.Point(30, 60);
            this.pnlHrCard.Name = "pnlHrCard";
            this.pnlHrCard.Size = new System.Drawing.Size(260, 260);
            this.pnlHrCard.TabIndex = 1;

            //
            // lblHrTitle
            //
            this.lblHrTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblHrTitle.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblHrTitle.Location = new System.Drawing.Point(10, 10);
            this.lblHrTitle.Name = "lblHrTitle";
            this.lblHrTitle.Size = new System.Drawing.Size(240, 20);
            this.lblHrTitle.TabIndex = 0;
            this.lblHrTitle.Text = "HEART RATE (HR)";

            //
            // txtHr
            //
            this.txtHr.BackColor = System.Drawing.Color.FromArgb(28, 30, 34);
            this.txtHr.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtHr.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Bold);
            this.txtHr.ForeColor = System.Drawing.Color.FromArgb(0, 230, 118);
            this.txtHr.Location = new System.Drawing.Point(10, 35);
            this.txtHr.Name = "txtHr";
            this.txtHr.Size = new System.Drawing.Size(240, 52);
            this.txtHr.TabIndex = 1;
            this.txtHr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtHr.Text = "0.0";

            //
            // lblHrUnit
            //
            this.lblHrUnit.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblHrUnit.ForeColor = System.Drawing.Color.DarkGray;
            this.lblHrUnit.Location = new System.Drawing.Point(10, 90);
            this.lblHrUnit.Name = "lblHrUnit";
            this.lblHrUnit.Size = new System.Drawing.Size(240, 15);
            this.lblHrUnit.TabIndex = 2;
            this.lblHrUnit.Text = "normalised deviation";
            this.lblHrUnit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            //
            // pnlHrBar
            //
            this.pnlHrBar.BackColor = System.Drawing.Color.FromArgb(28, 30, 34);
            this.pnlHrBar.Location = new System.Drawing.Point(10, 115);
            this.pnlHrBar.Name = "pnlHrBar";
            this.pnlHrBar.Size = new System.Drawing.Size(240, 28);
            this.pnlHrBar.TabIndex = 3;
            this.pnlHrBar.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlHrBar_Paint);

            //
            // lblHrMembership
            //
            this.lblHrMembership.Font = new System.Drawing.Font("Consolas", 9F);
            this.lblHrMembership.ForeColor = System.Drawing.Color.LightGray;
            this.lblHrMembership.Location = new System.Drawing.Point(10, 150);
            this.lblHrMembership.Name = "lblHrMembership";
            this.lblHrMembership.Size = new System.Drawing.Size(240, 60);
            this.lblHrMembership.TabIndex = 4;
            this.lblHrMembership.Text = "Mild:     0.00\nModerate: 0.00\nSevere:   0.00";

            //
            // pnlBpCard
            //
            this.pnlBpCard.BackColor = System.Drawing.Color.FromArgb(28, 30, 34);
            this.pnlBpCard.Controls.Add(this.lblBpTitle);
            this.pnlBpCard.Controls.Add(this.txtBp);
            this.pnlBpCard.Controls.Add(this.lblBpUnit);
            this.pnlBpCard.Controls.Add(this.pnlBpBar);
            this.pnlBpCard.Controls.Add(this.lblBpMembership);
            this.pnlBpCard.Location = new System.Drawing.Point(320, 60);
            this.pnlBpCard.Name = "pnlBpCard";
            this.pnlBpCard.Size = new System.Drawing.Size(260, 260);
            this.pnlBpCard.TabIndex = 2;

            //
            // lblBpTitle
            //
            this.lblBpTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblBpTitle.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblBpTitle.Location = new System.Drawing.Point(10, 10);
            this.lblBpTitle.Name = "lblBpTitle";
            this.lblBpTitle.Size = new System.Drawing.Size(240, 20);
            this.lblBpTitle.TabIndex = 0;
            this.lblBpTitle.Text = "BLOOD PRESSURE (BP)";

            //
            // txtBp
            //
            this.txtBp.BackColor = System.Drawing.Color.FromArgb(28, 30, 34);
            this.txtBp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtBp.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Bold);
            this.txtBp.ForeColor = System.Drawing.Color.FromArgb(255, 82, 82);
            this.txtBp.Location = new System.Drawing.Point(10, 35);
            this.txtBp.Name = "txtBp";
            this.txtBp.Size = new System.Drawing.Size(240, 52);
            this.txtBp.TabIndex = 1;
            this.txtBp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtBp.Text = "0.0";

            //
            // lblBpUnit
            //
            this.lblBpUnit.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblBpUnit.ForeColor = System.Drawing.Color.DarkGray;
            this.lblBpUnit.Location = new System.Drawing.Point(10, 90);
            this.lblBpUnit.Name = "lblBpUnit";
            this.lblBpUnit.Size = new System.Drawing.Size(240, 15);
            this.lblBpUnit.TabIndex = 2;
            this.lblBpUnit.Text = "normalised deviation";
            this.lblBpUnit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            //
            // pnlBpBar
            //
            this.pnlBpBar.BackColor = System.Drawing.Color.FromArgb(28, 30, 34);
            this.pnlBpBar.Location = new System.Drawing.Point(10, 115);
            this.pnlBpBar.Name = "pnlBpBar";
            this.pnlBpBar.Size = new System.Drawing.Size(240, 28);
            this.pnlBpBar.TabIndex = 3;
            this.pnlBpBar.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBpBar_Paint);

            //
            // lblBpMembership
            //
            this.lblBpMembership.Font = new System.Drawing.Font("Consolas", 9F);
            this.lblBpMembership.ForeColor = System.Drawing.Color.LightGray;
            this.lblBpMembership.Location = new System.Drawing.Point(10, 150);
            this.lblBpMembership.Name = "lblBpMembership";
            this.lblBpMembership.Size = new System.Drawing.Size(240, 60);
            this.lblBpMembership.TabIndex = 4;
            this.lblBpMembership.Text = "Mild:     0.00\nModerate: 0.00\nSevere:   0.00";

            //
            // pnlPvCard
            //
            this.pnlPvCard.BackColor = System.Drawing.Color.FromArgb(28, 30, 34);
            this.pnlPvCard.Controls.Add(this.lblPvTitle);
            this.pnlPvCard.Controls.Add(this.txtPv);
            this.pnlPvCard.Controls.Add(this.lblPvUnit);
            this.pnlPvCard.Controls.Add(this.pnlPvBar);
            this.pnlPvCard.Controls.Add(this.lblPvMembership);
            this.pnlPvCard.Location = new System.Drawing.Point(610, 60);
            this.pnlPvCard.Name = "pnlPvCard";
            this.pnlPvCard.Size = new System.Drawing.Size(260, 260);
            this.pnlPvCard.TabIndex = 3;

            //
            // lblPvTitle
            //
            this.lblPvTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPvTitle.ForeColor = System.Drawing.Color.Gainsboro;
            this.lblPvTitle.Location = new System.Drawing.Point(10, 10);
            this.lblPvTitle.Name = "lblPvTitle";
            this.lblPvTitle.Size = new System.Drawing.Size(240, 20);
            this.lblPvTitle.TabIndex = 0;
            this.lblPvTitle.Text = "PULSE VOLUME (PV)";

            //
            // txtPv
            //
            this.txtPv.BackColor = System.Drawing.Color.FromArgb(28, 30, 34);
            this.txtPv.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPv.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Bold);
            this.txtPv.ForeColor = System.Drawing.Color.FromArgb(0, 229, 255);
            this.txtPv.Location = new System.Drawing.Point(10, 35);
            this.txtPv.Name = "txtPv";
            this.txtPv.Size = new System.Drawing.Size(240, 52);
            this.txtPv.TabIndex = 1;
            this.txtPv.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtPv.Text = "0.0";

            //
            // lblPvUnit
            //
            this.lblPvUnit.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblPvUnit.ForeColor = System.Drawing.Color.DarkGray;
            this.lblPvUnit.Location = new System.Drawing.Point(10, 90);
            this.lblPvUnit.Name = "lblPvUnit";
            this.lblPvUnit.Size = new System.Drawing.Size(240, 15);
            this.lblPvUnit.TabIndex = 2;
            this.lblPvUnit.Text = "normalised deviation";
            this.lblPvUnit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            //
            // pnlPvBar
            //
            this.pnlPvBar.BackColor = System.Drawing.Color.FromArgb(28, 30, 34);
            this.pnlPvBar.Location = new System.Drawing.Point(10, 115);
            this.pnlPvBar.Name = "pnlPvBar";
            this.pnlPvBar.Size = new System.Drawing.Size(240, 28);
            this.pnlPvBar.TabIndex = 3;
            this.pnlPvBar.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlPvBar_Paint);

            //
            // lblPvMembership
            //
            this.lblPvMembership.Font = new System.Drawing.Font("Consolas", 9F);
            this.lblPvMembership.ForeColor = System.Drawing.Color.LightGray;
            this.lblPvMembership.Location = new System.Drawing.Point(10, 150);
            this.lblPvMembership.Name = "lblPvMembership";
            this.lblPvMembership.Size = new System.Drawing.Size(240, 60);
            this.lblPvMembership.TabIndex = 4;
            this.lblPvMembership.Text = "Mild:     0.00\nModerate: 0.00\nSevere:   0.00";

            //
            // lblLegend
            //
            this.lblLegend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right));
            this.lblLegend.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.lblLegend.ForeColor = System.Drawing.Color.Gray;
            this.lblLegend.Location = new System.Drawing.Point(30, 326);
            this.lblLegend.Name = "lblLegend";
            this.lblLegend.Size = new System.Drawing.Size(840, 16);
            this.lblLegend.TabIndex = 4;
            this.lblLegend.Text = "Bar key:  Green = Normal   Yellow = Mild   Orange = Moderate   Red = Severe   |   White line = current reading";
            this.lblLegend.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            //
            // btnUpdate
            //
            this.btnUpdate.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnUpdate.BackColor = System.Drawing.Color.FromArgb(0, 120, 215);
            this.btnUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnUpdate.ForeColor = System.Drawing.Color.White;
            this.btnUpdate.Location = new System.Drawing.Point(350, 350);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(200, 40);
            this.btnUpdate.TabIndex = 5;
            this.btnUpdate.Text = "UPDATE READINGS";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);

            //
            // pnlDiagnosisBanner
            //
            this.pnlDiagnosisBanner.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right));
            this.pnlDiagnosisBanner.BackColor = System.Drawing.Color.FromArgb(60, 60, 60);
            this.pnlDiagnosisBanner.Controls.Add(this.lblDiagnosisText);
            this.pnlDiagnosisBanner.Controls.Add(this.lblScoreText);
            this.pnlDiagnosisBanner.Location = new System.Drawing.Point(30, 405);
            this.pnlDiagnosisBanner.Name = "pnlDiagnosisBanner";
            this.pnlDiagnosisBanner.Size = new System.Drawing.Size(840, 90);
            this.pnlDiagnosisBanner.TabIndex = 6;

            //
            // lblDiagnosisText
            //
            this.lblDiagnosisText.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblDiagnosisText.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblDiagnosisText.ForeColor = System.Drawing.Color.White;
            this.lblDiagnosisText.Location = new System.Drawing.Point(0, 0);
            this.lblDiagnosisText.Name = "lblDiagnosisText";
            this.lblDiagnosisText.Size = new System.Drawing.Size(840, 55);
            this.lblDiagnosisText.TabIndex = 0;
            this.lblDiagnosisText.Text = "AWAITING READINGS";
            this.lblDiagnosisText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            //
            // lblScoreText
            //
            this.lblScoreText.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblScoreText.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblScoreText.ForeColor = System.Drawing.Color.White;
            this.lblScoreText.Location = new System.Drawing.Point(0, 60);
            this.lblScoreText.Name = "lblScoreText";
            this.lblScoreText.Size = new System.Drawing.Size(840, 30);
            this.lblScoreText.TabIndex = 1;
            this.lblScoreText.Text = "Severity Score: -- / 100";
            this.lblScoreText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            //
            // btnDetails
            //
            this.btnDetails.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDetails.BackColor = System.Drawing.Color.FromArgb(45, 45, 48);
            this.btnDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetails.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnDetails.ForeColor = System.Drawing.Color.Gainsboro;
            this.btnDetails.Location = new System.Drawing.Point(350, 510);
            this.btnDetails.Name = "btnDetails";
            this.btnDetails.Size = new System.Drawing.Size(200, 34);
            this.btnDetails.TabIndex = 7;
            this.btnDetails.Text = "Show Rule Details";
            this.btnDetails.UseVisualStyleBackColor = false;
            this.btnDetails.Click += new System.EventHandler(this.btnDetails_Click);

            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(18, 18, 22);
            this.ClientSize = new System.Drawing.Size(900, 580);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pnlHrCard);
            this.Controls.Add(this.pnlBpCard);
            this.Controls.Add(this.pnlPvCard);
            this.Controls.Add(this.lblLegend);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.pnlDiagnosisBanner);
            this.Controls.Add(this.btnDetails);
            this.MinimumSize = new System.Drawing.Size(916, 619);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Absolute Hypovolaemia Monitor - AMSabshypovolaemia";

            this.pnlHrCard.ResumeLayout(false);
            this.pnlBpCard.ResumeLayout(false);
            this.pnlPvCard.ResumeLayout(false);
            this.pnlDiagnosisBanner.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label lblTitle;

        private System.Windows.Forms.Panel pnlHrCard;
        private System.Windows.Forms.Label lblHrTitle;
        private System.Windows.Forms.TextBox txtHr;
        private System.Windows.Forms.Label lblHrUnit;
        private System.Windows.Forms.Panel pnlHrBar;
        private System.Windows.Forms.Label lblHrMembership;

        private System.Windows.Forms.Panel pnlBpCard;
        private System.Windows.Forms.Label lblBpTitle;
        private System.Windows.Forms.TextBox txtBp;
        private System.Windows.Forms.Label lblBpUnit;
        private System.Windows.Forms.Panel pnlBpBar;
        private System.Windows.Forms.Label lblBpMembership;

        private System.Windows.Forms.Panel pnlPvCard;
        private System.Windows.Forms.Label lblPvTitle;
        private System.Windows.Forms.TextBox txtPv;
        private System.Windows.Forms.Label lblPvUnit;
        private System.Windows.Forms.Panel pnlPvBar;
        private System.Windows.Forms.Label lblPvMembership;

        private System.Windows.Forms.Label lblLegend;
        private System.Windows.Forms.Button btnUpdate;

        private System.Windows.Forms.Panel pnlDiagnosisBanner;
        private System.Windows.Forms.Label lblDiagnosisText;
        private System.Windows.Forms.Label lblScoreText;

        private System.Windows.Forms.Button btnDetails;
    }
}