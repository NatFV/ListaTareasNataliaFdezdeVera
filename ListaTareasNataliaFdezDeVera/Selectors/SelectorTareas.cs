

using ListaTareasNataliaFdezDeVera.MVVM.Models;

namespace ListaTareasNataliaFdezDeVera.Selectors
{
    /**
     * Clase interna SelectorTareas:
     * Su propósito es seleccionar una plantilla de datos (un DataTemplate) 
     * dependiendo de la prioridad de una tarea.
     * En este caso, la plantilla seleccionada se elige en función de la prioridad
     */
    internal class SelectorTareas : DataTemplateSelector
    {
        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            Tarea? tarea = item as Tarea;
            if (tarea != null && tarea.Prioridad.Equals("Alta"))
            {
                Application.Current!.Resources.TryGetValue("PAlta", out object dataTemplate);
                return dataTemplate as DataTemplate ?? new DataTemplate();
            }
            else if (tarea != null && tarea.Prioridad.Equals("Media"))
            {
                Application.Current!.Resources.TryGetValue("PMedia", out object dataTemplate);
                return dataTemplate as DataTemplate ?? new DataTemplate();

            }
            else
            {
                Application.Current!.Resources.TryGetValue("TareasNormales", out object dataTemplate);
                return dataTemplate as DataTemplate ?? new DataTemplate();
            }


        }
    }
}
