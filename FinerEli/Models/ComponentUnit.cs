using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinerEli.Models;

public class ComponentUnit
{
    [ForeignKey(nameof(EufdName))] public string EufdNameThsCode { get; set; }

    [Key] public string Description { get; set; }

    public EufdName EufdName { get; set; }
}