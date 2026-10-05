using System.Windows.Input;

namespace CalculateurAge.ViewModels;

// Transforme une méthode en objet liable à un Button.
public class RelayCommand : ICommand
{
    private readonly Action _executer;
    private readonly Func<bool>? _peutExecuter;

    public RelayCommand(Action executer, Func<bool>? peutExecuter = null)
    {
        _executer = executer;
        _peutExecuter = peutExecuter;
    }

    // "object?" résout les erreurs CS8767
    public bool CanExecute(object? parameter) => _peutExecuter?.Invoke() ?? true;

    // "object?" résout les erreurs CS8767
    public void Execute(object? parameter) => _executer();

    // "EventHandler?" résout les erreurs CS8618 et CS8612
    public event EventHandler? CanExecuteChanged;

    public void Rafraichir() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
}
