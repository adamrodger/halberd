namespace Halberd
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// A resource contains HAL links
    /// </summary>
    public interface ILinkResource
    {
        /// <summary>
        /// HAL links
        /// </summary>
        [JsonProperty("_links")]
        IDictionary<string, Link> Links { get; }
    }
}
