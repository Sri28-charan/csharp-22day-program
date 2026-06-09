using System;
using System.Collections.Generic;

namespace CareBridge.EFCoreDemo.Models.Generated;

public partial class VwClinical
{
    public int EncounterId { get; set; }

    public string PatientName { get; set; } = null!;

    public string Gender { get; set; } = null!;

    public string EncounterType { get; set; } = null!;

    public int? DiagnosisId { get; set; }

    public string? IcdCode { get; set; }

    public string? DiagnosisDescription { get; set; }
}
