using AutoMapper;
using Domain.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class BaseService
    {
        protected readonly IUnitOfWork _unitOfWork;

        protected readonly IMapper _mapper;

        public BaseService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
    }
    }
}
