using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FinerEli.Models;

[PrimaryKey(nameof(FoodId), nameof(EufdNameThsCode))]
public class ComponentValue
{
    [ForeignKey(nameof(Food))] public int FoodId { get; set; }

    [ForeignKey(nameof(EufdName))] public string EufdNameThsCode { get; set; }

    public double Value { get; set; }

    public Food Food { get; set; }
    public EufdName EufdName { get; set; }
}