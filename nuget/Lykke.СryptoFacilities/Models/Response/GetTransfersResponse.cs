using System;
using Lykke.СryptoFacilities.Models.Common;
using Newtonsoft.Json;

namespace Lykke.СryptoFacilities.Models.Response
{
    public class GetTransfersResponse : BaseResponse
    {
        /// <summary>
        /// A list containing structures with information on the account’s transfer history. he list is sorted descending by ReceivedTime.
        /// </summary>
        [JsonProperty("transfers")]
        public Transfer[] Transfers { set; get; }
    }

    public class Transfer
    {
        /// <summary>
        /// If transferType is deposit: The date and time the deposit was first detected.
        /// If transferType is withdrawal: The date and time the withdrawal request was received.
        /// </summary>
        [JsonProperty("receivedTime")]
        public DateTime ReceivedTime { set; get; }
        
        /// <summary>
        /// If status is processed: The date and time the transfer has been processed and booked.
        /// If status is pending: Not returned because N/A.
        /// </summary>
        [JsonProperty("completedTime")]
        public DateTime? CompletedTime { set; get; }
        
        /// <summary>
        /// The status of the transfer request.
        /// </summary>
        [JsonProperty("status")]
        public TransferStatus Status { set; get; }
        
        /// <summary>
        /// The unique identifier of the transfer.
        /// </summary>
        [JsonProperty("transfer_id")]
        public string TransferId { set; get; }
        
        /// <summary>
        /// If status is processed: The blockchain transaction id of the transfer if the transfer involves an external digital asset address and Internal Transaction if the transaction is sent to an address controlled by Crypto Facilities.
        /// If status is pending: Not returned because N/A.
        /// </summary>
        [JsonProperty("transaction_id")]
        public string TransactionId { set; get; }
        
        /// <summary>
        /// The digital asset address to which the transfer is sent.
        /// </summary>
        [JsonProperty("targetAddress")]
        public string TargetAddress { set; get; }
        
        /// <summary>
        /// The type of the transfer, either deposit or withdrawal.
        /// </summary>
        [JsonProperty("transferType")]
        public TransferType Type { set; get; }
        
        /// <summary>
        /// The digital asset amount that was transferred. Positive for deposits and negative for withdrawals.
        /// </summary>
        [JsonProperty("amount")]
        public decimal Amount { set; get; }
    }
}
