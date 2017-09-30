namespace Halberd.Generation
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Halberd.Definition;

    /// <summary>
    /// Link generator
    /// </summary>
    public interface ILinkGenerator
    {
        /// <summary>
        /// Apply links to the given resource
        /// </summary>
        /// <param name="definitions">Link definitions for the resource</param>
        /// <param name="resource">Resource</param>
        /// <returns>Awaitable task</returns>
        Task ApplyAsync(ICollection<LinkDefinition> definitions, ILinkResource resource);
    }
}