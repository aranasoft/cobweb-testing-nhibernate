using System;
using System.Linq;
using Cobweb.Data.NHibernate.Tests.Entities;
using FluentAssertions;
using NHibernate.Linq;
using Xunit;

namespace Cobweb.Testing.NHibernate.Tests {
    [Collection("FetchingProvider")]
    public class FetchSpecs {
        [Fact]
        public void ItShouldThrowOnFetchWithDirectFetchCall() {
            Action act = () => EagerFetchingExtensionMethods.Fetch(Enumerable.Empty<RootEntity>().AsQueryable(), root => root.Child).FirstOrDefault();

            act.Should()
               .Throw<InvalidOperationException>()
               .WithMessage(
                   "There is no method 'Fetch' on type 'NHibernate.Linq.EagerFetchingExtensionMethods' that matches the specified arguments");
        }

        [Fact]
        public void ItShouldThrowOnFetchManyWithDirectFetchCall() {
            Action act = () => EagerFetchingExtensionMethods.FetchMany(Enumerable.Empty<RootEntity>().AsQueryable(), root => root.Children).FirstOrDefault();

            act.Should()
               .Throw<InvalidOperationException>()
               .WithMessage(
                   "There is no method 'FetchMany' on type 'NHibernate.Linq.EagerFetchingExtensionMethods' that matches the specified arguments");
        }
    }
}
