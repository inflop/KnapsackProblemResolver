using KnapsackProblem.Core;
using KnapsackProblem.Core.Abstractions;

namespace KnapsackProblem.Application;

public class BestChromosomeProvider : IBestChromosomeProvider
{
    private List<BestChromosome> _history = new ();

    public BestChromosome? BestChromosome { get; private set; }

    public IEnumerable<BestChromosome> History
        => _history;

    public bool SetBetter(Chromosome chromosome, int iteration)
    {
        bool isBetter = BestChromosome is null || chromosome.Fitness.Value > BestChromosome?.Fitness.Value;

        if (isBetter)
        {
            var genes = chromosome.Genes.ToArray();
            BestChromosome = new BestChromosome(iteration, genes, chromosome.Fitness);
            AddHistory();
        }

        return isBetter;
    }

    private void AddHistory()
    {
        if (BestChromosome is null)
            return;

        _history.Add(BestChromosome);
    }

    public void Reset()
    {
        _history = [];
        BestChromosome = null;
    }
}
