using AutoMapper;
using GeneratorProject.BLL.DTO;
using System;
using System.Collections.Generic;
using GeneratorProject.DAL.Entities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorProject.BLL.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Mapping Data for Generator Service

            this.CreateMap<GeneratorRequest, Generator>()
                .ForMember(d => d.Id,
                    op => op.MapFrom(srs => srs.Id))
                .ForMember(d => d.Name,
                op => op.MapFrom(srs => srs.Name))
                .ForMember(d => d.Description,
                op => op.MapFrom(srs => srs.Description))
                .ForMember(d => d.Location,
                op => op.MapFrom(srs => srs.Location));

            this.CreateMap<Generator, GeneratorResponse>()
                .ForMember(d => d.Id,
                op => op.MapFrom(srs => srs.Id))
                .ForMember(d => d.Name,
                op => op.MapFrom(srs => srs.Name))
                .ForMember(d => d.Description,
                op => op.MapFrom(srs => srs.Description))
                .ForMember(d => d.Location,
                op => op.MapFrom(srs => srs.Location));

            #endregion
        }
    }
}
