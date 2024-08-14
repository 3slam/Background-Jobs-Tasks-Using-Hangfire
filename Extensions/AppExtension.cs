using Serilog;
using Serilog.Formatting.Json;
namespace Background_Jobs__Tasks__Using_Hangfire.Extensions
{
    public static class AppExtension
    {

        public static void SerilogConfig(this IHostBuilder builder) 
        {
             builder.UseSerilog( ( context , config ) =>
             {
                 config.WriteTo.Console();
                  // , Rolling Daily
                 config.WriteTo.File( new JsonFormatter(),"Logs/appLogs.txt");
             });
        }
    }
}
