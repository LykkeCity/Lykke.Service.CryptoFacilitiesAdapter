using JetBrains.Annotations;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Lykke.CryptoFacilities.Models.Common
{
    /// <summary>
    /// The classification of the fill.
    /// </summary>
    [UsedImplicitly(ImplicitUseTargetFlags.WithMembers)]
    public static class FillType
    {
        /// <summary>
        /// User has a limit order that gets filled.
        /// </summary>
        public const string Maker = "maker";

        /// <summary>
        /// User makes an execution that crosses the spread.
        /// </summary>
        public const string Taker = "taker";
        
        /// <summary>
        /// Execution is result of a liquidation.
        /// </summary>
        public const string Liquidation = "liquidation";

        /// <summary>
        /// Execution is a result of a counterparty receiving an Assignment in PAS.
        /// </summary>
        public const string Assignee = "assignee";

        /// <summary>
        /// Execution is a result of user assigning their position due to failed liquidation.
        /// </summary>
        public const string Assignor = "assignor";
    }
}
