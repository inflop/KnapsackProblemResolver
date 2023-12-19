using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using KnapsackProblem.Application;
using GtkApplication = Gtk.Application;
using KnapsackProblem.Host.GtkApp.Windows;

namespace KnapsackProblem.Host.GtkApp;

class Program
{
    [STAThread]
    public static void Main(string[] args)
    {
        try
        {
            GtkApplication.Init();

            var host = CreateHost(args);
            var app = host.Services.GetService<Startup>();
            app!.Run();
        }
        catch(Exception ex)
        {
            ex.ShowErrorDialog();
        }
    }

    private static IHost CreateHost(string[] args)
        => new HostBuilder()
            .UseConsoleLifetime()
            .ConfigureLogging((_, loggingBuilder) =>
            {
                loggingBuilder.ClearProviders();
                loggingBuilder.AddConsole();
            })
            .ConfigureServices((_, services) =>
            {
                services.AddKnapsackProblemResolver();
                services.AddSingleton<MainWindow>();
                services.AddSingleton<Startup>();
            })
            .Build();
}