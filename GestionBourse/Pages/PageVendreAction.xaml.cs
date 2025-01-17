using System.Transactions;
using GestionBourse.Models;
using GestionBourse.Repositories;
using Transaction = GestionBourse.Models.Transaction;

namespace GestionBourse.Pages;

public partial class PageVendreAction : ContentPage
{
    TransactionTrader transactionTrader;
    TransactionRepository transactionRepository;

    public PageVendreAction(TransactionTrader uneTransaction)
    {
        transactionTrader = uneTransaction;
        BindingContext = transactionTrader;
        transactionRepository = new TransactionRepository();
        InitializeComponent();
    }

    private async void btnVendre_ClickedAsync(object sender, EventArgs e)
    {
        if (txtNouvelleQuantite.Text.Equals("") || txtNouvelleQuantite.Text == null)
        {
            await DisplayAlert("Erreur de saisie", "Veuillez saisir une quantité", "Ok");
        }
        else if (Convert.ToInt16(txtNouvelleQuantite.Text) > Convert.ToInt16(txtQuantite.Text))
        {
            // Impossible de vendre plus que ce que l'on possède
            await DisplayAlert("Erreur de saisie", "Quantité trop grande", "Ok");
        }
        else if (Convert.ToInt16(txtNouvelleQuantite.Text) < Convert.ToInt16(txtQuantite.Text))
        {
            // On met à jour la quantité : on ne vend qu'une partie
            Transaction transaction = await transactionRepository.GetTransactionById(transactionTrader.IdTransaction);
            transaction.Quantite = transactionTrader.Quantite - Convert.ToInt16(txtNouvelleQuantite.Text);
            await transactionRepository.Update(transaction);
            await Navigation.PushModalAsync(new NavigationPage(new MainPage()));
        }
        else
        {
            // On supprime l'action possédée : on vend tout
            Transaction transaction = await transactionRepository.GetTransactionById(transactionTrader.IdTransaction);
            await transactionRepository.Delete(transaction);
            await Navigation.PushModalAsync(new NavigationPage(new MainPage()));
        }
    }
}