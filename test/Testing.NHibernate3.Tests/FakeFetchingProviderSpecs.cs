using System;
using System.Linq;
using Cobweb.Data.NHibernate.Fetching;
using Cobweb.Data.NHibernate.Providers;
using Cobweb.Data.NHibernate.Tests.Entities;
using Cobweb.Testing.NHibernate.Fetching;
using FluentAssertions;
using Xunit;

namespace Cobweb.Testing.NHibernate.Tests {
    [Collection("FetchingProvider")]
    public class FakeFetchingProviderSpecs : IDisposable {
        private readonly Func<IFetchingProvider> _currentFetchProvider;
        
        public FakeFetchingProviderSpecs() {
            _currentFetchProvider = EagerFetch.Current;
            EagerFetch.Current = () => new FakeFetchingProvider();
        }

        public void Dispose() {
            EagerFetch.Current = _currentFetchProvider;
        }

        [Fact]
        public void ItShouldNotThrowOnFetchWithFakeFetchingProviderCall() {
            Action act = () => EagerFetch.Fetch(Enumerable.Empty<RootEntity>().AsQueryable(), root => root.Child).FirstOrDefault();

            act.Should().NotThrow<InvalidOperationException>();
        }

        [Fact]
        public void ItShouldNotThrowOnFetchManyWithFakeFetchingProviderCall() {
            Action act = () => EagerFetch.FetchMany(Enumerable.Empty<RootEntity>().AsQueryable(), root => root.Children).FirstOrDefault();

            act.Should().NotThrow<InvalidOperationException>();
        }
        
        [Fact]
        public void ItShouldNotThrowOnThenFetchWithFakeFetchingProviderCall() {
            Action act = () => EagerFetch.ThenFetch(Enumerable.Empty<RootEntity>().AsQueryable().Fetch(root => root.Child), child => child.Parent).FirstOrDefault();

            act.Should().NotThrow<InvalidOperationException>();
        }

        [Fact]
        public void ItShouldNotThrowOnThenFetchManyWithFakeFetchingProviderCall() {
            Action act = () => EagerFetch.ThenFetchMany(Enumerable.Empty<RootEntity>().AsQueryable().FetchMany(root => root.Children), child => child.Parents).FirstOrDefault();

            act.Should().NotThrow<InvalidOperationException>();
        }
    }
}
