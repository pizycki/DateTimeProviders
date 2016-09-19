using System;

namespace IzzyDev.DateTimeProviders
{
    /// <summary>
    /// Wrapper for static class System.DateTime.
    /// </summary>
    public class DateTimeWrapper : IDateTimeProvider
    {
        public DateTime Now => DateTime.Now;
        public DateTime Today => DateTime.Today;
        public DateTime UtcNow => DateTime.UtcNow;
    }
}
