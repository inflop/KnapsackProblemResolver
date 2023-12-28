using KnapsackProblem.Host.GtkApp.Windows;
using GtkApplication = Gtk.Application;

namespace KnapsackProblem.Host.GtkApp;

public class Startup(MainWindow mainWindow)
{
    public void Run()
    {
        var app = new GtkApplication("org.KnapsackProblem.Host.GtkApp.KnapsackProblem.Host.GtkApp", GLib.ApplicationFlags.None);
        app.Register(GLib.Cancellable.Current);

        app.AddWindow(mainWindow);
        mainWindow.Show();

        GtkApplication.Run();
    }
}
