using ListaTareasNataliaFdezDeVera.MVVM.Models;
using ListaTareasNataliaFdezDeVera.MVVM.ViewModels;
using System.Threading;

namespace ListaTareasNataliaFdezDeVera.MVVM.Views;

public partial class DataView : ContentPage
{
    public DataView()
    {
        InitializeComponent();
        BindingContext = App.SharedViewModel; // Usar el ViewModel compartido
    }

    /**
     * Método Button_Clicked
     * Método que navega hacia una nueva página llamada nueva tarea 
     * Crea una nueva tarea, se pasa null como parámetro al constructor de la página nueva tarea
     */
    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NuevaTarea(null));
    }

    /**
     * Método para que cuando el usuario presione el botón de editar
     * se le asigne la tarea al view model y se navegue a la página de Nueva Tarea
     * */
    private async void EditarTarea(Tarea tarea)
    {
        if (tarea != null)
        {
            //asignamos la terea al ViewModel
            App.SharedViewModel.TareaSeleccionada = tarea;

            //Navegamos a la página de NuevaTarea
            await Application.Current.MainPage.Navigation.PushAsync(new NuevaTarea(tarea));
        }





    }
}