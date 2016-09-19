using System;

namespace IzzyDev.DateTimeProviders
{
    /* Copied from static System.DateTime
     * Assembly mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
     * C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.6\mscorlib.dll
     */
    public interface IDateTimeProvider
    {
        //
        // Summary:
        //     Gets a System.DateTime object that is set to the current date and time on this
        //     computer, expressed as the local time.
        //
        // Returns:
        //     An object whose value is the current local date and time.
        DateTime Now { get; }
        //
        // Summary:
        //     Gets the current date.
        //
        // Returns:
        //     An object that is set to today's date, with the time component set to 00:00:00.
        DateTime Today { get; }
        //
        // Summary:
        //     Gets a System.DateTime object that is set to the current date and time on this
        //     computer, expressed as the Coordinated Universal Time (UTC).
        //
        // Returns:
        //     An object whose value is the current UTC date and time.
        DateTime UtcNow { get; }
    }
}