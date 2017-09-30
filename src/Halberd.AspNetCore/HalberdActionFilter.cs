namespace Halberd.AspNetCore
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Halberd.Definition;
    using Halberd.Generation;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.AspNetCore.Mvc;

    /// <summary>
    /// Action filter for adding HAL links to applicable responses automatically
    /// </summary>
    public class HalberdActionFilter : IAsyncResultFilter
    {
        private readonly ILinkDefinitionRepository repository;
        private readonly ILinkGenerator generator;

        /// <summary>
        /// Initialises a new instance of the <see cref="HalberdActionFilter"/> class.
        /// </summary>
        /// <param name="repository">Link definition repository</param>
        /// <param name="generator">Link generator</param>
        public HalberdActionFilter(ILinkDefinitionRepository repository, ILinkGenerator generator)
        {
            this.repository = repository;
            this.generator = generator;
        }

        /// <summary>
        /// Called when the result has been calculated
        /// </summary>
        /// <param name="context">Result context</param>
        /// <param name="next">Next result filter</param>
        /// <returns>Awaitable task</returns>
        public async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            var result = context.Result as OkObjectResult;

            if (result != null)
            {
                await this.ApplyLinksAsync(result.Value);
            }
            
            await next();
        }

        /// <summary>
        /// Apply links to the given resource, or all resources if the object is a collection of resources
        /// </summary>
        /// <param name="value">Object on which to apply links</param>
        /// <returns>Awaitable task</returns>
        private async Task ApplyLinksAsync(object value)
        {
            if (value is ILinkResource)
            {
                var resource = value as ILinkResource;
                await this.ApplyLinksAsync(resource);
            }
            else if (value is IEnumerable)
            {
                var resources = ((IEnumerable)value).OfType<ILinkResource>();

                foreach (ILinkResource resource in resources)
                {
                    await this.ApplyLinksAsync(resource);
                }
            }
        }

        /// <summary>
        /// Applies links to the given resource
        /// </summary>
        /// <param name="resource">Resource</param>
        /// <returns>Awaitable task</returns>
        private async Task ApplyLinksAsync(ILinkResource resource)
        {
            ICollection<LinkDefinition> definitions = this.repository.Get(resource.GetType());

            await generator.ApplyAsync(definitions, resource);
        }
    }
}
