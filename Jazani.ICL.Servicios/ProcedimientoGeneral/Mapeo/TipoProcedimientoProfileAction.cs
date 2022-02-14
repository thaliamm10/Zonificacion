using AutoMapper;
using Jazani.Comunes.Utilitarios.Infraestructura.Utilitarios;
using Jazani.ICL.Datos.ProcedimientoGeneral.Entidades;
using Jazani.ICL.Servicios.ProcedimientoGeneral.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Servicios.ProcedimientoGeneral.Mapeo
{
    public class TipoProcedimientoProfileAction : IMappingAction<TipoProcedimiento, TipoProcedimientoDto>
    {
        public void Process(TipoProcedimiento source, TipoProcedimientoDto destination, ResolutionContext context)
        {
            destination.Id = RijndaelUtilitario.EncryptRijndaelToUrl(source.Id);
        }
    }
}
