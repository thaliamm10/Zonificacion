using System;
using System.Collections.Generic;
using Jazani.ICL.Datos.CompendioNormas.Entidades;

namespace Jazani.ICL.Datos.General.Entidades
{
    public class Documento
    {
        public long Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Contenido { get; set; }
        public string MineType { get; set; }
        public string Extencion { get; set; }
        public string NombreOriginal { get; set; }
        public string UbicacionFisica { get; set; }

        public DateTime FechaRegistro { get; set; }
        public int Estado { get; set; }
        // 
        public virtual ICollection<NormaInteresDocumento> NormaInteresDocumento { get; set; }

        public virtual ICollection<NormaDiaDocumento> NormaDiaDocumento { get; set; }

        public Documento()
        {
            FechaRegistro = DateTime.UtcNow;
            Estado = 1;
        }
    }
}