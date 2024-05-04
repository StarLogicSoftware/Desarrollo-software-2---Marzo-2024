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

        public void MostrarMenu()
        {
            int eleccion;
            Console.WriteLine("1- Cargar un cliente");
            Console.WriteLine("2- Ver clientes registrados");
            Console.WriteLine();
            Console.Write("Opcion: ");
            eleccion = int.Parse(Console.ReadLine());

            switch (eleccion)
            {
                case 1:

                    vistaCliente.CargarDatosCliente();

                    Console.WriteLine(); 
                    MostrarMenu(); 

                    break;
                case 2:

                    vistaCliente.MostrarClientesRegistrados();

                    Console.WriteLine();
                    MostrarMenu();
                    break;

                default:
                    Console.Clear();
                    MostrarMenu();
                    break;
            }
        }
    }
}
