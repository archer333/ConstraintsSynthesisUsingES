﻿using CSUES.Engine.Models;
using CSUES.Engine.Models.Terms;

namespace CSUES.WinApplication
{
    public class Linear2DConstraint : Constraint
    {
        public Linear2DConstraint(double a, double b, InequalityValue inequalityValue) : base(new Term[]
            {
                new LinearTerm((int)inequalityValue * -a),
                new LinearTerm((int)inequalityValue)
            }, (int)inequalityValue * b)
        {
        }

        public enum InequalityValue
        {
            OverLine = -1,
            UnderLine = 1
        }
    }
}
