using System;
using System.Collections.Generic;

namespace Halberd.Definition
{
    /// <summary>
    /// Link definition repository
    /// </summary>
    public interface ILinkDefinitionRepository
    {
        /// <summary>
        /// Populate the repository from the given link definition policies
        /// </summary>
        /// <param name="policies">Applicable policies</param>
        void Populate(IEnumerable<ILinkDefinitionPolicy> policies);

        /// <summary>
        /// Get the link definitions for the given resource type
        /// </summary>
        /// <typeparam name="TResource">Resource type</typeparam>
        /// <returns>Matching link definitions</returns>
        /// <exception cref="KeyNotFoundException">Resource type has no matching definitions</exception>
        ICollection<LinkDefinition> Get<TResource>() where TResource : ILinkResource;

        /// <summary>
        /// Get the link definitions for the given resource type
        /// </summary>
        /// <param name="resourceType">Resource type</param>
        /// <returns>Matching link definitions</returns>
        /// <exception cref="KeyNotFoundException">Resource type has no matching definitions</exception>
        /// <exception cref="InvalidOperationException">Type is not a resource type</exception>
        ICollection<LinkDefinition> Get(Type resourceType);
    }
}