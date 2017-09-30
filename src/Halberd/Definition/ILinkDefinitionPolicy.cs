namespace Halberd.Definition
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Defines link definitions for a particular resource
    /// </summary>
    public interface ILinkDefinitionPolicy
    {
        /// <summary>
        /// Type of the resource
        /// </summary>
        Type ResourceType { get; }

        /// <summary>
        /// Generate link definitions
        /// </summary>
        /// <returns>Link definitions for the resource</returns>
        ICollection<LinkDefinition> GetDefinitions();
    }
}
