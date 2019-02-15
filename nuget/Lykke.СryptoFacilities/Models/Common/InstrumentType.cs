using JetBrains.Annotations;

namespace Lykke.СryptoFacilities.Models.Common
{
    /// <summary>
    /// The type of the instrument.
    /// </summary>
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public static class InstrumentType
    {
        public const string FuturesInverse = "futures_inverse";
        
        public const string FuturesVanilla = "futures_vanilla";
        
        public const string TurboInverse = "turbo_inverse";
        
        public const string SpotIndex = "spot index";
        
        public const string VolatilityIndex = "volatility index";
    }
}
