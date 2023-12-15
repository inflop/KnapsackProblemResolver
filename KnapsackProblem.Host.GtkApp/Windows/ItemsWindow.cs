using Gtk;
using UI = Gtk.Builder.ObjectAttribute;

namespace KnapsackProblem.Host.GtkApp.Windows;

class ItemsWindow : Dialog
{
    [UI] private ListStore? _lsItems = null;
    [UI] private TreeView? _tvItems = null;
    [UI] private Button? _btnPreviewOK = null;

    private IEnumerable<Core.Item> _items = [];

    public ItemsWindow() : this(new Builder("gui.glade"))
    {
        Initialize();
    }

    private ItemsWindow(Builder builder) : base(builder.GetRawOwnedObject("ItemsWindow"))
    {
        builder.Autoconnect(this);
        DefaultResponse = ResponseType.Cancel;

        Response += (o, args) => Destroy();
        _btnPreviewOK!.Clicked += (o, args) => Destroy();
    }

    public void LoadItems(IEnumerable<Core.Item> items)
    {
        _items = items;
        _lsItems!.Clear();

        foreach (var item in items)
            _lsItems.AppendValues(item.Value, item.Weight);
        
        _tvItems!.Model = _lsItems;
    }

    private void Initialize()
    {
        Title = "Input items";
        InitializeTreeView();
    }

    private void InitializeTreeView()
    {
        AddColumn("Value", 0);
        AddColumn("Weight", 1);
    }

    private void AddColumn(string title, int columnId)
        => _tvItems!.AppendColumn(new TreeViewColumn(title, new CellRendererText(), "text", columnId)
            {
                Resizable = true,
                Expand = true,
                SortColumnId = columnId
            });
}
