using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serialization
{
    /// <summary>
    /// A Helper for json operations
    /// </summary>
    public class JsonSerializer
    {
        public static JsonSerializerSettings GetDefaultJsonSerializerSettings()
        {
            var jsonSerializerSettings = new JsonSerializerSettings();
            jsonSerializerSettings.NullValueHandling = NullValueHandling.Ignore;
            jsonSerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;
            return jsonSerializerSettings;
        }
        /// <summary>
        /// Convert given complex type to json string
        /// </summary>
        /// <typeparam name="T">Complex Object Type</typeparam>
        /// <param name="input">Complex Object</param>
        /// <returns>Json string of given complex object</returns>
        public static string Serialize<T>(T input)
        {
            return JsonConvert.SerializeObject(input, GetDefaultJsonSerializerSettings());
        }
        /// <summary>
        /// Convert given json string to complex object
        /// </summary>
        /// <typeparam name="T">Type of complex object</typeparam>
        /// <param name="value">Json string value</param>
        /// <returns>Complex object with given type</returns>
        public static T Deserialize<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }
    }
}
