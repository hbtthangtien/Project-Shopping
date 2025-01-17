using AutoMapper;
using Domain.Interfaces.IRepositories;
using Domain.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProfileService : BaseService, IProfileService
    {
        public ProfileService(IMapper mapper, IUnitOfWork unitOfWork) 
            : base(mapper, unitOfWork)
        {
        }
    }
}
