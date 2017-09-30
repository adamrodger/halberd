namespace Halberd.AspNetCore
{
    using Halberd.Definition;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;

    public static class HalberdAppliationBuilderExtensions
    {
        /// <summary>
        /// Use Halberd in the request pipeline
        /// </summary>
        /// <param name="app">Application builder</param>
        /// <returns>Same application builder</returns>
        public static IApplicationBuilder UseHalberd(this IApplicationBuilder app)
        {
            var linkPolicies = app.ApplicationServices.GetServices<ILinkDefinitionPolicy>();
            var definitionRepository = app.ApplicationServices.GetRequiredService<ILinkDefinitionRepository>();

            definitionRepository.Populate(linkPolicies);

            return app;
        }
    }
}
