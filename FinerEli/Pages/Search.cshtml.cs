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

    public IList<Models.Food> Foods { get; set; } = new List<Models.Food>();

    public async Task<IActionResult> OnGetAsync()
    {
        if (HttpContext.Request.Headers["Hx-Trigger"] != "search") return Page();
        if (string.IsNullOrWhiteSpace(Q)) return Partial("_FoodItems", Foods);
        
        var foods = from f in _context.Foods
            where f.Name.ToLower().Contains(Q.ToLower())
            orderby f.Name
            select f;

        var result = await foods.Take(10).ToListAsync();
        Foods = result.Select(FoodNameToSentenceCase).ToList();

        return Partial("_FoodItems", Foods);
    }

    private static Models.Food FoodNameToSentenceCase(Models.Food food)
    {
        var lower = food.Name.ToLower();
        var name = char.ToUpper(lower[0]) + lower[1..];
        food.Name = name;
        return food;
    }
}