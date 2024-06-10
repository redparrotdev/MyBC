using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBC.App.Extentions
{
    public static class SerilogExtentions
    {
        public static MauiAppBuilder UseSerilog(this MauiAppBuilder builder)
        {
            var logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.File(Path.Combine(FileSystem.AppDataDirectory, "log.txt"), rollingInterval: RollingInterval.Day)
                .CreateLogger();

            builder.Services.AddSerilog(logger);

            return builder;
        }
    }
}
