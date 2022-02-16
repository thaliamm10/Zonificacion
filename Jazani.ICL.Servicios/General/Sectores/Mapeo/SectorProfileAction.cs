using AutoMapper;
using Jazani.Comunes.Utilitarios.Infraestructura.Utilitarios;
using Jazani.ICL.Datos.General.Entidades;
using Jazani.ICL.Servicios.General.Sectores.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.ICL.Servicios.General.Sectores.Mapeo
{
    class SectorProfileAction : IMappingAction<Sector, SectorDto>
    {
        public void Process(Sector source, SectorDto destination, ResolutionContext context)
        {
            destination.Id = RijndaelUtilitario.EncryptRijndaelToUrl(source.Id);
        }
    }
}
