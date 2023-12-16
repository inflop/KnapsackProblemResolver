using System.Diagnostics;
using KnapsackProblem.Core;
using KnapsackProblem.Core.Abstractions;
using KnapsackProblem.Core.Abstractions.Factories;
using KnapsackProblem.Core.Parameters;

namespace KnapsackProblem.Application;

public class ProblemResolver(IEvaluatorFactory evaluatorFactory, IMutatorFactory mutatorFactory, ISelectorFactory selectorFactory,
                             ICrossoverFactory crossoverFactory, IBestChromosomeProvider bestChromosomeProvider,
                             IIterationController iterationController) : IProblemResolver
{
    public ResolveResult Resolve(IParameters parameters)
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();

        var evaluator = evaluatorFactory.Create(parameters.EvaluatorParameters);
        var mutator = mutatorFactory.Create(parameters.MutationRate);
        var selector = selectorFactory.Create(parameters.SelectionType);
        var crossover = crossoverFactory.Create(parameters.CrossoverParameters);
        bestChromosomeProvider.Reset();

        var population = Population.CreateRandom(parameters.PopulationSize, parameters.ChromosomeSize);
        int iteration = 1;

        iterationController.Initialize(parameters.IterationParameters);
        do
        {
            population.Evaluate(evaluator);
            bestChromosomeProvider.SetBetter(population.BestChromosome!, iteration);

            var nextPopulation = new Population();
            for (int i = 0; i < population.Size; i++)
            {
                var parent1 = selector.Select(population);
                var parent2 = selector.Select(population);
                var child = crossover.Cross(parent1, parent2).First();
                var mutatedChild = child.Mutate(mutator);
                nextPopulation.AddChromosome(mutatedChild);
            }

            population = nextPopulation;
            iteration++;
        }
        while(!iterationController.Terminate(iteration));

        stopWatch.Stop();
        var elapsedTime = stopWatch.Elapsed;

        return new ResolveResult(iteration, bestChromosomeProvider.BestChromosome!, bestChromosomeProvider.History, elapsedTime, parameters);
    }
}
