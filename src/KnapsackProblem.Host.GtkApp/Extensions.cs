using Gtk;

namespace KnapsackProblem.Host.GtkApp;

public static class Extensions
{
    public static void FillWithEnum<T>(this ComboBox comboBox) where T : Enum
    {
        comboBox.Model= ToListStore<T>();
        var textCell = new CellRendererText();
        comboBox.PackStart(textCell, true);
        comboBox.AddAttribute(textCell, "text", 1);
    }

    private static Dictionary<int, string> ToDictionary<T>() where T : Enum
        => Enum.GetValues(typeof(T)).Cast<int>().ToDictionary(e => e, e => Enum.GetName(typeof(T), e)!);

    private static ListStore ToListStore<T>() where T : Enum
    {
        var dictionary = ToDictionary<T>();
        var store = new ListStore(typeof(int), typeof(string));

        foreach (var item in dictionary)
            store.AppendValues(item.Key, item.Value);

        return store;
    }

    public static void ShowErrorDialog(this Exception exception)
        => GtkHelper.ShowErrorDialog(exception.Message);
}
