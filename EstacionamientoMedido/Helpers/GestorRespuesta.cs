using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamientoMedido.Helpers
{
    public class GestorRespuesta<T>
    {
        public T Respuesta;
        public bool HayError;
        public string MensajeError;
    }
}
