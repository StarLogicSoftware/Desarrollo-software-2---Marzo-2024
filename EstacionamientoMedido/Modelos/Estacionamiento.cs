using EstacionamientoMedido.Enumeraciones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamientoMedido.Modelos
{
    public class Estacionamiento
    {
        public Estacionamiento(Vehiculo vehiculo, int precioHora)
        {
            Entrada = DateTime.Now;
            Estado = EstadoEstacionamiento.Activo;
            VehiculoEstacionado = vehiculo;
            PrecioHora = precioHora;
        }

        public void SalidaEstacionamiento()
        {
            Estado = EstadoEstacionamiento.Terminado;

            Salida = DateTime.Now;

            TimeSpan tiempo = Salida - Entrada;

            double horas = tiempo.TotalHours;

            if (horas < 1)
            {
                TotalEstacionamiento = PrecioHora;
            }
            else
            {
                TotalEstacionamiento = Convert.ToInt32(horas * PrecioHora);
            }
        }

        public DateTime Entrada { get; private set; }
        public DateTime Salida { get; private set; }
        public PlazaEstacionamiento PlazaEstacionamiento { get; private set; }
        public int PrecioHora { get; private set; }
        public Vehiculo VehiculoEstacionado { get; private set; }
        public int TotalEstacionamiento { get; private set; }
        public EstadoEstacionamiento Estado { get; private set; }
    }
}
