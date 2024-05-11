using EstacionamientoMedido.Controladores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamientoMedido.Vistas
{
    public class VehiculoVista
    {
        VehiculoController vehiculoController = new VehiculoController();

        public void ListarVehiculos()
        {
            var vehiculos = vehiculoController.ObtenerTodos();

            Console.WriteLine("Vehiculos cargados");
            Console.WriteLine();
            foreach (var item in vehiculos)
            {
                Console.WriteLine($"{item.Patente} - {item.Marca} {item.Modelo}");
            }
            Console.WriteLine();
        }
    }
}
