﻿using System.Collections.Generic;
using System.Text;
using CSUES.Engine.Enums;
using CSUES.Engine.Models;
using CSUES.Engine.Models.Constraints;

namespace CSUES.Engine.Utils
{
    public static class Extensions
    {     
        public static bool IsSatisfyingConstraints(this IList<Constraint> constraints, Point point)
        {
            var length = constraints.Count;

            for (var i = 0; i < length; i++)
            {
                if (!constraints[i].IsSatisfyingConstraint(point))
                    return false;
            }

            return true;
        }
        
        public static string ToLpFormat(this IList<Constraint> constraints, IList<Domain> domains)
        {
            var sb = new StringBuilder();

            sb.AppendLine("Subject To");

            for (var i = 0; i < constraints.Count; i++)
            {
                sb.Append("\t");
                sb.AppendFormat("c{0}: ", i);
              
                for (var j = 0; j < constraints[i].Terms.Length; j++)
                {                    
                    var term = constraints[i].Terms[j];
                    
                    if (term.Type == TermType.Linear)
                        sb.AppendFormat("{0} x{1}", term.Coefficient, j);
                    else
                        sb.AppendFormat("{0} x{1} ^ {2}", term.Coefficient, j, term.Power);

                    sb.Append(j == constraints[i].Terms.Length - 1 ? " <= " : " + ");
                }

                sb.Append(constraints[i].LimitingValue);
                sb.Append("\n");
            }

            sb.AppendLine("Bounds");

            for (var i = 0; i < domains.Count; i++)
            {
                sb.Append("\t");
                sb.AppendFormat("{0} <= x{1} <= {2}", domains[i].LowerLimit, i, domains[i].UpperLimit);
                sb.Append("\n");
            }

            sb.AppendLine("Generals");
            sb.Append("\t");

            for (var i = 0; i < domains.Count; i++)
            {
                sb.AppendFormat("x{0}", i);
                sb.Append(i != domains.Count - 1 ? " " : string.Empty);
            }

            sb.Append("\n");
            sb.Append("End");

            return sb.ToString();
        }
    }
}
