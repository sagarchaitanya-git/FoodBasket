using System;
using System.Collections.Generic;

namespace FoodBasket.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public decimal ProductDisplayCost { get; set; }

    public decimal ProductActualCost { get; set; }

    public int ProductTypeId { get; set; }

    public int SupplierId { get; set; }

    public virtual ProductType ProductType { get; set; } = null!;

    public virtual Supplier Supplier { get; set; } = null!;
}
