using mamdanifuzzylogic;
using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AMSabshypovolaemia
{
    public partial class Form1 : Form
    {
        private readonly FuzzyHypovolaemiaController _controller = new FuzzyHypovolaemiaController();

        // Current values, kept around so the Paint handlers know where to draw the marker.
        private double _currentHr = 0.0;
        private double _currentBp = 0.0;
        private double _currentPv = 0.0;

        // Last computed result, kept so "Show Rule Details" doesn't need to recompute.
        private FuzzyResult _lastResult;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(txtHr.Text, out double hr))
            {
                MessageBox.Show("Please enter a valid number for Heart Rate.", "Invalid input",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!double.TryParse(txtBp.Text, out double bp))
            {
                MessageBox.Show("Please enter a valid number for Blood Pressure.", "Invalid input",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!double.TryParse(txtPv.Text, out double pv))
            {
                MessageBox.Show("Please enter a valid number for Pulse Volume.", "Invalid input",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _currentHr = hr;
            _currentBp = bp;
            _currentPv = pv;

            _lastResult = _controller.Evaluate(hr, bp, pv);

            UpdateMembershipLabels(_lastResult);
            UpdateDiagnosisBanner(_lastResult);

            // Force the three severity bars to repaint with the new marker position.
            pnlHrBar.Invalidate();
            pnlBpBar.Invalidate();
            pnlPvBar.Invalidate();
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            if (_lastResult == null)
            {
                MessageBox.Show("Enter readings and click \"Update Readings\" first.", "No data yet",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            MessageBox.Show(
                BuildReport(_currentHr, _currentBp, _currentPv, _lastResult),
                "Rule Firing Details",
                MessageBoxButtons.OK,
                MessageBoxIcon.None);
        }

        private void UpdateMembershipLabels(FuzzyResult result)
        {
            lblHrMembership.Text =
                $"Mild:     {result.HrSet.Mild:F2}\nModerate: {result.HrSet.Moderate:F2}\nSevere:   {result.HrSet.Severe:F2}";

            lblBpMembership.Text =
                $"Mild:     {result.BpSet.Mild:F2}\nModerate: {result.BpSet.Moderate:F2}\nSevere:   {result.BpSet.Severe:F2}";

            lblPvMembership.Text =
                $"Mild:     {result.PvSet.Mild:F2}\nModerate: {result.PvSet.Moderate:F2}\nSevere:   {result.PvSet.Severe:F2}";
        }

        private void UpdateDiagnosisBanner(FuzzyResult result)
        {
            Color bannerColor;
            string diagnosisText;

            if (!result.Diagnosis.HasValue)
            {
                bannerColor = Color.FromArgb(46, 125, 50);   // green
                diagnosisText = "NORMAL - NO SIGNIFICANT DEVIATION";
            }
            else
            {
                switch (result.Diagnosis.Value)
                {
                    case Level.Mild:
                        bannerColor = Color.FromArgb(212, 168, 22);   // yellow/gold
                        diagnosisText = "MILD HYPOVOLAEMIA";
                        break;
                    case Level.Moderate:
                        bannerColor = Color.FromArgb(245, 124, 0);    // orange
                        diagnosisText = "MODERATE HYPOVOLAEMIA";
                        break;
                    default:
                        bannerColor = Color.FromArgb(198, 40, 40);    // red
                        diagnosisText = "SEVERE HYPOVOLAEMIA";
                        break;
                }
            }

            pnlDiagnosisBanner.BackColor = bannerColor;
            lblDiagnosisText.Text = diagnosisText;
            lblScoreText.Text = $"Severity Score: {result.CrispScore:F1} / 100";
        }

        // ---------------- Severity bar painting ----------------

        private void pnlHrBar_Paint(object sender, PaintEventArgs e)
        {
            DrawSeverityBar(pnlHrBar, e.Graphics, _currentHr, FuzzyHypovolaemiaController.HrBounds);
        }

        private void pnlBpBar_Paint(object sender, PaintEventArgs e)
        {
            DrawSeverityBar(pnlBpBar, e.Graphics, _currentBp, FuzzyHypovolaemiaController.BpBounds);
        }

        private void pnlPvBar_Paint(object sender, PaintEventArgs e)
        {
            DrawSeverityBar(pnlPvBar, e.Graphics, _currentPv, FuzzyHypovolaemiaController.PvBounds);
        }

        /// <summary>
        /// Draws a horizontal bar split into Normal/Mild/Moderate/Severe colored zones
        /// (using the controller's real boundary numbers), plus a white marker showing
        /// where the current reading falls.
        /// </summary>
        private void DrawSeverityBar(Panel panel, Graphics g, double value, (double b0, double b1, double b2) bounds)
        {
            int width = panel.Width;
            int height = panel.Height;
            if (width <= 0 || height <= 0) return;

            // Give a bit of room past the severe shoulder's full-membership point.
            double axisMax = bounds.b2 + (bounds.b2 - bounds.b1) * 1.5;
            if (axisMax <= 0) axisMax = 1;

            int xNormalEnd = (int)Math.Round(Math.Min(1.0, bounds.b0 / axisMax) * width);
            int xMildEnd = (int)Math.Round(Math.Min(1.0, bounds.b1 / axisMax) * width);
            int xModerateEnd = (int)Math.Round(Math.Min(1.0, bounds.b2 / axisMax) * width);

            using (var brushNormal = new SolidBrush(Color.FromArgb(46, 125, 50)))
            using (var brushMild = new SolidBrush(Color.FromArgb(212, 168, 22)))
            using (var brushModerate = new SolidBrush(Color.FromArgb(245, 124, 0)))
            using (var brushSevere = new SolidBrush(Color.FromArgb(198, 40, 40)))
            {
                g.FillRectangle(brushNormal, 0, 0, xNormalEnd, height);
                g.FillRectangle(brushMild, xNormalEnd, 0, Math.Max(0, xMildEnd - xNormalEnd), height);
                g.FillRectangle(brushModerate, xMildEnd, 0, Math.Max(0, xModerateEnd - xMildEnd), height);
                g.FillRectangle(brushSevere, xModerateEnd, 0, Math.Max(0, width - xModerateEnd), height);
            }

            int markerX = (int)Math.Round(Math.Min(1.0, Math.Max(0.0, value / axisMax)) * width);
            markerX = Math.Max(1, Math.Min(width - 2, markerX));

            using (var markerPen = new Pen(Color.White, 3))
            {
                g.DrawLine(markerPen, markerX, 0, markerX, height);
            }
        }

        // ---------------- Detailed text report (used by "Show Rule Details") ----------------

        private string BuildReport(double hr, double bp, double pv, FuzzyResult result)
        {
            var sb = new StringBuilder();

            sb.AppendLine("=== Crisp Inputs ===");
            sb.AppendLine($"HR: {hr}    BP: {bp}    PV: {pv}");
            sb.AppendLine();

            sb.AppendLine("=== Fuzzification ===");
            sb.AppendLine($"HR -> Mild: {result.HrSet.Mild:F2}   Moderate: {result.HrSet.Moderate:F2}   Severe: {result.HrSet.Severe:F2}");
            sb.AppendLine($"BP -> Mild: {result.BpSet.Mild:F2}   Moderate: {result.BpSet.Moderate:F2}   Severe: {result.BpSet.Severe:F2}");
            sb.AppendLine($"PV -> Mild: {result.PvSet.Mild:F2}   Moderate: {result.PvSet.Moderate:F2}   Severe: {result.PvSet.Severe:F2}");
            sb.AppendLine();

            sb.AppendLine("=== Rules Fired ===");
            bool anyFired = false;
            for (int i = 0; i < result.RuleFiringStrengths.Length; i++)
            {
                if (result.RuleFiringStrengths[i] > 0)
                {
                    sb.AppendLine($"Rule {i + 1}: {result.RuleFiringStrengths[i]:F2}");
                    anyFired = true;
                }
            }
            if (!anyFired)
            {
                sb.AppendLine("(no rules fired)");
            }
            sb.AppendLine();

            sb.AppendLine("=== Aggregated Output Strengths ===");
            sb.AppendLine($"Mild: {result.MildAggregate:F2}   Moderate: {result.ModerateAggregate:F2}   Severe: {result.SevereAggregate:F2}");
            sb.AppendLine();

            sb.AppendLine("=== Result ===");
            sb.AppendLine($"Crisp Severity Score: {result.CrispScore:F2} / 100");
            sb.AppendLine($"Diagnosis: {(result.Diagnosis.HasValue ? result.Diagnosis.Value.ToString() : "Normal / No hypovolaemia detected")}");

            return sb.ToString();
        }
    }
}