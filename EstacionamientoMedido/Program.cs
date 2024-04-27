using EstacionamientoMedido.Controladores;
using EstacionamientoMedido.Modelos;

ClienteController controladorClientes = new ClienteController();

Menu();

void Menu()
{
    int eleccion;
    Console.WriteLine("1- Cargar un cliente");
    Console.WriteLine("2- Ver clientes registrados");
    Console.WriteLine();
    Console.Write("Opcion: ");
    eleccion = int.Parse(Console.ReadLine());

    string texto = Console.ReadLine();

    eleccion = int.Parse(texto);

    switch (eleccion)
    {
        case 1: // cargar un nuevo cliente al sistema

            Cliente clienteTemporal = CargarDatosCliente();

            // validaciones

            controladorClientes.GuardarCliente(clienteTemporal); // Agregamos el nuevo cliente a la lista de clientes

            // Clientes.Add( CargarDatosCliente() );  // Opcion de una sola linea

            Console.WriteLine(); // Espacio en blanco antes de mostrar el menu
            Menu(); // Una vez cargado, volvemos a mostrar el menú para elegir otra acción

            break;
        case 2:
            // veo clientes registrados

            MostrarClientesRegistrados(controladorClientes.ObtenerClientes());

            Console.WriteLine();
            Menu();
            break;

        default:
            Console.Clear();
            Menu();
            break;
    }
}

Cliente CargarDatosCliente()
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

    return clienteNuevo;
}

void MostrarClientesRegistrados(List<Cliente> listadoClientes)
{
    Console.WriteLine("Listado de clientes cargados en el sistema");

    foreach (var item in listadoClientes)
    {
        Console.WriteLine($"> nombre: {item.Nombre} {item.Apellido} - tel: {item.Telefono} - email: {item.Email}");
    }
}