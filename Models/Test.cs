﻿using System;
using System.Collections.Generic;

namespace Italian_Restaurant_1.Models;

public partial class Test
{
    public int TestId { get; set; }

    public string? TestName { get; set; }

    public string? Description { get; set; }

    public string? Status { get; set; }

    public int? WinnerId { get; set; }

    public virtual User? Winner { get; set; }
}
