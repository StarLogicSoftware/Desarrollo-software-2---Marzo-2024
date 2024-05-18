using EstacionamientoMedido.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamientoMedido.Controladores
{
    public class EstacionamientoController
    {
        Repositorio repo = Repositorio.ObtenerInstancia();
        VehiculoController controladorVehiculo = new VehiculoController();
        private const int PrecioPorHora = 2000;

        public void IniciarEstacionamiento(string patente)
        {
            Vehiculo vehiculo = controladorVehiculo.ObtenerVehiculoPorPatente(patente);

            Estacionamiento estacionamiento = new Estacionamiento();
            estacionamiento.Entrada = DateTime.Now;
            estacionamiento.VehiculoEstacionado = vehiculo;
            estacionamiento.PrecioHora = PrecioPorHora;

            repo.Estacionamientos.Add(estacionamiento);
        }

        public Estacionamiento FinalizarEstacionamiento(string patente)
        {
            Estacionamiento salidaVehiculo = repo.Estacionamientos
                .Where(x=> x.VehiculoEstacionado.Patente == patente)
                //.Where(x=> x.Salida == null)
                .OrderBy(x=> x.Entrada)
                .Single();

            repo.Estacionamientos.Remove(salidaVehiculo);

            salidaVehiculo.Salida = DateTime.Now;

            TimeSpan tiempo = salidaVehiculo.Salida - salidaVehiculo.Entrada;

            double horas = tiempo.TotalHours;

            if(horas < 1)
            {
                salidaVehiculo.TotalEstacionamiento = PrecioPorHora;
            }
            else
            {
                salidaVehiculo.TotalEstacionamiento = Convert.ToInt32( horas * PrecioPorHora);
            }

            repo.Estacionamientos.Add(salidaVehiculo);

            return salidaVehiculo;
        }
    }
}
