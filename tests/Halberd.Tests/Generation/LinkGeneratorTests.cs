namespace Halberd.Tests.Generation
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using FluentAssertions;
    using Halberd.Definition;
    using Halberd.Generation;
    using Moq;
    using Xunit;

    public class LinkGeneratorTests
    {
        private LinkGenerator generator;

        private IList<LinkDefinition> definitions;
        private Mock<IHrefGenerator> mockHrefGenerator;
        private ILinkResource resource;

        public LinkGeneratorTests()
        {
            this.definitions = new[]
            {
                new LinkDefinition { Rel = "self", RouteName = "SelfRoute" },
                new LinkDefinition { Rel = "all", RouteName = "AllRoute" }
            };

            this.resource = new TestResource();

            this.mockHrefGenerator = new Mock<IHrefGenerator>();
            this.mockHrefGenerator.Setup(g => g.GenerateAsync(resource, this.definitions[0])).ReturnsAsync("/api/test/1");
            this.mockHrefGenerator.Setup(g => g.GenerateAsync(resource, this.definitions[1])).ReturnsAsync("/api/tests");

            this.generator = new LinkGenerator(this.mockHrefGenerator.Object);
        }

        [Fact]
        public async Task ApplyAsync_WhenCalled_AddsAllLinks()
        {
            var expected = new Dictionary<string, Link>
            {
                ["self"] = new Link { Rel = "self", Href = "/api/test/1" },
                ["all"] = new Link { Rel = "all", Href = "/api/tests" }
            };

            await this.generator.ApplyAsync(this.definitions, this.resource);

            this.resource.Links.ShouldAllBeEquivalentTo(expected);
        }
    }
}
