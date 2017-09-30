namespace Halberd.Tests.Definition
{
    using System;
    using System.Collections.Generic;
    using FluentAssertions;
    using Halberd.Definition;
    using Moq;
    using Xunit;

    public class LinkDefinitionRepositoryTests
    {
        private readonly LinkDefinitionRepository repository;

        private IEnumerable<ILinkDefinitionPolicy> policies;
        private Mock<ILinkDefinitionPolicy> mockPolicy1;
        private Mock<ILinkDefinitionPolicy> mockPolicy2;

        public LinkDefinitionRepositoryTests()
        {
            this.mockPolicy1 = new Mock<ILinkDefinitionPolicy>();
            this.mockPolicy1.Setup(p => p.ResourceType).Returns(typeof(TestResource));

            this.mockPolicy2 = new Mock<ILinkDefinitionPolicy>();
            this.mockPolicy2.Setup(p => p.ResourceType).Returns(new Mock<ILinkResource>().Object.GetType());

            this.policies = new[] { this.mockPolicy1.Object, this.mockPolicy2.Object };

            this.repository = new LinkDefinitionRepository();
        }

        [Fact]
        public void Populate_WhenCalled_CompilesEachPolicy()
        {
            this.repository.Populate(this.policies);

            this.mockPolicy1.Verify(p => p.GetDefinitions(), Times.Once);
            this.mockPolicy2.Verify(p => p.GetDefinitions(), Times.Once);
        }

        [Fact]
        public void Populate_WhenCalled_StoresGeneratedLinkDefinitions()
        {
            ICollection<LinkDefinition> expected = new[] { new LinkDefinition() };
            this.mockPolicy1.Setup(p => p.GetDefinitions()).Returns(expected);

            this.repository.Populate(this.policies);

            this.repository.Get<TestResource>().Should().BeSameAs(expected);
        }

        [Fact]
        public void Get_InvalidType_ThrowsInvalidOperationException()
        {
            this.repository.Populate(this.policies);

            Action action = () => this.repository.Get(typeof(int));

            action.ShouldThrow<InvalidOperationException>();
        }

        [Fact]
        public void Get_UnknownType_ThrowsKeyNotFoundException()
        {
            Action action = () => this.repository.Get(typeof(TestResource));

            action.ShouldThrow<KeyNotFoundException>("because the repository wasn't populated");
        }
    }
}
