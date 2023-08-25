using FinerEli.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FinerEli.Pages;

public class SearchModel : PageModel
{
    private readonly FoodsContext _context;

    public SearchModel(FoodsContext context)
    {
        _context = context;
    }

    [BindProperty(SupportsGet = true)] public string? Q { get; set; }

    public IList<string> FoodNames { get; set; } = new List<string>();

    public async Task<IActionResult> OnGetAsync()
    {
        if (HttpContext.Request.Headers["Hx-Trigger"] != "search") return Page();
        if (string.IsNullOrWhiteSpace(Q)) return Partial("_FoodItems", FoodNames);
        var foods = from f in _context.Foods
            where f.Name.ToLower().Contains(Q.ToLower())
            orderby f.Name
            select f.Name;

        var result = await foods.Take(10).ToListAsync();
        FoodNames = result.Select(ToSentenceCase).ToList();

        return Partial("_FoodItems", FoodNames);
    }

    private static string ToSentenceCase(string s)
    {
        var lower = s.ToLower();
        return char.ToUpper(lower[0]) + lower[1..];
    }
}