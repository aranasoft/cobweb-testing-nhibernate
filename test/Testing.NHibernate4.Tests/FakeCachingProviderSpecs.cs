using System;
using System.Linq;
using Cobweb.Data.NHibernate.Caching;
using Cobweb.Data.NHibernate.Providers;
using Cobweb.Data.NHibernate.Tests.Entities;
using Cobweb.Testing.NHibernate.Caching;
using FluentAssertions;
using Xunit;

namespace Cobweb.Testing.NHibernate.Tests {
    [Collection("CachingProvider")]
    public class FakeCachingProviderSpecs : IDisposable {
        private Func<ICachingProvider> _currentCacheProvider;

        public FakeCachingProviderSpecs() {
            _currentCacheProvider = CachingProvider.Current;
            CachingProvider.Current = () => new FakeCachingProvider();
        }

        public void Dispose() {
            CachingProvider.Current = _currentCacheProvider;
        }

        [Fact]
        public void ItShouldNotThrowOnCacheableWithFakeCachingProviderCall() {
            Action act = () => Enumerable.Empty<RootEntity>().AsQueryable().Cacheable().FirstOrDefault();

            act.Should().NotThrow<InvalidOperationException>();
        }
    }
}
