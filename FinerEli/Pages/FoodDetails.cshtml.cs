using FinerEli.Models;
using FinerEli.Util;
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

    public IEnumerable<FoodDetailsGrouping> FoodDetailsData { get; set; } = new List<FoodDetailsGrouping>();

    public IActionResult OnGet(int id)
    {
        var food = _context.Foods.Find(id);
        if (food == null) return NotFound();

        Food = food;

        var componentValues =
            _context.ComponentValues.Where(componentValue => componentValue.FoodId == Food.Id).ToList();

        var foodDetailsGrouping = from componentValue in componentValues
            join component in _context.Components on componentValue.EufdNameThsCode equals component.EufdNameThsCode
            join componentClass in _context.ComponentClasses on component.ComponentClassName equals componentClass.Name
            join eufdName in _context.EufdNames on componentValue.EufdNameThsCode equals eufdName.ThsCode
            join componentUnit in _context.ComponentUnits on component.ComponentUnitName equals componentUnit
                .EufdNameThsCode
            orderby componentValue.Value descending
            group new FoodDetailsModel
                {
                    Name = StringFormatting.ToSentenceCase(eufdName.Description), Value = componentValue.Value,
                    Unit = componentUnit.EufdNameThsCode.ToLower()
                } by
                componentClass
            into g
            select new FoodDetailsGrouping { ComponentClass = g.Key, FoodDetailsModels = g };

        FoodDetailsData = foodDetailsGrouping;

        return Page();
    }
}

public class FoodDetailsGrouping
{
    public ComponentClass ComponentClass { get; set; } = new();
    public IEnumerable<FoodDetailsModel> FoodDetailsModels { get; set; } = new List<FoodDetailsModel>();
}

public class FoodDetailsModel
{
    public string Name { get; set; } = "";
    public double Value { get; set; }
    public string Unit { get; set; } = "";
}