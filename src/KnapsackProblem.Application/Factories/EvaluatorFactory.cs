using KnapsackProblem.Application.Operators;
using KnapsackProblem.Core.Abstractions.Factories;
using KnapsackProblem.Core.Abstractions.Operators;
using KnapsackProblem.Core.Parameters;

namespace KnapsackProblem.Application.Factories;

public class EvaluatorFactory : IEvaluatorFactory
{
    public IEvaluator Create(EvaluatorParameters parameters)
        => new Evaluator(parameters);
}
