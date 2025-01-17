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
    public class OrderDetailService : BaseService, IOrderDetailService
    {
        public OrderDetailService(IMapper mapper, IUnitOfWork unitOfWork) 
            : base(mapper, unitOfWork)
        {
        }
    }
}
