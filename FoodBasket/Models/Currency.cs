using System;
using System.Collections.Generic;

namespace FoodBasket.Models;

public partial class Currency
{
    public int CurrencyId { get; set; }

    public string CurrencyShortName { get; set; } = null!;

    public string CurrencyName { get; set; } = null!;

    public string CurrencyIcon { get; set; } = null!;

    public bool? IsActive { get; set; }

    public virtual ICollection<Country> Countries { get; set; } = new List<Country>();
}
