using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstacionamientoMedido.Modelos;

namespace EstacionamientoMedido.Controladores
{
    public class ClienteController
    {

        Repositorio repo = new Repositorio();

        public void GuardarCliente(Cliente c)
        {
            repo.Clientes.Add(c);
        }

        public List<Cliente> ObtenerClientes()
        {
            return repo.Clientes;
        }
    }
}
