using System;
using System.Collections.Generic;

namespace FoodBasket.Models;

public partial class Country
{
    public int CountryId { get; set; }

    public string CountryCode { get; set; } = null!;

    public string CountryName { get; set; } = null!;

    public int CurrencyId { get; set; }

    public bool? IsActive { get; set; }

    public virtual Currency Currency { get; set; } = null!;

    public virtual ICollection<Supplier> Suppliers { get; set; } = new List<Supplier>();
}
