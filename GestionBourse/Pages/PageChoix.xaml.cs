namespace GestionBourse.Pages;

public partial class PageChoix : ContentPage
{
    int idTrader;

    public PageChoix(int numTrader)
    {
        idTrader = numTrader;
        InitializeComponent();
    }

    private void btnAcheter_Clicked(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new NavigationPage(new PageActionsNonPossedees(idTrader)));
    }

    private void btnVendre_Clicked(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new NavigationPage(new PageTransactions(idTrader)));
    }
}