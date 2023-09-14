using Microsoft.EntityFrameworkCore;

namespace FinerEli.Models;

[PrimaryKey(nameof(Name))]
public class ComponentUnit
{
     public string Name { get; set; }

     public string Description { get; set; }
}