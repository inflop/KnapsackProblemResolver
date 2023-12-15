using KnapsackProblem.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KnapsackProblem.Host.WebApp.Pages;

public class ResultModel : PageModel
{
    public void OnGet()
    {
    }

    [BindProperty]
    public ResolveResult? ResolveResult { get; set; }
}
