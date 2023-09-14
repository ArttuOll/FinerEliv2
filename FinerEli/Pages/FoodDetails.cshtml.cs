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
        
        // Get component name, value and unit, grouped by component class in LINQ syntax
        var componentClasses = from componentValue in componentValues
            join component in _context.Components on componentValue.EufdNameThsCode equals component.EufdNameThsCode
            join componentClass in _context.ComponentClasses on component.ComponentClassName equals componentClass.Name
            join eufdName in _context.EufdNames on componentValue.EufdNameThsCode equals eufdName.ThsCode
            join componentUnit in _context.ComponentUnits on component.ComponentUnitName equals componentUnit.Name
            orderby componentValue.Value descending 
            group new {Name = eufdName.Description, componentValue.Value, Unit = componentUnit.Description} by componentClass
            into g
            select new {ComponentClass = g.Key, ComponentValues = g};
        
        
        
        ComponentClasses = componentClasses.Distinct();

        return Page();
    }
}