using FinerEli.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinerEli.Pages;

public class FoodDetails : PageModel
{
    
    private readonly FoodsContext _context;

    public FoodDetails(FoodsContext context)
    {
        _context = context;
    }

    public Models.Food Food { get; set; } = new Models.Food();
    
    public void OnGet()
    {
        
    }
}