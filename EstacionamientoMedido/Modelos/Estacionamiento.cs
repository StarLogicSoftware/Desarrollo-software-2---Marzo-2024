using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamientoMedido.Modelos
{
    public class Estacionamiento
    {
        public DateTime Entrada { get; set; }
        public DateTime Salida { get; set; }
        public PlazaEstacionamiento PlazaEstacionamiento { get; set; }
        public int PrecioHora { get; set; }
        public Vehiculo VehiculoEstacionado { get; set; }
        public int TotalEstacionamiento { get; set; }

    }
}
