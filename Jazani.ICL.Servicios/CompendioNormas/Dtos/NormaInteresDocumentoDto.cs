using System;
using Jazani.ICL.Servicios.Auth.Usuarios.Dtos;
using Jazani.ICL.Servicios.General.Documento.Dtos;

namespace Jazani.ICL.Servicios.CompendioNormas.Dtos
{
    public class NormaInteresDocumentoDto
    {
        public string Id { get; set; }
        public long IdNormaInteres { get; set; }
        public long IdDocumento { get; set; }
        public long IdNormaDiaDocumento { get; set; }
        public long IdUsuario { get; set; }
        public DateTime FechaModificacion { get; set; }
        //Relaciones
        public DocumentoDto Documento { get; set; }
        public NormaDiaDocumentoDto NormaDiaDocumento { get; set; }
        public UsuarioDto Usuario { get; set; }
    }
}