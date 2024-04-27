using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamientoMedido.Modelos
{
    public class Repositorio
    {
        public List<Cliente> Clientes = new List<Cliente>();
        public List<Vehiculo> Vehiculos = new List<Vehiculo>();
        public List<PlazaEstacionamiento> PlazasEstacionamiento = new List<PlazaEstacionamiento>();
        public List<Estacionamiento> Estacionamientos = new List<Estacionamiento>();

        public Repositorio()
        {
            Clientes.Add(new Cliente()
            {
                Nombre = "Pepe",
                Apellido = "Gonzales",
                Telefono = "123456",
                Email = "notiene@gmail.com",
            });
            Clientes.Add(new Cliente()
            {
                Nombre = "Juan",
                Apellido = "Fernandez",
                Telefono = "654321",
                Email = "estesitiene@gmail.com",
            });
        }
    }
}
