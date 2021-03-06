﻿using System.Diagnostics;
using ES.Core.Factories;
using ES.Core.Models;
using ES.Core.Models.Solutions;
using ES.Core.Mutation;
using ES.Core.MutationSupervison;
using ES.Core.PopulationGeneration;
using ES.Core.Selection;

namespace ES.Core.Engine
{
    public class UmEngineWithoutRecombination : EngineBase
    {
        public UmEngineWithoutRecombination(EvolutionParameters evolutionParameters, IGenericFactory<Solution> solutionsFactory, PopulationGeneratorBase populationGenerator, MutatorBase objectMutator, MutatorBase stdDeviationsMutator, MutationRuleSupervisorBase mutationRuleSupervisor, ParentsSelectorBase parentsSelector, SurvivorsSelectorBase survivorsSelector, Statistics statistics, Stopwatch stoper) : base(evolutionParameters, solutionsFactory, populationGenerator, objectMutator, stdDeviationsMutator, mutationRuleSupervisor, parentsSelector, survivorsSelector, statistics, stoper)
        {
        }    

        protected override void Evolve(EvaluatorBase evaluator)
        {
            var offspringPopulationSize = Parameters.OffspringPopulationSize;

            for (var i = 0; i < offspringPopulationSize; i++)
            {
                OffspringPopulation[i] = ParentsSelector.Select(BasePopulation);

                OffspringPopulation[i] = StdDeviationsMutator.Mutate(OffspringPopulation[i]);
                OffspringPopulation[i] = ObjectMutator.Mutate(OffspringPopulation[i]);

                OffspringPopulation[i].FitnessScore = evaluator.Evaluate(OffspringPopulation[i]);
            }

            BasePopulation = SurvivorsSelector.Select(BasePopulation, OffspringPopulation);
        }
    }
}
