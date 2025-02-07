using Serilog.Core;
using Spectre.Console.Cli;

namespace Spectre.Console.Examples;

public class LogInterceptor : ICommandInterceptor
{
    public static readonly LoggingLevelSwitch LogLevel = new();

    public void Intercept(CommandContext context, CommandSettings settings)
    {
        if (settings is LogCommandSettings logSettings)
        {
            LoggingEnricher.Path = logSettings.LogFile ?? "application.log";
            LogLevel.MinimumLevel = logSettings.LogLevel;
        }
    }
}
