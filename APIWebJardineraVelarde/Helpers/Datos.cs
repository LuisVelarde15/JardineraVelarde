using APIWebJardineraVelarde.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIWebJardineraVelarde.Helpers
{
    public class Datos : DbContext
    {
        public DbSet<Gama_Productos> gama_producto { get; set; } //Tabla Gama Productos de la base de datos
        public DbSet<Oficinas> Oficina { get; set; } //Tabla Oficina de la base de datos
        public DbSet<Empleado> Empleado { get; set; } //Tabla categoria de la base de datos

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string Conexion = @"Server = jardineravelardedb.database.windows.net;
                                Database = jardineravelarde;
                                User = admindb;
                                Password = luis1598*;";
            optionsBuilder.UseSqlServer(Conexion);
        }
    }
}
