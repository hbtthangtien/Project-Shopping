using AutoMapper;
using Domain.DTOs.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.AutoMapper
{
    public class ApplicationMapper : Profile
    {
        public ApplicationMapper() {
            CreateMap<Domain.Entities.Store, RequestDTORegisterStore>().ReverseMap();
        }
    }
}
