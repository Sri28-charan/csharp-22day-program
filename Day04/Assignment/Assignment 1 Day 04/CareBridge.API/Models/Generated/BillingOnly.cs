using System;
using System.Collections.Generic;

namespace CareBridge.EFCoreDemo.Models.Generated;

public partial class BillingOnly
{
    public int ClaimId { get; set; }

    public int EncounterId { get; set; }

    public string Status { get; set; } = null!;

    public decimal BilledAmount { get; set; }

    public decimal? ReimbursedAmt { get; set; }

    public decimal? OutstandingAmount { get; set; }
}
