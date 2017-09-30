namespace Halberd.Example.AspNetCore.Models
{
    using System.Collections.Generic;

    public class CarModel : ILinkResource
    {
        public string Registration { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public ushort Year { get; set; }

        public IDictionary<string, Link> Links { get; private set; } = new Dictionary<string, Link>();
    }
}
