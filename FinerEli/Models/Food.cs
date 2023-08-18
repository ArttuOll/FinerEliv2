using System.ComponentModel.DataAnnotations;

namespace FinerEli.Models;

public class Food
{
    [Key] public int Id { get; set; }

    public string Name { get; set; }
}