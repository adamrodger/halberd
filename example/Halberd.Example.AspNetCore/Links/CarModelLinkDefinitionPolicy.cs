namespace Halberd.Example.AspNetCore.Links
{
    using System.Collections.Generic;
    using Halberd.Definition;
    using Halberd.Example.AspNetCore.Models;

    public class CarModelLinkDefinitionPolicy : LinkDefinitionPolicy<CarModel>
    {
        public override ICollection<LinkDefinition> GetDefinitions()
        {
            LinkDefinitionBuilder<CarModel> builder = new LinkDefinitionBuilder<CarModel>();

            return builder.FromRoute("self", "GetCarDetails", resource => (new { id = resource.Registration }))
                          .FromRoute("all", "GetAllCars")
                          .Build();
        }
    }
}
