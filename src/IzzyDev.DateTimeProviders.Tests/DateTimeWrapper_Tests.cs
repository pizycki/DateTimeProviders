using System;
using Shouldly;
using Xunit;

namespace IzzyDev.DateTimeProviders.Tests
{
    public class DateTimeWrapper_Tests
    {
        private readonly IDateTimeProvider _wrapper;

        public DateTimeWrapper_Tests()
        {
            _wrapper = new DateTimeWrapper();
        }

        [Fact]
        public void Now_property_returns_actual_DateTime_for_local_timezone()
        {
            _wrapper.Now.ShouldBe(DateTime.Now, TimeSpan.FromMilliseconds(ToleranceInMs));
        }

        [Fact]
        public void UtcNow_property_returns_actual_DateTime_for_UTC_timezone()
        {
            _wrapper.UtcNow.ShouldBe(DateTime.UtcNow, TimeSpan.FromMilliseconds(ToleranceInMs));
        }

        [Fact]
        public void Today_property_returns_TodayDate_for_local_timezone()
        {
            _wrapper.Today.ShouldBe(DateTime.Today, TimeSpan.FromMilliseconds(ToleranceInMs));
        }

        private static readonly long ToleranceInMs = 150L;
    }
}
