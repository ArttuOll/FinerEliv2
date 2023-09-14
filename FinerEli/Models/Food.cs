using Microsoft.EntityFrameworkCore;

namespace FinerEli.Models;

[PrimaryKey(nameof(Id))]
public class Food
{
    public int Id { get; set; }

    public string Name { get; set; }
}