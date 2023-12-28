using KnapsackProblem.Core;
using KnapsackProblem.Core.Domain;
using Shouldly;

namespace KnapsackProblem.UnitTests;

public class GeneTest
{
    [Fact]
    public void gene_should_be_mutated()
    {
        var gene = new Gene(false);
        bool expected = !gene.Value;

        var result = gene.Mutate();

        result.Value.ShouldBe(expected);
    }

    [Fact]
    public void any_gene_should_be_created()
    {
        var result = Gene.CreateRandom();
        result.Value.ShouldBeOneOf(true, false);
    }

    [Fact]
    public void gene_should_be_convertable_from_int()
    {
        int value = 0;
        Gene result = value;
        bool expectedValue = false;
        result.Value.ShouldBe(expectedValue);
    }

    [Fact]
    public void gene_should_be_convertable_to_int()
    {
        var gene = new Gene(false);
        int result = gene;
        int expectedValue = 0;
        result.ShouldBe(expectedValue);
    }

    [Fact]
    public void gene_should_be_convertable_from_bool()
    {
        bool value = false;
        Gene result = value;
        result.Value.ShouldBe(value);
    }

    [Fact]
    public void gene_should_be_convertable_to_bool()
    {
        bool value = false;
        var gene = new Gene(value);
        bool result = gene.Value;
        result.ShouldBe(value);
    }

    [Fact]
    public void given_genes_should_be_equal()
    {
        var gene1 = new Gene(false);
        var gene2 = new Gene(gene1.Value);

        var result = (gene1 == gene2);

        result.ShouldBeTrue();
    }

    [Fact]
    public void given_genes_should_not_be_equal()
    {
        var gene1 = new Gene(false);
        var gene2 = new Gene(!gene1.Value);

        var result = (gene1 != gene2);

        result.ShouldBeTrue();
    }

    [Fact]
    public void given_gene_negation_operator_should_return_a_negated_gene()
    {
        bool value = false;
        var gene1 = new Gene(value);
        var result = !gene1;

        result.Value.ShouldBe(!value);
    }
}
