using ListaTareasNataliaFdezDeVera.MVVM.Models;
using ListaTareasNataliaFdezDeVera.MVVM.ViewModels;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;

namespace ListaTareasNataliaFdezDeVera.MVVM.Views;

public partial class NuevaTarea : ContentPage
{
    /**
     * Constructor NuevaTarea
     * Inicializa la página con un objeto Tarea denominado Tarea Seleccionada.
     * Establece el contexto de enlace Binding Context y el SharedViewModel
     * Si la tarea no es nula implementa el método cargar tarea en campos
     * 
     */
    public NuevaTarea(Tarea tareaSeleccionada)
    {
        InitializeComponent();
        BindingContext = App.SharedViewModel; // Usar el ViewModel compartido

        // Asignar la tarea seleccionada al ViewModel
        if (tareaSeleccionada != null)
        {
            App.SharedViewModel.TareaSeleccionada = tareaSeleccionada;

            CargarTareaEnCampos(tareaSeleccionada);
        }
    }
    /**
     * Método CargarTareaEnCampos
     * Se encarga de guardar los datos rellenados por el usuario como propiedades
     * de la clase Tarea
     */
    private void CargarTareaEnCampos(Tarea tarea)
    {
        TituloEntry.Text = tarea.Titulo;
        DescripcionEntry.Text = tarea.Descripcion;
        PlazoPicker.Date = tarea.Plazo;
        if (BindingContext is DataViewModel viewModel)
        {
            viewModel.Prioridad = tarea.Prioridad;
        }
        slider.Value = tarea.Porcentaje;
        // Asignar el estado del CheckBox para TareaCompletada
        TareaCompletadaCheckBox.IsChecked = tarea.TareaCompletada;

    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        // Si existe una tarea seleccionada, cargarla en la UI
        if (App.SharedViewModel.TareaSeleccionada != null)
        {
            CargarTareaEnCampos(App.SharedViewModel.TareaSeleccionada);
        }
    }

    /**
     * Método button_clicked
     * Método utilizado para navegar hacia atrás en la pila de navegación, vuelve a la 
     * página anterior
     */
    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    /**
     * Método Entry_TextChanged, se ejcuta cada vez que un texto del Entry cambia
     * Muestra el texto actualizado
     */
    private void Entry_TextChanged(object sender, TextChangedEventArgs e)
    {
        Entry? entry = sender as Entry;
        if (entry is not null)
        {
            Debug.WriteLine($"Entry_TextChanged: {entry.Text}");
        }

    }

    /**
     * Método que se ejecuta cuando el usuario finaliza la edición de un Entry
     */
    private void Entry_Completed(object sender, EventArgs e)
    {
        Entry? entry = sender as Entry;
        if (entry is not null)
        {
            Debug.WriteLine($"Entry_Completed: {entry.Text}");
        }
    }

    /**
     * Método DatePicker_DateSelected
     * Se ejecuta cuando el usuario selecciona una fecha
     * Actualiza la etiqueta LblValueDatePicker para mostrar la fecha en formato dd/MM/yyyy;
     */
    private void DatePicker_DateSelected(object sender, DateChangedEventArgs e)
    {
        DatePicker? datePicker = sender as DatePicker;
        LblValueDatePicker.Text = datePicker!.Date.ToString("dd/MM/yyyy");
    }

    /**
     * Método Slider_ValueChanged 
     * Se ejecuta cuando el valor del slider cambia
     * Actualiza la etiqueta LblValueSlider para mostrar el valor del slider;
     */
    private void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        Slider? slider = sender as Slider;
        if (slider is not null)
        {
            LblValueSlider.Text = $"{slider.Value}";

            // Sincronizamos el Stepper con el valor del Slider
            // Esto se asegura de que el Stepper se mueva junto con el Slider
            stepper.Value = slider.Value;
        }
    }

    /**
     * Método Stp_Control_ValueChanged 
     * Se ejecuta cuando el valor del stepper cambia
     * Actualiza la etiqueta StpControlValue para mostrar el valor del slider;
     */
    private void StpControl_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        Stepper? stepper = sender as Stepper;
        if (stepper is not null)
        {
            StpControlValue.Text = $"Valor: {stepper.Value}";
            // Sincronizamos el Slider con el valor del Stepper
            // Esto se asegura de que el Slider se mueva junto con el Stepper
            slider.Value = stepper.Value;
        }

    }
    

    }

   





