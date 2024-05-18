using EstacionamientoMedido.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamientoMedido.Vistas
{
    public class Menu
    {
        ClienteVista vistaCliente = new ClienteVista();
        VehiculoVista vistaVehiculo = new VehiculoVista();
        EstacionamientoVista vistaEstacionamiento = new EstacionamientoVista();

        public void MostrarMenu()
        {
            int eleccion;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("1- Iniciar estacionamiento");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("2- Terminar estacionamiento");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("---------------------------");
            Console.WriteLine("3- Cargar un cliente");
            Console.WriteLine("4- Ver clientes registrados");
            Console.WriteLine("---------------------------");
            Console.WriteLine("5- Cargar Vehiculo");
            Console.WriteLine("6- Ver vehiculos cargados");
            Console.WriteLine("7- Ver estacionamientos");
            Console.WriteLine("---------------------------");
            Console.WriteLine("8- Salir");
            Console.WriteLine();
            Console.Write("Opcion: ");
            eleccion = int.Parse(Console.ReadLine());

            switch (eleccion)
            {
                case 1:
                    Console.WriteLine();
                    vistaEstacionamiento.IniciarEstacionamiento();

                    Console.WriteLine();
                    MostrarMenu();

                    break;
                case 3:

                    vistaCliente.CargarDatosCliente();

                    Console.WriteLine();
                    MostrarMenu();

                    break;

                case 4:

                    vistaCliente.MostrarClientesRegistrados();

                    Console.WriteLine();
                    MostrarMenu();
                    break;

                case 5:
                    vistaVehiculo.CrearVehiculo();
                    Console.WriteLine();
                    MostrarMenu();

                    break;

                case 6:
                    vistaVehiculo.ListarVehiculos();
                    Console.WriteLine();
                    MostrarMenu();
                    break;

                case 7: // ver estacionmaientos
                    vistaEstacionamiento.VerEstacionamientos();
                    Console.WriteLine();
                    MostrarMenu();
                    break;

                case 8:
                    Environment.Exit(0);
                    break;

                default:
                    Console.Clear();
                    MostrarMenu();
                    break;
            }
        }
    }
}
