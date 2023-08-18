using System.ComponentModel.DataAnnotations;

namespace FinerEli.Models;

public class EufdName
{
    [Key] public string ThsCode { get; set; }

    public string Description { get; set; }
}