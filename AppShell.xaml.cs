using CalculateurAge.Views;

namespace CalculateurAge;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // Déclare la route. Sans cette ligne, GoToAsync lève une exception "route inconnue".
        Routing.RegisterRoute(nameof(ResultatPage), typeof(ResultatPage));
    }
}