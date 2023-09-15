using Microsoft.EntityFrameworkCore;

namespace FinerEli.Models;

[PrimaryKey(nameof(EufdNameThsCode))]
public class ComponentUnit
{
    public string EufdNameThsCode { get; set; }

    public string Description { get; set; }
}