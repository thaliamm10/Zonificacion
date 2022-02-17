using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Jazani.ICL.Datos.Zonificacion.Entidades
{
    public class Ubigeo
    {
        //CODIGO_UBIGEO
        [Key]
        public string CodigoUbigeo { get; set; }
        //CODIGO_PADRE
        public string CodigoPadre { get; set; }
        //CODIGO_PARCIAL
        public string CodigoParcial { get; set; }
        //NOMBRE
        public string Nombre { get; set; }
        //NIVEL
        public string Nivel { get; set; }
        //NOMBRE_COMPLETO
        public string NombreCompleto { get; set; }
        //FECHA_REGISTRO
        public DateTime FechaRegistro { get; set; }
        //ESTADO
        public int Estado { get; set; }

        public virtual ICollection<ZonificacionParametro> ZonificacionParametro { get; set; }
        public Ubigeo()
        {
            FechaRegistro = DateTime.UtcNow;
            Estado = 1;
        }
    }
}