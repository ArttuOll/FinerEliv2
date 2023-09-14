using FinerEli.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FinerEli.Pages;

public class FoodDetails : PageModel
{
    
    private readonly FoodsContext _context;

    public FoodDetails(FoodsContext context)
    {
        _context = context;
    }

    public Food Food { get; set; } = new();
    
    public IEnumerable<ComponentClass> ComponentClasses { get; set; } = new List<ComponentClass>();
    
    public IActionResult OnGet(int id)
    {
        var food = _context.Foods.Find(id);
        if (food == null)
        {
            return NotFound();
        }
        
        Food = food;

        var componentValues = _context.ComponentValues.Where(componentValue => componentValue.FoodId == Food.Id).ToList();
        
        var componentClasses = from componentValue in componentValues
            join component in _context.Components on componentValue.EufdNameThsCode equals component.EufdNameThsCode
            join componentClass in _context.ComponentClasses on component.ComponentClassName equals componentClass.Name
            orderby componentValue.Value descending 
            select componentClass;
        
        ComponentClasses = componentClasses.Distinct();

        return Page();
    }
}