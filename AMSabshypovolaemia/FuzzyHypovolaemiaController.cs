using System;
using System.Collections.Generic;
using System.Linq;

namespace mamdanifuzzylogic
{
    /// <summary>
    /// Linguistic levels used for both inputs (HR/BP/PV deviation) and the output (hypovolaemia severity).
    /// </summary>
    public enum Level
    {
        Mild,
        Moderate,
        Severe
    }

    /// <summary>
    /// Fuzzified membership degrees for a single crisp input.
    /// </summary>
    public struct FuzzySet
    {
        public double Mild;
        public double Moderate;
        public double Severe;

        public double this[Level level]
        {
            get
            {
                switch (level)
                {
                    case Level.Mild: return Mild;
                    case Level.Moderate: return Moderate;
                    case Level.Severe: return Severe;
                    default: throw new ArgumentOutOfRangeException(nameof(level));
                }
            }
        }
    }

    /// <summary>
    /// One IF-THEN rule: (HR is X) AND (BP is Y) AND (PV is Z) => Hypovolaemia is W
    /// Taken directly from Section 3.2 of Baig et al. (2013), FLMS-2's 10 rules.
    /// </summary>
    public struct Rule
    {
        public Level Hr;
        public Level Bp;
        public Level Pv;
        public Level Output;

        public Rule(Level hr, Level bp, Level pv, Level output)
        {
            Hr = hr;
            Bp = bp;
            Pv = pv;
            Output = output;
        }
    }

    /// <summary>
    /// Full result of running the controller once, kept around so a future UI
    /// can display fuzzification, rule strengths, and the final diagnosis.
    /// </summary>
    public class FuzzyResult
    {
        public FuzzySet HrSet;
        public FuzzySet BpSet;
        public FuzzySet PvSet;

        public double[] RuleFiringStrengths;   // one per rule, in declaration order
        public double MildAggregate;           // max firing strength across rules concluding "Mild"
        public double ModerateAggregate;
        public double SevereAggregate;

        public double CrispScore;              // 0-100 defuzzified severity
        public Level? Diagnosis;                // null => no rule fired => normal / no hypovolaemia
    }

    public class FuzzyHypovolaemiaController
    {
        // ---- Input boundary points, straight from Table 1 (normalised values) ----
        // (b0 = normal/mild boundary, b1 = mild/moderate boundary, b2 = moderate/severe boundary)
        // Public so the UI can draw accurate severity-zone bars using the exact same numbers.
        public static readonly (double b0, double b1, double b2) HrBounds = (1.75, 3.0, 5.0);
        public static readonly (double b0, double b1, double b2) BpBounds = (2.75, 5.0, 6.0);
        public static readonly (double b0, double b1, double b2) PvBounds = (4.0, 6.0, 8.0);

        // ---- Output universe of discourse: abstract 0-100 severity score ----
        // Same triangular style as the professor's fan-speed example.
        private const double OutMildA = 0, OutMildB = 0, OutMildC = 50;
        private const double OutModA = 20, OutModB = 50, OutModC = 80;
        private const double OutSevA = 50, OutSevB = 100, OutSevC = 100;

        private readonly List<Rule> _rules;

        public FuzzyHypovolaemiaController()
        {
            _rules = BuildRuleBase();
        }

        /// <summary>
        /// The 10 rules from FLMS-2 (Section 3.2). Kept in one place so they're easy
        /// to compare against the paper and tweak later.
        /// </summary>
        private static List<Rule> BuildRuleBase()
        {
            return new List<Rule>
            {
                new Rule(Level.Mild,     Level.Mild,     Level.Mild,     Level.Mild),      // 1
                new Rule(Level.Moderate, Level.Moderate, Level.Moderate, Level.Moderate),  // 2
                new Rule(Level.Severe,   Level.Severe,   Level.Severe,   Level.Severe),    // 3
                new Rule(Level.Mild,     Level.Moderate, Level.Moderate, Level.Moderate),  // 4
                new Rule(Level.Severe,   Level.Severe,   Level.Moderate, Level.Severe),    // 5
                new Rule(Level.Moderate, Level.Mild,     Level.Mild,     Level.Mild),      // 6
                new Rule(Level.Mild,     Level.Moderate, Level.Severe,   Level.Moderate),  // 7
                new Rule(Level.Mild,     Level.Mild,     Level.Severe,   Level.Moderate),  // 8
                new Rule(Level.Severe,   Level.Mild,     Level.Mild,     Level.Moderate),  // 9
                new Rule(Level.Mild,     Level.Moderate, Level.Mild,     Level.Mild),      // 10
            };
        }

        // ---------------- Membership function primitives ----------------

        private static double Triangular(double x, double a, double b, double c)
        {
            if (x <= a || x >= c) return 0.0;
            if (x == b) return 1.0;
            if (x > a && x < b) return (x - a) / (b - a);
            return (c - x) / (c - b);
        }

        /// <summary>
        /// Right-facing shoulder: 0 below riseStart, ramps linearly, 1 at and beyond plateauStart.
        /// Used for the open-ended "severe" category.
        /// </summary>
        private static double ShoulderHigh(double x, double riseStart, double plateauStart)
        {
            if (x <= riseStart) return 0.0;
            if (x >= plateauStart) return 1.0;
            return (x - riseStart) / (plateauStart - riseStart);
        }

        /// <summary>
        /// Fuzzifies one crisp normalised value into Mild/Moderate/Severe using the
        /// same "triangle-then-shoulder" partition for all three inputs.
        /// </summary>
        private static FuzzySet Fuzzify(double x, (double b0, double b1, double b2) bounds)
        {
            double mildPeak = (bounds.b0 + bounds.b1) / 2.0;
            double modPeak = (bounds.b1 + bounds.b2) / 2.0;

            // Extend each triangle's far foot PAST the shared boundary so adjacent
            // categories overlap and cross at exactly 0.5 right at the paper's stated
            // boundary value. This lets a reading blend between two categories instead
            // of belonging 100% to only one (and also removes the old "dead zone" where
            // a value sitting exactly on a boundary had zero membership everywhere).
            double mildFoot = (2.0 * bounds.b1) - mildPeak;      // mild's zero point, now past b1
            double modLeftFoot = (2.0 * bounds.b1) - modPeak;    // moderate's zero point, now before b1
            double modRightFoot = (2.0 * bounds.b2) - modPeak;   // moderate's zero point, now past b2
            double severeRiseStart = modPeak;                    // severe starts rising where moderate peaks
            double severePlateau = modRightFoot;                 // severe reaches full membership where moderate reaches zero

            return new FuzzySet
            {
                Mild = Triangular(x, bounds.b0, mildPeak, mildFoot),
                Moderate = Triangular(x, modLeftFoot, modPeak, modRightFoot),
                Severe = ShoulderHigh(x, severeRiseStart, severePlateau)
            };
        }

        // ---------------- Main inference pipeline ----------------

        /// <summary>
        /// Runs the full Mamdani pipeline on one set of normalised HR/BP/PV deviation values.
        /// </summary>
        /// <param name="normalisedHr">|HR - mean(HR)| / SD(HR) over the analysis window</param>
        /// <param name="normalisedBp">|BP - mean(BP)| / SD(BP) over the analysis window</param>
        /// <param name="normalisedPv">|PV - mean(PV)| / SD(PV) over the analysis window</param>
        public FuzzyResult Evaluate(double normalisedHr, double normalisedBp, double normalisedPv)
        {
            var result = new FuzzyResult
            {
                HrSet = Fuzzify(normalisedHr, HrBounds),
                BpSet = Fuzzify(normalisedBp, BpBounds),
                PvSet = Fuzzify(normalisedPv, PvBounds)
            };

            // 1. Rule evaluation (AND = Min), exactly like the professor's demo
            result.RuleFiringStrengths = new double[_rules.Count];
            for (int i = 0; i < _rules.Count; i++)
            {
                var rule = _rules[i];
                double strength = Math.Min(
                    result.HrSet[rule.Hr],
                    Math.Min(result.BpSet[rule.Bp], result.PvSet[rule.Pv]));
                result.RuleFiringStrengths[i] = strength;
            }

            // 2. Aggregate rules that share the same output label (take the strongest one)
            result.MildAggregate = MaxStrengthFor(Level.Mild, result);
            result.ModerateAggregate = MaxStrengthFor(Level.Moderate, result);
            result.SevereAggregate = MaxStrengthFor(Level.Severe, result);

            // 3. Implication + aggregation + centroid defuzzification (Center of Gravity)
            result.CrispScore = Defuzzify(result.MildAggregate, result.ModerateAggregate, result.SevereAggregate);

            // 4. Diagnosis label: null if literally nothing fired (i.e. normal / no hypovolaemia signal)
            bool anythingFired = result.MildAggregate > 0 || result.ModerateAggregate > 0 || result.SevereAggregate > 0;
            result.Diagnosis = anythingFired ? LabelForCrispScore(result.CrispScore) : (Level?)null;

            return result;
        }

        private double MaxStrengthFor(Level output, FuzzyResult result)
        {
            double max = 0.0;
            for (int i = 0; i < _rules.Count; i++)
            {
                if (_rules[i].Output == output)
                    max = Math.Max(max, result.RuleFiringStrengths[i]);
            }
            return max;
        }

        private static double Defuzzify(double mildStrength, double moderateStrength, double severeStrength)
        {
            double sumNumerator = 0.0;
            double sumDenominator = 0.0;
            const double step = 0.5;

            for (double y = 0.0; y <= 100.0; y += step)
            {
                double outMild = Triangular(y, OutMildA, OutMildB, OutMildC);
                double outMod = Triangular(y, OutModA, OutModB, OutModC);
                double outSev = Triangular(y, OutSevA, OutSevB, OutSevC);

                double clippedMild = Math.Min(mildStrength, outMild);
                double clippedMod = Math.Min(moderateStrength, outMod);
                double clippedSev = Math.Min(severeStrength, outSev);

                double aggregatedY = Math.Max(clippedMild, Math.Max(clippedMod, clippedSev));

                sumNumerator += y * aggregatedY * step;
                sumDenominator += aggregatedY * step;
            }

            return sumDenominator > 0.0 ? sumNumerator / sumDenominator : 0.0;
        }

        /// <summary>
        /// Post-hoc label for the crisp score: whichever output MF is strongest at that point.
        /// </summary>
        private static Level LabelForCrispScore(double crispScore)
        {
            double mild = Triangular(crispScore, OutMildA, OutMildB, OutMildC);
            double mod = Triangular(crispScore, OutModA, OutModB, OutModC);
            double sev = Triangular(crispScore, OutSevA, OutSevB, OutSevC);

            if (sev >= mod && sev >= mild) return Level.Severe;
            if (mod >= mild) return Level.Moderate;
            return Level.Mild;
        }
    }
}