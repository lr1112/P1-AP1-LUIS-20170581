﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P1_AP1_LUIS_20170581.Entidades
{
    public class Aportes
    {
        [Key]
        public int AporteId { get; set; }

        public DateTime Fecha { get; set; }

        public string Persona { get; set; }
        public string Concepto { get; set; }
        public int Monto { get; set; }

    }
}