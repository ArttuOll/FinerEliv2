using Microsoft.EntityFrameworkCore;

namespace FinerEli.Models;

[PrimaryKey(nameof(ThsCode))]
public class EufdName
{
    public string ThsCode { get; set; }

    public string Description { get; set; }
}