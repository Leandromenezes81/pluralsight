using System.Collections.Generic;
using NUnit.Framework;
using Shouldly;
using Store.Domain.Models;

namespace Store.Tests.Unit.DomainTests.RepositoryTests.StateRepositoryTests
{
    [TestFixture]
    public class When_getting_all_States : Given_a_StateRepository
    {
        private List<State> _models;

        protected override void When()
        {
            base.When();

            _models = SUT.GetAsync(AdminUserId).Result;
        }

        [Test]
        public void Then_multiple_States_are_returned()
        {
            _models.Count.ShouldBeGreaterThan(1);
        }
    }
}
