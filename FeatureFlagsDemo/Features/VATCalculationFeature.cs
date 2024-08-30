using Microsoft.FeatureManagement;

namespace FeatureFlagsDemo.Features;

public class VATCalculationFeature(
    IFeatureManager featureManager)
    : IVATCalculationFeature
{
    public async Task<bool> IsEnabled()
    {
        return await featureManager.IsEnabledAsync(Features.FeatureFlags.Features.VATCalculation);
    }
}

public interface IVATCalculationFeature
{
    Task<bool> IsEnabled();
}