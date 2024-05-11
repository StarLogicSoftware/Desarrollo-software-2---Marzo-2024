using EstacionamientoMedido.Helpers;
using EstacionamientoMedido.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamientoMedido.Controladores
{
    public class VehiculoController
    {
        Repositorio repo = new Repositorio();

        public void GuardarVehiculo(Vehiculo v)
        {
            repo.Vehiculos.Add(v);
        }

        public List<Vehiculo> ObtenerTodos()
        {
            return repo.Vehiculos;
        }

        public Vehiculo Modificar(Vehiculo v)
        {
            Vehiculo vehiculoBorrar = repo.Vehiculos.Find(x => x.Patente == v.Patente);

            repo.Vehiculos.Remove(vehiculoBorrar);

            repo.Vehiculos.Add(v);

            return v;
        }

        public void Eliminar(Vehiculo c)
        {
            Vehiculo vehiculoAEliminar = repo.Vehiculos.Find(x => x.Patente == c.Patente);

            repo.Vehiculos.Remove(vehiculoAEliminar);
        }

        public GestorRespuesta<Vehiculo> ObtenerVehiculoPorPatente(string patente)
        {
            Vehiculo vehiculoBuscado = repo.Vehiculos.Find(x => x.Patente == patente);

            if (vehiculoBuscado == null)
            {
                return new GestorRespuesta<Vehiculo>()
                {
                    HayError = true,
                    MensajeError = "No se encuentra vehiculo con esa patente",
                };
            }
            else
            {
                return new GestorRespuesta<Vehiculo>()
                {
                    HayError = false,
                    Respuesta = vehiculoBuscado,
                };
            }
        }
    }
}
