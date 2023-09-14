using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FinerEli.Models;

[PrimaryKey(nameof(EufdNameThsCode), nameof(ComponentUnitName), nameof(ComponentClassName))]
public class Component
{
    [ForeignKey(nameof(EufdName))]
    public string EufdNameThsCode { get; set; }
    
    [ForeignKey(nameof(ComponentUnit))]
    public string ComponentUnitName { get; set; }
    
    [ForeignKey(nameof(ComponentClass.Name))]
    public string ComponentClassName { get; set; }
}