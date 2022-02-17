using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Jazani.ICL.Datos.Zonificacion.Entidades.Mapeo
{
    public class ZonificacionParametroMapeo : IEntityTypeConfiguration<ZonificacionParametro>
    {
        public void Configure(EntityTypeBuilder<ZonificacionParametro> builder)
        {
            builder.ToTable("ZONIFICACION_PARAMETRO");
            builder.HasKey(t => t.Id);
            // ID_ZONIFICACION_PARAMETRO
            builder.Property(t => t.Id).HasColumnName("ID_ZONIFICACION_PARAMETRO");
            // CODIGO
            builder.Property(e => e.Codigo).HasColumnName("CODIGO").IsUnicode(false).HasMaxLength(100);
            // ZONIFICACION
            builder.Property(e => e.Zonificacion).HasColumnName("ZONIFICACION").IsUnicode(false);
            // ABREVIATURA
            builder.Property(e => e.Abreviatura).HasColumnName("ABREVIATURA").IsUnicode(false);
            // CODIGO_UBIGEO
            builder.Property(e => e.CodigoUbigeo).HasColumnName("CODIGO_UBIGEO").IsUnicode(false).HasMaxLength(500);
            // ID_TIPO_NORMA
            builder.Property(e => e.IdTipoNorma).HasColumnName("ID_TIPO_NORMA").IsRequired();
            // NUMERO_NORMATIVA
            builder.Property(e => e.NumeroNormativa).HasColumnName("NUMERO_NORMATIVA").IsUnicode(false).HasMaxLength(500);
            // ID_SECTOR
            builder.Property(e => e.IdSector).HasColumnName("ID_SECTOR").IsUnicode(false).HasMaxLength(500);
            // DENSIDAD_NETA,
            builder.Property(e => e.DensidadNeta).HasColumnName("DENSIDAD_NETA").IsUnicode(false).HasMaxLength(500);
            // AREA_LOTE_MIN_NROMATIVO
            builder.Property(e => e.AreaLoteMinNormativo).HasColumnName("AREA_LOTE_MIN_NORMATIVO").IsUnicode(false).HasMaxLength(500);
            // FRENTE_LOTE_MIN_NORMATIVO
            builder.Property(e => e.FrenteLoteMinNormativo).HasColumnName("FRENTE_LOTE_MIN_NORMATIVO").IsUnicode(false).HasMaxLength(500);
            // ALTURA_MAX_EDIFICACION_PISO
            builder.Property(e => e.AlturaMaxEdificacionPiso).HasColumnName("ALTURA_MAX_EDIFICACION_PISO").IsUnicode(false).HasMaxLength(500);
            //ALTURA_MAX_EDIFICACION
            builder.Property(e => e.AlturaMaxEdificacion).HasColumnName("ALTURA_MAX_EDIFICACION").IsUnicode(false).HasMaxLength(500);
            // PORCENTAJE_MIN_AREA_LIBRE
            builder.Property(e => e.PorcentajeMinAreaLibre).HasColumnName("PORCENTAJE_MIN_AREA_LIBRE").IsUnicode(false).HasMaxLength(500);
            // USO_PERMITIDO
            builder.Property(e => e.UsoPermitido).HasColumnName("USO_PERMITIDO").IsUnicode(false).HasMaxLength(500);
            // REQUIERE_ESTACIONAMIENTO
            builder.Property(e => e.RequiereEstacionamiento).HasColumnName("REQUIERE_ESTACIONAMIENTO").IsUnicode(false).HasMaxLength(500);
            // COEFICIENTE_EDIFICACION
            builder.Property(e => e.CoeficienteEdificacion).HasColumnName("COEFICIENTE_EDIFICACION").IsUnicode(false).HasMaxLength(500);
            //USO_COMPATIBLES
            builder.Property(e => e.UsoCompatibles).HasColumnName("USO_COMPATIBLES").IsUnicode(false).HasMaxLength(500);
            // NOTA
            builder.Property(e => e.Nota).HasColumnName("NOTA").IsUnicode(false).HasMaxLength(500);
            // OBSERVACION
            builder.Property(e => e.Observacion).HasColumnName("OBSERVACION").IsUnicode(false).HasMaxLength(500);
            //  ESTADO_CULMINADO,
            builder.Property(e => e.EstadoCulminado).HasColumnName("ESTADO_CULMINADO").IsUnicode(false).HasMaxLength(500);
            //   FECHA_REGISTRO
            builder.Property(e => e.FechaRegistro).HasColumnName("FECHA_REGISTRO");
            //   ESTADO
            builder.Property(e => e.Estado).HasColumnName("ESTADO");

            builder.HasOne(e => e.TipoNormativa).WithMany(
                b => b.ZonificacionParametro).HasForeignKey(c
                => c.IdTipoNorma);
            builder.HasOne(e => e.Sector).WithMany(
                b => b.ZonificacionParametro).HasForeignKey(c
                => c.IdSector);
            builder.HasOne(e => e.Ubigeo).WithMany(
                b => b.ZonificacionParametro).HasForeignKey(c
                => c.CodigoUbigeo);
        }
    }
}