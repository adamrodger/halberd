namespace Halberd.AspNetCore
{
    using Halberd.Definition;
    using Halberd.Generation;
    using Microsoft.AspNetCore.Mvc.Infrastructure;
    using Microsoft.AspNetCore.Mvc.Routing;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Halberd extension methods for <see cref="IServiceCollection" />
    /// </summary>
    public static class HalberdMvcBuilderExtensions
    {
        /// <summary>
        /// Add Halberd-related services
        /// </summary>
        /// <param name="services">Service collection</param>
        /// <returns>Same service collection</returns>
        internal static IServiceCollection AddHalberd(this IServiceCollection services)
        {
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
            services.AddSingleton<IUrlHelperFactory, UrlHelperFactory>();

            services.AddSingleton<ILinkDefinitionRepository, LinkDefinitionRepository>();
            services.AddSingleton<IHrefGenerator, HrefGenerator>();
            services.AddSingleton<ILinkGenerator, LinkGenerator>();

            return services;
        }

        /// <summary>
        /// Add Halberd to the MVC generation pipeline to enable automatic link generation
        /// </summary>
        /// <param name="builder">MVC builder</param>
        /// <returns>Same MVC builder</returns>
        public static IMvcBuilder AddHalberd(this IMvcBuilder builder)
        {
            builder.AddMvcOptions(options => options.Filters.Add<HalberdActionFilter>())
                   .Services.AddHalberd();

            return builder;
        }
    }
}
