namespace Halberd
{
    using Newtonsoft.Json;

    /// <summary>
    /// Represents a HAL link
    /// </summary>
    public class Link
    {
        /// <summary>
        /// Link rel label
        /// </summary>
        [JsonIgnore]
        public string Rel { get; set; }

        /// <summary>
        /// Link href
        /// </summary>
        [JsonRequired]
        public string Href { get; set; }

        /// <summary>
        /// Link is templated
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool Templated { get; set; } = false;

        /// <summary>
        /// Link type
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Type { get; set; }

        /// <summary>
        /// Link is deprecated
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
        public bool Deprecation { get; set; } = false;

        /// <summary>
        /// Link name
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        /// <summary>
        /// Link profile
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Profile { get; set; }

        /// <summary>
        /// Link title
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        /// <summary>
        /// Link hreflang
        /// </summary>
        [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore, NullValueHandling = NullValueHandling.Ignore)]
        public string Hreflang { get; set; }
    }
}
