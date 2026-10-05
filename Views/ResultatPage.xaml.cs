namespace CalculateurAge.Views;

// Relie les paramètres de l'URL aux propriétés
[QueryProperty(nameof(Nom), "nom")]
[QueryProperty(nameof(Age), "age")]
public partial class ResultatPage : ContentPage
{
    // Ces propriétés sont remplies par la navigation, APRÈS le constructeur.
	public string Nom { get; set; } = null!;
	public string Age { get; set; } = null!;
    public ResultatPage()
    {
        InitializeComponent();
    }

    // Appelé à CHAQUE affichage de la page.
    protected override void OnAppearing()
    {
        base.OnAppearing();
        lblMessage.Text = $"{Nom}, vous avez {Age} ans";
    }

    // Revenir à la page précédente.
    private async void OnRetourClicked(object? sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}