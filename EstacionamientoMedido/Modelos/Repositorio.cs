using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamientoMedido.Modelos
{
    /*
     * Patron de diseño SINGLETONE
     * Reglas a aplicar
        1 -> Constructor PRIVADO
        2 -> Metodo para obtener instancia
            2.1 -> si no existe la crea, y si existe devuelve la misma
        3 -> El metodo y la instancia tiene que ser estatico */

    public class Repositorio 
    {
        public List<Cliente> Clientes = new List<Cliente>();
        public List<Vehiculo> Vehiculos = new List<Vehiculo>();
        public List<PlazaEstacionamiento> PlazasEstacionamiento = new List<PlazaEstacionamiento>();
        public List<Estacionamiento> Estacionamientos = new List<Estacionamiento>();

        private static Repositorio Instancia;

        private Repositorio()
        {
            PrecargarDatos();
        }
        
        public static Repositorio ObtenerInstancia()
        {
            if(Instancia == null)
            {
                Instancia = new Repositorio();

                return Instancia;
            }
            else
            {
                return Instancia;
            }
        }

        private void PrecargarDatos()
        {
            // Clientes

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

            // Vehiculos
            Vehiculos.Add(new Vehiculo()
            {
                Marca = "Fiat",
                Color = "Rojo",
                Patente="ABC123",
                Modelo = "Palio"
            });
            Vehiculos.Add(new Vehiculo()
            {
                Marca = "Fiat",
                Modelo = "Cronos",
                Color = "Blanco",
                Patente = "AB123CD",
            });

            //Plazas estacionamiento
            PlazasEstacionamiento.Add(new PlazaEstacionamiento()
            {
                Nombre= "A"
            });
            PlazasEstacionamiento.Add(new PlazaEstacionamiento()
            {
                Nombre = "B"
            });
            PlazasEstacionamiento.Add(new PlazaEstacionamiento()
            {
                Nombre = "C"
            });
        }
    }
}
