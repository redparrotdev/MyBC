using Microsoft.Extensions.Logging;
using MyBC.App.Extentions;

namespace MyBC.App
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

/*#if DEBUG
    		builder.Logging.AddDebug();
#endif*/

            builder.UseSerilog();
            builder.UseFirebaseAuth();
            builder.AddMVVM();

            return builder.Build();
        }
    }
}
