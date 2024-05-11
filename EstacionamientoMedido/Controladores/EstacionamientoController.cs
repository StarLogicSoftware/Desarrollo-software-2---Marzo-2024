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

        public void IniciarEstacionamiento(string patente)
        {
            Vehiculo vehiculo = controladorVehiculo.ObtenerVehiculoPorPatente(patente);

            Estacionamiento estacionamiento = new Estacionamiento();
            estacionamiento.Entrada = DateTime.Now;
            estacionamiento.VehiculoEstacionado = vehiculo;
            estacionamiento.PrecioHora = 2000;

            repo.Estacionamientos.Add(estacionamiento);
        }

        public void FinalizarEstacionamiento(string patente)
        {
            Estacionamiento salida = repo.Estacionamientos
                .Where(x=> x.VehiculoEstacionado.Patente == patente)
                //.Where(x=> x.Salida == null)
                .OrderBy(x=> x.Entrada)
                .Single();

            repo.Estacionamientos.Remove(salida);

            salida.Salida = DateTime.Now;
            // TAREA: Calculo del precio total
            salida.TotalEstacionamiento = 0;

            repo.Estacionamientos.Add(salida);
        }
    }
}
