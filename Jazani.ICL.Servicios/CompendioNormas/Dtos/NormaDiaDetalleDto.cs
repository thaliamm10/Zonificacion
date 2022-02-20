namespace Jazani.ICL.Servicios.CompendioNormas.Dtos
{
    public class NormaDiaDetalleDto
    {
        public string Id { get; set; }
        public long IdNormaDia { get; set; }
        public string Nombre { get; set; }
        public string Sumilla { get; set; }

        public NormaDiaDto NormaDia { get; set; }
    }
}