using Jazani.ICL.Servicios.Auth.Usuarios.Dtos;
using Jazani.ICL.Servicios.General.Documento.Dtos;

namespace Jazani.ICL.Servicios.CompendioNormas.Dtos
{
    public class NormaDiaDocumentoDto
    {
        public string Id { get; set; }
        public long IdNormaDia { get; set; }

        public long IdDocumento { get; set; }

        public long IdUsuario { get; set; }

        /// Realaciones

        public NormaDiaDto NormaDia { get; set; }

        public DocumentoDto Documento { get; set; }

        public UsuarioDto Usuario { get; set; }

    }
}