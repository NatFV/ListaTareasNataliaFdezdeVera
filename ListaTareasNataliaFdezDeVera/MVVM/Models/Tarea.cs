namespace ListaTareasNataliaFdezDeVera.MVVM.Models
{
    public class Tarea
    {
        public string Titulo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public bool TareaCompletada { get; set; }
        public DateTime Plazo { get; set; }
        public string Prioridad { get; set; } = string.Empty;
        public double Porcentaje { get; set; }





    }
}
