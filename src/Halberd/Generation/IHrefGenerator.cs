namespace Halberd.Generation
{
    using System.Threading.Tasks;
    using Halberd.Definition;

    /// <summary>
    /// Generates a href
    /// </summary>
    public interface IHrefGenerator
    {
        /// <summary>
        /// Generate the href for the given resource from the given definition
        /// </summary>
        /// <typeparam name="TResource">Resource type</typeparam>
        /// <param name="resource">Resource</param>
        /// <param name="definition">Link definition for the resource</param>
        /// <returns>Href</returns>
        Task<string> GenerateAsync(ILinkResource resource, LinkDefinition definition);
    }
}
