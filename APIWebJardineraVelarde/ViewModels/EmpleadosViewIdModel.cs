﻿using APIWebJardineraVelarde.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace APIWebJardineraVelarde.ViewModels
{
    public class EmpleadosIdViewModel
    {
        [Key]
        public int codigo_empleado { get; set; }
        public string nombre { get; set; }
        public string apellido1 { get; set; }
        public string apellido2 { get; set; }
        public string extension { get; set; }
        public string email { get; set; }
        public string codigo_oficina { get; set; }
        public int codigo_jefe { get; set; }
        public string puesto { get; set; }

        public EmpleadosIdViewModel()
        {

        }

        public EmpleadosIdViewModel(int codigo_empleado, string nombre, string apellido1, string apellido2, string extension, string email,
            string codigo_oficina, int codigo_jefe, string puesto)
        {
            this.codigo_empleado = codigo_empleado;
            this.nombre = nombre;
            this.apellido1 = apellido1;
            this.apellido2 = apellido2;
            this.extension = extension;
            this.email = email;
            this.codigo_oficina = codigo_oficina;
            this.codigo_jefe = codigo_jefe;
            this.puesto = puesto;
        }

        public EmpleadosIdViewModel(Empleado e)
        {
            this.codigo_empleado = e.codigo_empleado;
            this.nombre = e.nombre;
            this.apellido1 = e.apellido1;
            this.apellido2 = e.apellido2;
            this.extension = e.extension;
            this.email = e.email;
            this.codigo_oficina = e.codigo_oficina;
            this.codigo_jefe = e.codigo_jefe;
            this.puesto = e.puesto;
        }
    }
}
