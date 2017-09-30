namespace Halberd.Generation
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Halberd.Definition;

    /// <summary>
    /// Applies defined link definitions to a given resource
    /// </summary>
    public class LinkGenerator : ILinkGenerator
    {
        private readonly IHrefGenerator hrefGenerator;

        /// <summary>
        /// Initialises a new instance of the <see cref="LinkGenerator{TResource}"/> class.
        /// </summary>
        /// <param name="hrefGenerator">Href generator</param>
        public LinkGenerator(IHrefGenerator hrefGenerator)
        {
            this.hrefGenerator = hrefGenerator;
        }

        /// <summary>
        /// Apply links to the given resource
        /// </summary>
        /// <param name="definitions">Link definitions for the resource</param>
        /// <param name="resource">Resource</param>
        /// <returns>Awaitable task</returns>
        public async Task ApplyAsync(ICollection<LinkDefinition> definitions, ILinkResource resource)
        {
            foreach (LinkDefinition definition in definitions)
            {
                resource.Links[definition.Rel] = new Link
                {
                    Rel = definition.Rel,
                    Href = await this.hrefGenerator.GenerateAsync(resource, definition)
                };
            }
        }
    }
}
