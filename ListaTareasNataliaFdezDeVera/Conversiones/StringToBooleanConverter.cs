

using System;
using System.Globalization;
using Microsoft.Maui.Controls;

namespace ListaTareasNataliaFdezDeVera.Conversiones
{
    public class StringToBooleanConverter : IValueConverter
    {
        /**
         * Método Convert, que determina si el radiobotón está seleccionado (dirección Modelo-UI)
         * Selecciona el radio botón correcto (IsChecked = True)
         */
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // El parámetro es el valor del RadioButton (Baja, Media, Alta)
            return value?.ToString() == parameter?.ToString();
        }
        /**
         * Método ConvertBack 
         * Actualiza el modelo con el valor del botón seleccionado
         */
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isChecked && isChecked)
            {
                return parameter?.ToString();
            }
            return null;
        }
    }
}