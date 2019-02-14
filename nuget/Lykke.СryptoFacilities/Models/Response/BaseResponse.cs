using System;
using Common;

namespace Lykke.СryptoFacilities.Models.Response
{
    public class BaseResponse
    {
        public string Result { get; set; }
        public DateTime ServerTime { get; set; }
        public string Error { get; set; }

        public override string ToString()
        {
            return this.ToJson();
        }
    }
}
