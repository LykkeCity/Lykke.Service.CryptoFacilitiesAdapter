using JetBrains.Annotations;

namespace Lykke.CryptoFacilities.Models.Common
{
    /// <summary>
    /// The type of the instrument.
    /// </summary>
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public static class InstrumentType
    {
        /// <summary>
        /// Futures inverse.
        /// </summary>
        public const string FuturesInverse = "futures_inverse";
        
        /// <summary>
        /// Futures vanilla.
        /// </summary>
        public const string FuturesVanilla = "futures_vanilla";
        
        /// <summary>
        /// Turbo inverse.
        /// </summary>
        public const string TurboInverse = "turbo_inverse";
        
        /// <summary>
        /// Spot index.
        /// </summary>
        public const string SpotIndex = "spot index";
        
        /// <summary>
        /// Volatility index.
        /// </summary>
        public const string VolatilityIndex = "volatility index";
    }
}
