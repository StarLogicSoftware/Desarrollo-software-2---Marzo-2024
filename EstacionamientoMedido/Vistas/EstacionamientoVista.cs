using EstacionamientoMedido.Controladores;
using EstacionamientoMedido.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamientoMedido.Vistas
{
    public class EstacionamientoVista
    {
        VehiculoController controladorVehiculo = new VehiculoController();
        VehiculoVista vistaVehiculo = new VehiculoVista();
        EstacionamientoController controladorEstacionamiento = new EstacionamientoController();

        public void IniciarEstacionamiento()
        {
            Console.WriteLine();
            Console.Write("Ingrese patente de entrada: ");
            string patente = Console.ReadLine();

            if (!controladorVehiculo.ExistePatente(patente))
            {
                vistaVehiculo.CrearVehiculo();
            }

            controladorEstacionamiento.IniciarEstacionamiento(patente);
        }

        public void FinalizarEstacionamiento()
        {
            Console.WriteLine();
            Console.Write("Ingrese patente de salida: ");
            string patente = Console.ReadLine();

            controladorEstacionamiento.FinalizarEstacionamiento(patente);
        }

        public void VerEstacionamientos()
        {
            List<Estacionamiento> estacionamientos = controladorEstacionamiento.ObtenerTodos();

            if (estacionamientos.Count == 0)
            {
                Console.WriteLine("No hay estacionamientos");
            }
            else
            {
                foreach (var item in estacionamientos)
                {
                    if(item.Estado == Enumeraciones.EstadoEstacionamiento.Activo)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }

                    Console.WriteLine($"> {item.VehiculoEstacionado.Patente} - {item.Entrada} / {item.Salida}");

                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
        }
    }
}
