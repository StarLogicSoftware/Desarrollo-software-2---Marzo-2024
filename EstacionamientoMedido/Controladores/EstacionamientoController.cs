using EstacionamientoMedido.Modelos;
using EstacionamientoMedido.Enumeraciones;
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

            Estacionamiento estacionamiento = new Estacionamiento(vehiculo, PrecioPorHora);

            repo.Estacionamientos.Add(estacionamiento);
        }
        public Estacionamiento FinalizarEstacionamiento(string patente)
        {
            Estacionamiento salidaVehiculo = repo.Estacionamientos
                .Where(x=> x.VehiculoEstacionado.Patente == patente)
                .OrderBy(x=> x.Entrada)
                .Single();

            repo.Estacionamientos.Remove(salidaVehiculo);

            salidaVehiculo.SalidaEstacionamiento();

            repo.Estacionamientos.Add(salidaVehiculo);

            return salidaVehiculo;
        }
        public List<Estacionamiento> ObtenerTodos()
        {
            return repo.Estacionamientos;
        }
        public List<Estacionamiento> ObtenerEstacionamientosPorPatente(string patente)
        {
            List<Estacionamiento> estacionamientos;

            estacionamientos = repo.Estacionamientos
                .Where(x => x.VehiculoEstacionado.Patente == patente)
                .ToList();

            return estacionamientos;
        }

        public bool YaEstaEstacionado(string patente)
        {
            bool resultado;

            resultado = repo.Estacionamientos
                .Where( x => x.VehiculoEstacionado.Patente == patente)
                .Where( x => x.Estado == EstadoEstacionamiento.Activo)
                .Any();

            return resultado;
        }
    }
}
