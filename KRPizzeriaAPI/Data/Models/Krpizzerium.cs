using System;
using System.Collections.Generic;

namespace KRPizzeriaAPI.Data.Models;

public partial class Krpizzerium
{
    public int IdKrpizzeria { get; set; }

    public string KrName { get; set; } = null!;

    public bool KrWithCocaCola { get; set; }

    public decimal KrPrecio { get; set; }
}
