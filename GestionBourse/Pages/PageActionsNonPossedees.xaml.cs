using System.Transactions;
using GestionBourse.Datas;
using GestionBourse.Repositories;
using Transaction = GestionBourse.Models.Transaction;
using Action = GestionBourse.Models.Action;

namespace GestionBourse.Pages;

public partial class PageActionsNonPossedees : ContentPage
{
    int idTrader;
    TransactionRepository transactionRepository;
    ActionRepository actionRepository;

    public PageActionsNonPossedees(int numTrader)
    {
        transactionRepository = new TransactionRepository();
        actionRepository = new ActionRepository();
        idTrader = numTrader;
        InitializeComponent();
        Task.Run(async () => lvActionsNonPossedees.ItemsSource = await actionRepository.GetActionsNonPossedees(idTrader));
    }

    private void lvActionsNonPossedees_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (lvActionsNonPossedees.SelectedItem is Action action)
        {
            txtIdAction.Text = action.IdAction.ToString();
            txtNomAction.Text = action.NomAction.ToString();
        }
    }

    private async void btnAcheter_Clicked(object sender, EventArgs e)
    {
        if (lvActionsNonPossedees.SelectedItem == null)
        {
            await DisplayAlert("Choix de l'action", "Veuillez sélectionner une action", "Ok");
        }
        else if (txtPrixAchat.Text == null || txtPrixAchat.Text.Equals(""))
        {
            await DisplayAlert("Erreur de saisie", "Veuillez saisir un prix", "Ok");
        }
        else if (txtQuantite.Text == null || txtQuantite.Text.Equals(""))
        {
            await DisplayAlert("Erreur de saisie", "Veuillez saisir une quantité", "Ok");
        }
        else
        {
            Transaction nouvelleAction = new Transaction()
            {
                IdTransaction = DataBase.GetConnection().Table<Transaction>().ToListAsync().Result.Max(t => t.IdTransaction) + 1,
                NumAction = Convert.ToInt16(txtIdAction.Text),
                NumTrader = idTrader,
                Quantite = Convert.ToInt16(txtQuantite.Text),
                PrixAchat = Convert.ToDouble(txtPrixAchat.Text)
            };
            await transactionRepository.Create(nouvelleAction);
            await Navigation.PushModalAsync(new NavigationPage(new MainPage()));
        }
    }
}