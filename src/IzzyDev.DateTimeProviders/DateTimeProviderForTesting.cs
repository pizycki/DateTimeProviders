using System;

namespace IzzyDev.DateTimeProviders
{
    /// <summary>
    /// Configurable DateTime provider designed for Unit and Integration testing.
    /// </summary>
    public class DateTimeProviderForTesting : IDateTimeProvider
    {
        /// <summary>
        /// Creates provider.
        /// </summary>
        /// <param name="current">Actual date and time.</param>
        public DateTimeProviderForTesting(DateTime current)
        {
            Current = current;
        }

        /// <summary>
        /// Holds current date and time.
        /// </summary>
        public DateTime Current { get; }

        public DateTime Now => Current;
        public DateTime Today => Current.Date;
        public DateTime UtcNow => Current.ToUniversalTime();
    }
}