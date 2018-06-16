using System;
using System.Linq;
using Cobweb.Data.NHibernate.Providers;
using Cobweb.Data.NHibernate.Tests.Entities;
using FluentAssertions;
using Xunit;

namespace Cobweb.Testing.NHibernate.Tests {
    [Collection("FetchingProvider")]
    public class FetchingProviderSpecs {
        [Fact]
        public void ItShouldThrowOnFetchWithFetchingProviderCall() {
            Action act = () => EagerFetch.Fetch(Enumerable.Empty<RootEntity>().AsQueryable(), root => root.Child).FirstOrDefault();

            act.Should()
               .Throw<InvalidOperationException>()
               .WithMessage(
                   "There is no method 'Fetch' on type 'NHibernate.Linq.EagerFetchingExtensionMethods' that matches the specified arguments");
        }

        [Fact]
        public void ItShouldThrowOnFetchManyWithFetchingProviderCall() {
            Action act = () => EagerFetch.FetchMany(Enumerable.Empty<RootEntity>().AsQueryable(), root => root.Children).FirstOrDefault();

            act.Should()
               .Throw<InvalidOperationException>()
               .WithMessage(
                   "There is no method 'FetchMany' on type 'NHibernate.Linq.EagerFetchingExtensionMethods' that matches the specified arguments");
        }
    }
}
