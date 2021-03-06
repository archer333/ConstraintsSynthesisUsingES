﻿using ES.Core.Engine;
using ES.Core.Models;
using ES.Core.Models.Solutions;
using ES.Core.Mutation;
using ES.Core.MutationSupervison;
using ES.Core.PopulationGeneration;
using ES.Core.Recombination;
using ES.Core.Selection;

namespace ES.Core.Factories
{
    public interface IEnginesFactory
    {
        IEngine Create(EvolutionParameters evolutionParameters, IGenericFactory<Solution> solutionsFactory,
            IGenericFactory<PopulationGeneratorBase> populationGeneratorsFactory, IGenericFactory<MutatorBase> objectMutatorsFactory,
            IGenericFactory<MutatorBase> stdDevsMutatorsFactory, IGenericFactory<MutationRuleSupervisorBase> mutationRuleSupervisorsFactory,
            IGenericFactory<ParentsSelectorBase> parentsSelectorsFactory, IGenericFactory<SurvivorsSelectorBase> survivorsSelectorsFactory, 
            IGenericFactory<MutatorBase> rotationsMutatorsFactory = null, IGenericFactory<RecombinerBase> objectRecombinersFactory = null, 
            IGenericFactory<RecombinerBase> stdDevsRecombinersFactory = null, IGenericFactory<RecombinerBase> rotationsRecombinersFactory = null);
    }
}