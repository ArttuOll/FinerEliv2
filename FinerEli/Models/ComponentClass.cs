using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace FinerEli.Models;

[PrimaryKey(nameof(Name))]
public class ComponentClass
{
    public string Name { get; set; }
    public string Description { get; set; }
}