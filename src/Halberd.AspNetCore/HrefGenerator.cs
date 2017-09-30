namespace Halberd.AspNetCore
{
    using System;
    using System.Threading.Tasks;
    using Halberd.Definition;
    using Halberd.Generation;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Routing;
    using Microsoft.AspNetCore.Mvc.Infrastructure;

    /// <summary>
    /// ASP.Net Core href generator
    /// </summary>
    public class HrefGenerator : IHrefGenerator
    {
        private static readonly Func<ILinkResource, dynamic> DefaultValues = r => null;

        private readonly IUrlHelperFactory urlHelperFactory;
        private readonly IActionContextAccessor actionContextAccessor;

        /// <summary>
        /// Initialises a new instance of the <see cref="HrefGenerator"/> class.
        /// </summary>
        /// <param name="urlHelperFactory">URL helper factory</param>
        /// <param name="actionContextAccessor">Action context accessor</param>
        public HrefGenerator(IUrlHelperFactory urlHelperFactory, IActionContextAccessor actionContextAccessor)
        {
            this.urlHelperFactory = urlHelperFactory;
            this.actionContextAccessor = actionContextAccessor;
        }

        /// <inheritdoc />
        public Task<string> GenerateAsync(ILinkResource resource, LinkDefinition definition)
        {
            Func<ILinkResource, dynamic> valuesFunc = definition.RouteValues ?? DefaultValues;
            object values = valuesFunc(resource) as object;

            ActionContext actionContext = actionContextAccessor.ActionContext;
            IUrlHelper helper = urlHelperFactory.GetUrlHelper(actionContext);
            string path = helper.RouteUrl(definition.RouteName, values);

            return Task.FromResult(path);
        }
    }
}
