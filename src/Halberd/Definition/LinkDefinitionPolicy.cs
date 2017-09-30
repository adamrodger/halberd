using System;
using System.Collections.Generic;

namespace Halberd.Definition
{
    /// <summary>
    /// Base strongly-typed helper class for link definition policies
    /// </summary>
    /// <typeparam name="TResource">Type of the resource</typeparam>
    public abstract class LinkDefinitionPolicy<TResource> : ILinkDefinitionPolicy where TResource : ILinkResource
    {
        /// <summary>
        /// Type of the resource
        /// </summary>
        public Type ResourceType => typeof(TResource);

        /// <summary>
        /// Generate link definitions
        /// </summary>
        /// <returns>Link definitions for the resource</returns>
        public abstract ICollection<LinkDefinition> GetDefinitions();
    }
}
