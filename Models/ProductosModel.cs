﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ItesDemo.Models
{
    public class ProductosModel
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string tipo { get; set; }
        public string descripcion { get; set; }
        public decimal precio { get; set; }
        public string urlImagen { get; set; }
        public int stock { get; set; }
    }
}
