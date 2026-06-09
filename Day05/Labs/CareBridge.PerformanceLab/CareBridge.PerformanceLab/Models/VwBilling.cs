using System;
using System.Collections.Generic;

namespace CareBridge.PerformanceLab.Models;

public partial class VwBilling
{
    public int ClaimId { get; set; }

    public int EncounterId { get; set; }

    public string Payer { get; set; } = null!;

    public string PolicyNumber { get; set; } = null!;

    public decimal BilledAmount { get; set; }

    public decimal? ReimbursedAmt { get; set; }

    public string ClaimStatus { get; set; } = null!;
}
