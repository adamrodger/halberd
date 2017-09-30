namespace Halberd.Definition
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Link definition builder
    /// </summary>
    public class LinkDefinitionBuilder<TResource> where TResource : ILinkResource
    {
        private readonly ICollection<LinkDefinition> definitions;

        /// <summary>
        /// Initialises a new instance of the <see cref="LinkDefinitionBuilder{TResource}"/> class.
        /// </summary>
        public LinkDefinitionBuilder()
        {
            this.definitions = new List<LinkDefinition>();
        }

        /// <summary>
        /// Create a link definition to a named route
        /// </summary>
        /// <param name="rel">Rel label</param>
        /// <param name="routeName">Route name</param>
        /// <returns>Same link definition builder</returns>
        public LinkDefinitionBuilder<TResource> FromRoute(string rel, string routeName)
        {
            definitions.Add(new LinkDefinition
            {
                Rel = rel,
                RouteName = routeName
            });

            return this;
        }

        /// <summary>
        /// Create a link definition to a named route
        /// </summary>
        /// <param name="rel">Rel label</param>
        /// <param name="routeName">Route name</param>
        /// <param name="routeArgs">Arguments for formatting the route</param>
        /// <returns>Same link definition builder</returns>
        public LinkDefinitionBuilder<TResource> FromRoute(string rel, string routeName, Func<TResource, dynamic> routeArgs)
        {
            definitions.Add(new LinkDefinition
            {
                Rel = rel,
                RouteName = routeName,
                RouteValues = resource => routeArgs((TResource)resource)
            });

            return this;
        }

        /// <summary>
        /// Build the registered definitions
        /// </summary>
        /// <returns>Link definitions</returns>
        public ICollection<LinkDefinition> Build()
        {
            return this.definitions;
        }
    }
}
