using KnapsackProblem.Host.GtkApp.Windows;
using GtkApplication = Gtk.Application;

namespace KnapsackProblem.Host.GtkApp;

public class Startup
{
    private readonly MainWindow _mainWindow;

    public Startup(MainWindow mainWindow)
    {
        _mainWindow = mainWindow;
    }

    public void Run()
    {
        var app = new GtkApplication("org.KnapsackProblem.Host.GtkApp.KnapsackProblem.Host.GtkApp", GLib.ApplicationFlags.None);
        app.Register(GLib.Cancellable.Current);

        app.AddWindow(_mainWindow);
        _mainWindow.Show();

        GtkApplication.Run();
    }
}
