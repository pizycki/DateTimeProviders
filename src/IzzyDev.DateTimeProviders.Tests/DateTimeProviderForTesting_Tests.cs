using System;
using Shouldly;
using Xunit;

namespace IzzyDev.DateTimeProviders.Tests
{
    public class DateTimeProviderForTesting_Tests
    {
        /// <summary>
        /// System Under Test
        /// </summary>
        private readonly IDateTimeProvider _provider;

        /// <summary>
        /// Test current date time.
        /// </summary>
        private DateTime CurrentDateTime { get; } = new DateTime(2000, 6, 20);

        public DateTimeProviderForTesting_Tests()
        {
            _provider = new DateTimeProviderForTesting(CurrentDateTime);
        }

        [Fact]
        public void Now_property_returns_TestCurrentDateTime()
        {
            _provider.Now.ShouldBe(CurrentDateTime);
        }

        [Fact]
        public void NowUtc_property_returns_TestCurrentDateTime()
        {
            _provider.UtcNow.ShouldBe(CurrentDateTime.ToUniversalTime());
        }

        [Fact]
        public void Today_property_returns_TestCurrentDateTime()
        {
            _provider.Today.ShouldBe(CurrentDateTime.Date);
        }
    }

}
