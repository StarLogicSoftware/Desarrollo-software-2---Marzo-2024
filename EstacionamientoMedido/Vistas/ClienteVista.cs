using EstacionamientoMedido.Controladores;
using EstacionamientoMedido.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamientoMedido.Vistas
{
    public class ClienteVista
    {
        ClienteController controladorClientes = new ClienteController();

        public void CargarDatosCliente()
        {
            Cliente clienteNuevo = new Cliente(); // Instanciamos el cliente para cargar los datos

            Console.Write("Nombre: ");
            clienteNuevo.Nombre = Console.ReadLine();
            Console.Write("Apellido: ");
            clienteNuevo.Apellido = Console.ReadLine();
            Console.Write("Telefono: ");
            clienteNuevo.Telefono = Console.ReadLine();
            Console.Write("Email: ");
            clienteNuevo.Email = Console.ReadLine();

           controladorClientes.GuardarCliente(clienteNuevo);
        }

        public void MostrarClientesRegistrados()
        {
            List<Cliente> listadoClientes = controladorClientes.ObtenerClientes();

            Console.WriteLine("Listado de clientes cargados en el sistema");

            foreach (var item in listadoClientes)
            {
                Console.WriteLine($"> nombre: {item.Nombre} {item.Apellido} - tel: {item.Telefono} - email: {item.Email}");
            }
        }
    }
}
