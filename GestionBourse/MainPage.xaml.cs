using GestionBourse.Datas;
using GestionBourse.Models;
using GestionBourse.Pages;
using GestionBourse.Repositories;

namespace GestionBourse
{
    public partial class MainPage : ContentPage
    {
        private DataBase dataBase;
        private TraderRepository traderRepository;

        public MainPage()
        {
            dataBase = new DataBase();
            traderRepository = new TraderRepository();
            InitializeComponent();
            Task.Run(async () => { lvTraders.ItemsSource = await traderRepository.GetTraders(); });
        }

        private void lvTraders_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (lvTraders.SelectedItem is Trader selectedTrader)
            {
                int idTrader = selectedTrader.IdTrader;
                Navigation.PushModalAsync(new NavigationPage(new PageChoix(idTrader)));
            }
        }
    }
}