namespace Halberd.Tests.Definition
{
    using System;
    using FluentAssertions;
    using Halberd.Definition;
    using Xunit;

    public class LinkDefinitionBuilderTests
    {
        private readonly LinkDefinitionBuilder<TestResource> builder;

        public LinkDefinitionBuilderTests()
        {
            this.builder = new LinkDefinitionBuilder<TestResource>();
        }
        [Fact]
        public void FromRoute_WithoutRouteValues_AddsNamedRouteLink()
        {
            var expected = new[]
            {
                new LinkDefinition { Rel = "self", RouteName = "NamedRoute", RouteValues = null }
            };

            var actual = builder.FromRoute("self", "NamedRoute")
                                .Build();

            actual.ShouldAllBeEquivalentTo(expected);
        }

        [Fact]
        public void FromRoute_WithRouteValues_AddsNamedRouteLink()
        {
            Func<TestResource, dynamic> routeArgs = resource => new { id = resource.Id };
            var expected = new[]
            {
                new LinkDefinition
                {
                    Rel = "self",
                    RouteName = "NamedRoute",
                    RouteValues = resource => routeArgs((TestResource)resource)
                }
            };

            var actual = builder.FromRoute("self", "NamedRoute", routeArgs)
                                .Build();

            actual.ShouldAllBeEquivalentTo(expected, options => options.Excluding(d => d.RouteValues));
        }

        [Fact]
        public void FromRoute_MultipleCalls_AddsMultipleDefinitions()
        {
            var expected = new[]
            {
                new LinkDefinition { Rel = "self", RouteName = "SelfRoute", RouteValues = null },
                new LinkDefinition { Rel = "all", RouteName = "AllRoute", RouteValues = null }
            };

            var actual = builder.FromRoute("self", "SelfRoute")
                                .FromRoute("all", "AllRoute")
                                .Build();

            actual.ShouldAllBeEquivalentTo(expected);
        }
    }
}
