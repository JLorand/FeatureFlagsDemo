namespace FeatureFlagsDemo.Features.VATCalculation;

public interface IVATCalculationFeature
{
    Task<bool> IsEnabled();
}