using EstacionamientoMedido.Modelos;

namespace EstacionamientoMedido
{
    public class EstacionamientoVistaDTO
    {
        public DateTime Entrada { get; set; }
        public DateTime Salida { get; set; }
        public string PlazaEstacionamiento { get; set; } = string.Empty;
        public int PrecioHora { get; private set; }
        public string Patente { get; set; } = string.Empty;
        public int TotalEstacionamiento { get; private set; }
    }
}
