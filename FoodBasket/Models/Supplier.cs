using System;
using System.Collections.Generic;

namespace FoodBasket.Models;

public partial class Supplier
{
    public int SupplierId { get; set; }

    public string SupplierName { get; set; } = null!;

    public string SupplierAddress { get; set; } = null!;

    public string SupplierTelephone1 { get; set; } = null!;

    public string? SupplierTelephone2 { get; set; }

    public string SupplierEmail { get; set; } = null!;

    public string? SupplierAltEmail { get; set; }

    public int CountryId { get; set; }

    public virtual Country Country { get; set; } = null!;

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
