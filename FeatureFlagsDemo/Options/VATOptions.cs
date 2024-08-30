namespace FeatureFlagsDemo.Options;

public class VATOptions
{
    public const string Position = nameof(VATOptions);
    
    public decimal VATPercentage { get; init; }
}