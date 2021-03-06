﻿using System;
using EvolutionStatistics = ES.Core.Models.Statistics;

namespace CSUES.Engine.Models
{
    public class Statistics : IStatistics
    {
        public int NumberOfConstraints { get; set; }
        public double MeanAngle { get; set; }
        //public double BallCenterDistanceDifference { get; set; }
        //public double BallRadiusDifference { get; set; }
        public double JaccardIndex => (double) TruePositives / (TruePositives + FalsePositives + FalseNegatives);

        public int TruePositives { get; set; }
        public int FalsePositives { get; set; }
        public int TrueNegatives { get; set; }
        public int FalseNegatives { get; set; }

        public double Recall => (double)TruePositives / (TruePositives + FalseNegatives);
        public double Specificity => (double)TrueNegatives / (TrueNegatives + FalsePositives);
        public double Precision => (double)TruePositives / (TruePositives + FalsePositives);
        public double NegativePredictiveValue => (double)TrueNegatives / (TrueNegatives + FalseNegatives);
        public double MissRate => 1 - Recall;
        public double FallOut => 1 - Specificity;
        public double FalseDiscoveryRate => 1 - Precision;
        public double FalseOmissionRate => 1 - NegativePredictiveValue;
        public double Accuracy => (double)(TruePositives + TrueNegatives) / (TruePositives + TrueNegatives + FalsePositives + FalseNegatives);
        public double F1Score => 2 * Precision * Recall / (Precision + Recall);
        
        public TimeSpan TotalSynthesisTime { get; set; }
        public TimeSpan RedundantConstraintsRemovingTime { get; set; }
        public TimeSpan ModelEvaluationTime { get; set; }

        public TimeSpan PositiveTrainingPointsGenerationTime { get; set; }
        public TimeSpan NegativeTrainingPointsGenerationTime { get; set; }
        public TimeSpan TestPointsGenerationTime { get; set; }

        public EvolutionStatistics EvolutionStatistics { get; set; }
    }
}
