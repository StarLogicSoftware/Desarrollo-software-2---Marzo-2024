using EstacionamientoMedido.Helpers;
using EstacionamientoMedido.Modelos;
using EstacionamientoMedido.Validaciones;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamientoMedido.Controladores
{
    public class VehiculoController
    {
        Repositorio repo = Repositorio.ObtenerInstancia();

        public bool ExistePatente(string patente)
        {
            return repo.Vehiculos.Any(x => x.Patente == patente);

            //bool resultado;

            //resultado = repo.Vehiculos.Any(x=> x.Patente == patente);
            //resultado = repo.Vehiculos.Where(x => x.Patente == patente).Any();

            //return resultado;
        }

        public void GuardarVehiculo(Vehiculo v)
        {
            VehiculoValidator valida = new VehiculoValidator();

            ValidationResult resultadoValidacion = valida.Validate(v);

            if (resultadoValidacion.IsValid)
            {
                repo.Vehiculos.Add(v);
            }
            else
            {
                foreach (var item in resultadoValidacion.Errors)
                {
                    Console.WriteLine(item.ErrorMessage);
                }
            }
            
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

        public Vehiculo ObtenerVehiculoPorPatente(string patente)
        {
            // Esto es sin usar LinQ
            //Vehiculo vehiculoBuscado = repo.Vehiculos.Find(x => x.Patente == patente);
            
            Vehiculo vehiculoBuscado = repo.Vehiculos.Where(x => x.Patente == patente).FirstOrDefault();

            return vehiculoBuscado;
        }
    }
}
