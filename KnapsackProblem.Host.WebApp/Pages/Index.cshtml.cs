using System.Reflection.Metadata;
using KnapsackProblem.Core.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KnapsackProblem.Host.WebApp.Pages;

public class IndexModel : PageModel
{
    private readonly IWebHostEnvironment _environment;
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger, IWebHostEnvironment environment)
    {
        _logger = logger;
        _environment = environment;
    }

    [BindProperty]
    public IFormFile? Upload { get; set; }

    [BindProperty]
    public Parameters? Parameters { get; set; }

    public async Task OnPostAsync()
    {
        var inputFile = Path.Combine(_environment.ContentRootPath, "Uploads", Upload!.FileName);
        using var fileStream = new FileStream(inputFile, FileMode.Create);
        await Upload.CopyToAsync(fileStream);

        Parameters!.InputFile = inputFile;
    }

    public void OnGet()
    {
        Parameters = new Parameters();
    }
}
