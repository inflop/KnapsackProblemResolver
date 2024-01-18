using Gtk;
using UI = Gtk.Builder.ObjectAttribute;
using GtkApplication = Gtk.Application;
using KnapsackProblem.Core.Enums;
using KnapsackProblem.Core.Abstractions;
using KnapsackProblem.Core;

namespace KnapsackProblem.Host.GtkApp.Windows;

public class MainWindow : Window
{
    [UI] private Adjustment? _adjCrossoverRate = null;
    [UI] private Scale? _sclCrossoverRate = null;

    [UI] private Adjustment? _adjMutationRate = null;
    [UI] private Scale? _sclMutationRate = null;

    [UI] private Adjustment? _adjPopulationSize = null;
    [UI] private SpinButton? _sbtPopulationSize = null;

    [UI] private Adjustment? _adjKnapsackSize = null;
    [UI] private SpinButton? _sbtKnapsackSize = null;

    [UI] private Adjustment? _adjIterationsLimit = null;
    [UI] private SpinButton? _sbtIterationsLimit = null;

    [UI] private ComboBox? _cboSelectionType = null;
    [UI] private ComboBox? _cboCrossoverType = null;

    [UI] private FileChooserButton? _fcInputFile = null;

    [UI] private RadioButton? _rbTotalIterationsLimit = null;
    [UI] private Button? _btnRun = null;
    [UI] private Button? _btnPreviewItems = null;

    private readonly Parameters _parameters = new();
    private readonly IProblemResolver? _problemResolver;

    public MainWindow(IProblemResolver problemResolver) : this(new Builder("gui.glade"))
    {
        _problemResolver = problemResolver;
    }

    private MainWindow(Builder builder) : base(builder.GetRawOwnedObject("MainWindow"))
    {
        builder.Autoconnect(this);

        InitializeControls();
        LoadParameters();

        DeleteEvent += (_, _) => GtkApplication.Quit();
        _btnRun!.Clicked += _btnRun_Clicked!;
        _btnPreviewItems!.Clicked += _btnPreviewItems_Clicked!;
        _fcInputFile!.SelectionChanged += (_, _) => _parameters.InputFile = _fcInputFile.Filename;
    }

    private void InitializeControls()
    {
        _sclCrossoverRate!.Adjustment = _adjCrossoverRate;
        _sclMutationRate!.Adjustment = _adjMutationRate;
        _sbtKnapsackSize!.Adjustment = _adjKnapsackSize;
        _sbtPopulationSize!.Adjustment = _adjPopulationSize;
        _sbtIterationsLimit!.Adjustment = _adjIterationsLimit;

        _cboSelectionType!.FillWithEnum<SelectionType>();
        _cboCrossoverType!.FillWithEnum<CrossoverType>();
    }

    private void LoadParameters()
    {
        try
        {
            _rbTotalIterationsLimit!.Active = _parameters.IterationsLimit.HasValue;
            var iterationsLimit = _parameters.IterationsLimit.HasValue ? _parameters.IterationsLimit!.Value : _parameters.IterationsLimitWithoutImprovement!.Value;
            _sbtIterationsLimit!.Value = iterationsLimit;

            _sbtKnapsackSize!.Value = _parameters.KnapsackSize;
            _sbtPopulationSize!.Value = _parameters.PopulationSize;

            _cboCrossoverType!.Active = (int)_parameters.CrossoverType;
            _cboSelectionType!.Active = (int)_parameters.SelectionType;

            _sclCrossoverRate!.Value = _parameters.CrossoverRate;
            _sclMutationRate!.Value = _parameters.MutationRate;

            _fcInputFile!.SetFilename(_parameters.InputFile);
        }
        catch (Exception ex)
        {
            ex.ShowErrorDialog();
        }
    }

    private void ReadParameters()
    {
        try
        {
            _parameters.CrossoverRate = _sclCrossoverRate!.Value;
            _parameters.MutationRate = _sclMutationRate!.Value;

            _parameters.SelectionType = (SelectionType)_cboSelectionType!.Active;
            _parameters.CrossoverType = (CrossoverType)_cboCrossoverType!.Active;

            _parameters.KnapsackSize = (int)_sbtKnapsackSize!.Value;
            _parameters.PopulationSize = (int)_sbtPopulationSize!.Value;

            _parameters.InputFile = _fcInputFile!.Filename;

            bool iterationsLimitActive = _rbTotalIterationsLimit!.Active;
            int iterationsLimit = (int)_sbtIterationsLimit!.Value;
            if (iterationsLimitActive)
            {
                _parameters.IterationsLimit = iterationsLimit;
                _parameters.IterationsLimitWithoutImprovement = null;
            }
            else
            {
                _parameters.IterationsLimit = null;
                _parameters.IterationsLimitWithoutImprovement = iterationsLimit;
            }
        }
        catch (Exception ex)
        {
            ex.ShowErrorDialog();
        }
    }

    private void OpenResultWindow(ResolveResult resolveResult)
    {
        try
        {
            var resultWindow = new ResultWindow();
            resultWindow.SetResult(resolveResult);
            resultWindow.Show();
        }
        catch (Exception ex)
        {
            ex.ShowErrorDialog();
        }
    }

    private void OpenItemsWindow()
    {
        try
        {
            var itemsWindow = new ItemsWindow();
            itemsWindow.LoadItems(_parameters.Items);
            itemsWindow.Modal = true;
            itemsWindow.Show();
        }
        catch (Exception ex)
        {
            ex.ShowErrorDialog();
        }
    }

    private void _btnRun_Clicked(object sender, EventArgs a)
    {
        ReadParameters();

        try
        {
            var result = _problemResolver!.Resolve(_parameters);
            OpenResultWindow(result);
        }
        catch (Exception ex)
        {
            ex.ShowErrorDialog();
        }
    }

    private void _btnPreviewItems_Clicked(object sender, EventArgs a)
    {
        OpenItemsWindow();
    }
}
