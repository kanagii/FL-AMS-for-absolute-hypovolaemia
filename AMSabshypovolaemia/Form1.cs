using System;
using System.Text;
using System.Windows.Forms;

namespace AMSabshypovolaemia
{
    public partial class Form1 : Form
    {
        private readonly FuzzyHypovolaemiaController _controller = new FuzzyHypovolaemiaController();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnDiagnose_Click(object sender, EventArgs e)
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

            var result = _controller.Evaluate(hr, bp, pv);
            txtOutput.Text = BuildReport(hr, bp, pv, result);
        }

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