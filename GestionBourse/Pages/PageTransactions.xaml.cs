using GestionBourse.Models;
using GestionBourse.Repositories;

namespace GestionBourse.Pages;

public partial class PageTransactions : ContentPage
{
    private TransactionRepository transactionRepository;

    public PageTransactions(int idTrader)
    {
        transactionRepository = new TransactionRepository();
        InitializeComponent();
        Task.Run(async () => lvTransactions.ItemsSource = await transactionRepository.GetTransactionsForTrader(idTrader));
    }

    private void lvTransactions_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        if (lvTransactions.SelectedItem is TransactionTrader transactionTrader)
        {
            Navigation.PushModalAsync(new NavigationPage(new PageVendreAction(transactionTrader)));
        }
    }
}