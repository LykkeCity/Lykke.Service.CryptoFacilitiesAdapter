using System.Collections.Concurrent;
using System.Globalization;
using System.Linq;

namespace Lykke.СryptoFacilities.WebSockets
{
    public static class ConcurrentDictionaryHelper
    {
        public static bool ContainsKeyIgnoreCase(this ConcurrentDictionary<string, bool> dict, string key,
            out string realKey)
        {
            var item = dict.Keys.FirstOrDefault(x => string.Compare(x, key, true, CultureInfo.InvariantCulture) == 0);

            if (item == null)
            {
                realKey = null;
                return false;
            }
            else
            {
                realKey = item;
                return true;
            }
        }
    }
}
