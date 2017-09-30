namespace Halberd.Definition
{
    using System;
    using System.Collections.Generic;
    using System.Collections.Concurrent;

    /// <summary>
    /// Link definition repository
    /// </summary>
    public class LinkDefinitionRepository : ILinkDefinitionRepository
    {
        private readonly IDictionary<Type, ICollection<LinkDefinition>> definitions;

        /// <summary>
        /// Initialises a new instance of the <see cref="LinkDefinitionRepository"/> class.
        /// </summary>
        public LinkDefinitionRepository()
        {
            this.definitions = new ConcurrentDictionary<Type, ICollection<LinkDefinition>>();
        }

        /// <summary>
        /// Populate the repository from the given link definition policies
        /// </summary>
        /// <param name="policies">Applicable policies</param>
        public void Populate(IEnumerable<ILinkDefinitionPolicy> policies)
        {
            foreach (ILinkDefinitionPolicy policy in policies)
            {
                var definitions = policy.GetDefinitions();
                this.definitions[policy.ResourceType] = definitions;
            }
        }

        /// <summary>
        /// Get the link definitions for the given resource type
        /// </summary>
        /// <typeparam name="TResource">Resource type</typeparam>
        /// <returns>Matching link definitions</returns>
        /// <exception cref="KeyNotFoundException">Resource type has no matching definitions</exception>
        public ICollection<LinkDefinition> Get<TResource>() where TResource : ILinkResource
        {
            return this.definitions[typeof(TResource)];
        }

        /// <summary>
        /// Get the link definitions for the given resource type
        /// </summary>
        /// <param name="resourceType">Resource type</param>
        /// <returns>Matching link definitions</returns>
        /// <exception cref="KeyNotFoundException">Resource type has no matching definitions</exception>
        /// <exception cref="InvalidOperationException">Type is not a resource type</exception>
        public ICollection<LinkDefinition> Get(Type resourceType)
        {
            if (!typeof(ILinkResource).IsAssignableFrom(resourceType))
            {
                throw new InvalidOperationException($"Unrecognised resource type: {resourceType.FullName}");
            }

            return this.definitions[resourceType];
        }
    }
}
