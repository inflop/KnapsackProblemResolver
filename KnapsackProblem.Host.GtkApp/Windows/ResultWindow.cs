using System;
using Gtk;
using KnapsackProblem.Core;
using UI = Gtk.Builder.ObjectAttribute;

namespace KnapsackProblem.Host.GtkApp.Windows;

class ResultWindow : Dialog
{
    [UI] private readonly TextView? _txtBestSolution = null;
    [UI] private readonly TextBuffer? _txbBestSolution = null;

    [UI] private readonly TextView? _txtSummary = null;
    [UI] private readonly TextBuffer? _txbSummary = null;

    [UI] private readonly TextView? _txtParameters = null;
    [UI] private readonly TextBuffer? _txbParameters = null;

    [UI] private readonly Button? _btnResultOK = null;

    public ResultWindow() : this(new Builder("gui.glade"))
    {
        Initialize();
    }

    private void Initialize()
    {
        Title = "Result";
        _txtBestSolution!.Buffer = _txbBestSolution;
        _txtSummary!.Buffer = _txbSummary;
        _txtParameters!.Buffer = _txbParameters;

        _txtBestSolution!.Editable = false;
        _txtSummary!.Editable = false;
        _txtParameters!.Editable = false;
    }

    public void SetResult(ResolveResult result)
    {
        _txbBestSolution!.Text = $"{result.BestChromosome}";
        _txbSummary!.Text = $"Total iterations: {result.TotalIterations}\nTime elapsed: {result.ElapsedTime}";
        _txbParameters!.Text = $"{result.Parameters}";
    }

    private ResultWindow(Builder builder) : base(builder.GetRawOwnedObject("ResultWindow"))
    {
        builder.Autoconnect(this);
        DefaultResponse = ResponseType.Cancel;

        Response += Dialog_Response;
        _btnResultOK!.Clicked += _btnResultOK_Clicked!;
    }

    private void Dialog_Response(object o, ResponseArgs args)
    {
        Destroy();
    }

    private void _btnResultOK_Clicked(object sender, EventArgs a)
    {
        Destroy();
    }
}
