namespace CalculateurAge.ViewModels;

public class CalculateurViewModel : BaseViewModel
{
    // Initialisation directe avec string.Empty pour régler l'avertissement CS8618
    private string _nom = string.Empty;
    private DateTime _dateNaissance = DateTime.Today.AddYears(-20);
    private string _resultat = string.Empty;
    private bool _resultatVisible;

    private string _statut = string.Empty;
    private string _prochainAnniversaire = string.Empty;

    public string Nom
    {
        get => _nom;
        set
        {
            if (SetField(ref _nom, value))
            {
                CalculerCommand.Rafraichir();
            }
        }
    }

    public DateTime DateNaissance
    {
        get => _dateNaissance;
        set => SetField(ref _dateNaissance, value);
    }

    public string Resultat
    {
        get => _resultat;
        set => SetField(ref _resultat, value);
    }

    public bool ResultatVisible
    {
        get => _resultatVisible;
        set => SetField(ref _resultatVisible, value);
    }

    public string Statut
    {
        get => _statut;
        set => SetField(ref _statut, value);
    }

    public string ProchainAnniversaire
    {
        get => _prochainAnniversaire;
        set => SetField(ref _prochainAnniversaire, value);
    }

    public RelayCommand CalculerCommand { get; }
    public RelayCommand EffacerCommand { get; }

    public CalculateurViewModel()
    {
        CalculerCommand = new RelayCommand(Calculer, () => !string.IsNullOrWhiteSpace(Nom));
        EffacerCommand = new RelayCommand(Effacer);
    }

    private void Calculer()
    {
        DateTime aujourdhui = DateTime.Today;

        int age = aujourdhui.Year - DateNaissance.Year;
        if (DateNaissance.Date > aujourdhui.AddYears(-age)) age--;

        Resultat = $"{Nom}, vous avez {age} ans";

        Statut = age >= 18 ? "Statut : Majeur(e)" : "Statut : Mineur(e)";

        DateTime prochainAnni = new DateTime(aujourdhui.Year, DateNaissance.Month, DateNaissance.Day);
        if (prochainAnni < aujourdhui)
        {
            prochainAnni = prochainAnni.AddYears(1);
        }
        int joursRestants = (prochainAnni - aujourdhui).Days;

        if (joursRestants == 0)
            ProchainAnniversaire = " Joyeux Anniversaire ! C'est aujourd'hui !";
        else
            ProchainAnniversaire = $" Prochain anniversaire dans {joursRestants} jours";

        ResultatVisible = true;
    }

    private void Effacer()
    {
        Nom = string.Empty;
        DateNaissance = DateTime.Today.AddYears(-20);
        Resultat = string.Empty;
        Statut = string.Empty;
        ProchainAnniversaire = string.Empty;
        ResultatVisible = false;
    }
}
