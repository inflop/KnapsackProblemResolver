using KnapsackProblem.Application.Operators;
using KnapsackProblem.Core;
using KnapsackProblem.Core.Abstractions;
using KnapsackProblem.Core.Parameters;
using NSubstitute;
using Shouldly;

namespace KnapsackProblem.UnitTests;

public class EvaluatorTest
{
    [Fact]
    public void should_return_valid_evaluation_value_for_given_parameters()
    {
        Size knapsackSize = 20;
        var genes = new Gene[] { new (true), new (false), new (true), new (false) };
        var items = new Item[] { new (1, 2), new (3, 4), new (5, 6), new (7, 0) };
        var expectedValue = 6;

        var parameters = Substitute.For<IParameters>();
        parameters.EvaluatorParameters.Returns(new EvaluatorParameters(items, knapsackSize));

        var chromosome = new Chromosome(genes);
        var evaluator = new Evaluator(parameters.EvaluatorParameters);

        var result = evaluator.Evaluate(chromosome.Genes);
        result.Value.ShouldBe(expectedValue);
    }
}