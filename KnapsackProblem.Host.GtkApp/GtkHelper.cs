using Gtk;

namespace KnapsackProblem.Host.GtkApp;

public static class GtkHelper
{
    public static void ShowErrorDialog(string errorMsg, Window? parentWindow = null)
    {
        var dlg = new MessageDialog(parentWindow, DialogFlags.Modal, MessageType.Error, ButtonsType.Close, errorMsg);
        dlg.SetPosition(WindowPosition.CenterAlways);
        dlg.Title = "ERROR";
        dlg.Run();
        dlg.Destroy();
    }
}
