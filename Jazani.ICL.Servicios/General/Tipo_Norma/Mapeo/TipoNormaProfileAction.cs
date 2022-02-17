using AutoMapper;
using Jazani.Comunes.Utilitarios.Infraestructura.Utilitarios;
using Jazani.ICL.Datos.General.Entidades;
using Jazani.ICL.Servicios.General.Tipo_Norma.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Servicios.General.Tipo_Norma.Mapeo
{
    class TipoNormaProfileAction : IMappingAction<Datos.General.Entidades.Tipo_Norma, TipoNormaDto>
    {
        public void Process(Datos.General.Entidades.Tipo_Norma source, TipoNormaDto destination, ResolutionContext context)
        {
            destination.Id = RijndaelUtilitario.EncryptRijndaelToUrl(source.ID_TIPO_NORMA);

        }
    }
}
