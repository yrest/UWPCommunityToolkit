﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace Microsoft.Toolkit.Uwp.Services.LinkedIn
{
    /// <summary>
    /// Parse results into strong type.
    /// </summary>
    /// <typeparam name="T">Type to parse into.</typeparam>
    public class LinkedInParser<T>
    {
        /// <summary>
        /// Take string data and parse into strong data type.
        /// </summary>
        /// <param name="data">String data.</param>
        /// <returns>Returns strong type.</returns>
        public IEnumerable<T> Parse(string data)
        {
            List<T> results;

            try
            {
                results = JsonConvert.DeserializeObject<List<T>>(data);
            }
            catch (JsonSerializationException)
            {
                T linkedInResult = JsonConvert.DeserializeObject<T>(data);
                results = new List<T> { linkedInResult };
            }

            return results;
        }
    }
}
