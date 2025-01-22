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
     * M�todo Button_Clicked
     * M�todo que navega hacia una nueva p�gina llamada nueva tarea 
     * Crea una nueva tarea, se pasa null como par�metro al constructor de la p�gina nueva tarea
     */
    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new NuevaTarea(null));
    }

    /**
     * M�todo para que cuando el usuario presione el bot�n de editar
     * se le asigne la tarea al view model y se navegue a la p�gina de Nueva Tarea
     * */
    private async void EditarTarea(Tarea tarea)
    {
        if (tarea != null)
        {
            //asignamos la terea al ViewModel
            App.SharedViewModel.TareaSeleccionada = tarea;

            //Navegamos a la p�gina de NuevaTarea
            await Application.Current.MainPage.Navigation.PushAsync(new NuevaTarea(tarea));
        }





    }
}