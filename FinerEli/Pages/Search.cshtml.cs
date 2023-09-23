using FinerEli.Models;
using FinerEli.Util;
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

    public IList<Food> Foods { get; set; } = new List<Food>();

    public async Task<IActionResult> OnGet()
    {
        if (HttpContext.Request.Headers["Hx-Trigger"] != "search") return Page();
        if (string.IsNullOrWhiteSpace(Q)) return Partial("_FoodItems", Foods);

        var foods = from f in _context.Foods
            where f.Name.ToLower().Contains(Q.ToLower())
            orderby f.Name
            select f;

        var result = await foods.Take(10).ToListAsync();
        Foods = result.Select(food =>
        {
            food.Name = StringFormatting.ToSentenceCase(food.Name);
            return food;
        }).ToList();

        return Partial("_FoodItems", Foods);
    }
}