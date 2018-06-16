using System;
using System.Linq;
using Cobweb.Data.NHibernate.Providers;
using Cobweb.Data.NHibernate.Tests.Entities;
using FluentAssertions;
using Xunit;

namespace Cobweb.Testing.NHibernate.Tests {
    [Collection("CachingProvider")]
    public class CachingProviderSpecs {
        [Fact]
        public void ItShouldThrowOnCacheableWithCachingProviderCall() {
            Action act = () => CachingProvider.Cacheable(Enumerable.Empty<RootEntity>().AsQueryable()).FirstOrDefault();

            act.Should()
               .Throw<InvalidOperationException>()
               .WithMessage(
                   "There is no method 'Cacheable' on type 'NHibernate.Linq.LinqExtensionMethods' that matches the specified arguments");
        }
    }
}
