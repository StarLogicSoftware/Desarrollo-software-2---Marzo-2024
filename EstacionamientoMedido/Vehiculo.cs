﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamientoMedido
{
    public class Vehiculo
    {
        public string Marca { get; set; }
        public string Modelo  { get; set; }
        public string Color { get; set; }
        public string Patente { get; set; }
        public Estacionamiento Estacionamiento { get; set; }
        public Cliente Cliente { get; set; }
    }
}
