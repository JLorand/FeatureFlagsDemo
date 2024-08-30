using Microsoft.FeatureManagement;

namespace FeatureFlagsDemo.Features.VATCalculation;

public class VATCalculationFeature(
    IFeatureManager featureManager)
    : IVATCalculationFeature
{
    public async Task<bool> IsEnabled()
    {
        return await featureManager.IsEnabledAsync(Features.FeatureFlags.Flags.VATCalculation);
    }
}