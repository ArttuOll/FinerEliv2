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

    public async void OnGetAsync()
    {
        if (string.IsNullOrWhiteSpace(Q)) return;
        var foods = from f in _context.Foods
            where f.Name.ToLower().Contains(Q.ToLower())
            select f.Name;

        var result = await foods.Take(10).ToListAsync();
        FoodNames = result.Select(ToSentenceCase).ToList();
    }

    private static string ToSentenceCase(string s)
    {
        var lower = s.ToLower();
        return char.ToUpper(lower[0]) + lower[1..];
    }
}