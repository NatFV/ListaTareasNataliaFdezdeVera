using ListaTareasNataliaFdezDeVera.MVVM.ViewModels;
using ListaTareasNataliaFdezDeVera.MVVM.Views;


namespace ListaTareasNataliaFdezDeVera
{
    public partial class App : Application
    {
        public static DataViewModel SharedViewModel { get; private set; }
        public App()
        {
            InitializeComponent();
            SharedViewModel = new DataViewModel();
            MainPage = new NavigationPage(new DataView());
        }
    }
}
