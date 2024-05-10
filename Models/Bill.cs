using System;
using System.Collections.Generic;

namespace Italian_Restaurant_1.Models;

public partial class Bill
{
    public int BillId { get; set; }

    public decimal? Total { get; set; }
}
