

using ListaTareasNataliaFdezDeVera.MVVM.Models;
using ListaTareasNataliaFdezDeVera.MVVM.Views;
using PropertyChanged;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading;
using System.Windows.Input;

namespace ListaTareasNataliaFdezDeVera.MVVM.ViewModels
{
    /**Añadimos la interfaz AddINotifyPropertyChangedInterface que 
     * notifica de los cambios de los valores de las propiedades a la UI automáticamente
     * */

    [AddINotifyPropertyChangedInterface]
    public class DataViewModel
    {
        //Creamos un ObservableCollection para que la lista en la UI se mantenga sincronizada con los cambios
        public ObservableCollection<Tarea> Tareas { get; set; } = new ObservableCollection<Tarea>();
        
        // Esta propiedad almacena la tarea seleccionada (para editarla)
        public Tarea TareaSeleccionada { get; set; }

        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public bool TareaCompletada { get; set; }

        public DateTime Plazo { get; set; }
        public string Prioridad { get; set; }
        public double Porcentaje { get; set; }

        //Propiedades que ejecuta la lógica de los métodos cuando el usuario presiona los distintos botones
        public ICommand GuardarTareaCommand { get; }

        public ICommand EditarTareaCommand { get; }

        public ICommand EliminarTareaCommand { get; }




        //CONSTRUCTOR
        public DataViewModel()
        {
            GuardarTareaCommand = new Command(GuardarTarea);
             
            EditarTareaCommand = new Command<Tarea>(EditarTarea);       // Aseguramos que el comando recibe la tarea como parámetro

            EliminarTareaCommand = new Command<Tarea>(EliminarTarea);
        }




        /**Método guardar tarea
         * Toma los datos de las propiedades para crear una tarea
         * Agrega la tarea a la lista posteriormente
         * Vacía la tarea para agregar una nueva tarea
         * */
        private void GuardarTarea()
        {
            if (TareaSeleccionada == null)
            {
                // Crear una nueva tarea
                var nuevaTarea = new Tarea
                {
                    Titulo = Titulo,
                    Descripcion = Descripcion,
                    TareaCompletada= TareaCompletada,
                    Plazo = Plazo,
                    Prioridad = Prioridad,
                    Porcentaje = Porcentaje
                };

                try
                {
                    Tareas.Add(nuevaTarea);
                    Debug.WriteLine($"Tarea agregada: {nuevaTarea.Titulo}");
                }
                catch (Exception ex)
                {
                    Debug.WriteLine($"Error al agregar tarea: {ex.Message}");
                }
            }
            else
            {
                // Editar la tarea seleccionada
                TareaSeleccionada.Titulo = Titulo;
                TareaSeleccionada.Descripcion = Descripcion;
                TareaSeleccionada.TareaCompletada = TareaCompletada;
                TareaSeleccionada.Plazo = Plazo;
                TareaSeleccionada.Prioridad = Prioridad;
                TareaSeleccionada.Porcentaje = Porcentaje;

                // Actualizar la lista
                var index = Tareas.IndexOf(TareaSeleccionada);
                if (index != -1)
                {
                    Tareas[index] = TareaSeleccionada;
                    Debug.WriteLine($"Tarea actualizada: {TareaSeleccionada.Titulo}");
                }
            }

            // Limpiar los campos para la próxima tarea
            LimpiarCampos();
        }
        //Comando para eliminar tarea
        public void EliminarTarea(Tarea tarea) 
        {
            if (Tareas.Contains(tarea))
                Tareas.Remove(tarea);
        }
        private void LimpiarCampos()
        {
            Titulo = string.Empty;
            Descripcion = string.Empty;
            TareaCompletada = false;
            Plazo = DateTime.Now;
            Prioridad = string.Empty;
            Porcentaje = 0;
            TareaSeleccionada = null; // Asegurarse de que no haya tarea seleccionada
        }

        /**
     * Método para que cuando el usuario presione el botón de editar
     * se le asigne la tarea al view model y se navegue a la página de Nueva Tarea
     * */
        private async void EditarTarea(Tarea tarea)
        {
            if (tarea != null)
            {
                // Asignamos la tarea seleccionada al ViewModel para ser editada
                App.SharedViewModel.TareaSeleccionada = tarea;

                //Navegar a la página de editar tarea pasando la tarea
                await Application.Current.MainPage.Navigation.PushAsync(new NuevaTarea(tarea));
            }
        }
        



    }

}



