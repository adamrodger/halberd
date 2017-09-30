namespace Halberd.Tests
{
    using System.Collections.Generic;

    public class TestResource : ILinkResource
    {
        public int Id { get; set; }

        public IDictionary<string, Link> Links { get; private set; } = new Dictionary<string, Link>();
    }
}
