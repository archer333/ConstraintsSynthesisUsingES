﻿using System.Linq;
using CSUES.Engine.Enums;
using CSUES.Engine.Models.Terms;

namespace CSUES.Engine.Models.Constraints
{
    public class Constraint
    {
        public Constraint(Term[] terms, double limitingValue, ConstraintType constraintType)
        {
            Terms = terms;
            LimitingValue = limitingValue;
            Type = constraintType;
        }

        public Term[] Terms { get; set; }
        public double LimitingValue { get; set; }
        public ConstraintType Type { get; set; }

        public double[] GetTermsCoefficients()
        {
            return Terms.Select(t => t.Coefficient).ToArray();
        }

        public virtual bool IsSatisfyingConstraint(Point point)
        {
            var constraintSum = 0.0;

            foreach (var term in Terms)
                constraintSum += term.Coefficient * term.Value(point.Coordinates);

            return constraintSum <= LimitingValue;
        }
    }
}