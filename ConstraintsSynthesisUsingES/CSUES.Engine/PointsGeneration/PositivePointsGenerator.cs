﻿using CSUES.Engine.Enums;
using CSUES.Engine.Models;
using ES.Core.Utils;

namespace CSUES.Engine.PointsGeneration
{
    public class PositivePointsGenerator : PointsGenerator
    {
        private readonly MersenneTwister _randomGenerator;

        public PositivePointsGenerator()
        {
            _randomGenerator = MersenneTwister.Instance;
        }

        protected override Point GetAllowedPoint(Domain[] domains, Constraint[] constraints)
        {
            var numberOfDimensions = domains.Length;
            var numberOfConstraints = constraints.Length;
            var point = new Point(numberOfDimensions, ClassificationType.Positive);

            var isSatsfyngConstraints = false;

            while (isSatsfyngConstraints == false)
            {
                isSatsfyngConstraints = true;

                for (var i = 0; i < numberOfDimensions; i++)
                    point.Coordinates[i] = _randomGenerator.NextDouble(domains[i].LowerLimit, domains[i].UpperLimit);

                for (var i = 0; i < numberOfConstraints; i++)
                {
                    if (constraints[i].IsSatisfyingConstraint(point)) continue;
                    isSatsfyngConstraints = false;
                    break;
                }
            }

            return point;
        }
    }
}
