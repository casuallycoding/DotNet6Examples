using System.Runtime.CompilerServices;
using System.Text;

namespace DotNet6Examples.InterpolatedStringHandler;

[InterpolatedStringHandler]
public ref struct LogInterpolatedStringHandler
{
    // Storage for the built-up string
    StringBuilder builder;

    // Add the receiver argument:
    public LogInterpolatedStringHandler(int literalLength, int formattedCount)
    {
        builder = new StringBuilder(literalLength);
        Console.WriteLine($"\tliteral length: {literalLength}, formattedCount: {formattedCount}");
    }

    public void AppendLiteral(string s)
    {
        Console.WriteLine($"\tAppendLiteral called: {{{s}}}");
        builder.Append(s);
    }

    public void AppendFormatted<T>(T t)
    {
        Console.WriteLine($"\tAppendFormatted called: {{{t}}} is of type {typeof(T)}");
        builder.Append(t?.ToString());
    }

    internal string GetFormattedText() => builder.ToString();
}





public class InterpolatedStringHandlerExample : IExampleInterface
{
    public void Run()
    {
        var logger = new Logger() { EnabledLevel = LogLevel.Warning };
        var time = DateTime.Now;

        logger.LogMessage(LogLevel.Error, $"Error Level. CurrentTime: {time}. This is an error. It will be printed.");
        logger.LogMessage(LogLevel.Trace, $"Trace Level. CurrentTime: {time}. This won't be printed.");
        //logger.LogMessage(LogLevel.Warning, "Warning Level. This warning is a string, not an interpolated string expression.");
    }
}



public enum LogLevel
{
    Off,
    Critical,
    Error,
    Warning,
    Information,
    Trace
}

public class Logger
{
    public LogLevel EnabledLevel { get; init; } = LogLevel.Error;

    public void LogMessage(LogLevel level, string msg)
    {
        if (EnabledLevel < level) return;
        Console.WriteLine(msg);
    }

    public void LogMessage(LogLevel level, LogInterpolatedStringHandler builder)
    {
        if (EnabledLevel < level) return;
        Console.WriteLine(builder.GetFormattedText());
    }
}


