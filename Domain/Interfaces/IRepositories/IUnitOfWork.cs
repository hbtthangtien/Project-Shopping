using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        public IAccountRepository Accounts { get; }

        public IBrandRepository Brands { get; }

        public ICartItemRepository CartItems { get; }

        public ICategoryRepository Categories { get; }

        public IProductRepository Products { get; }

        public IOrderRepository Orders { get; } 

        public IColorRepository Colors { get; }

        public ICustomerRepository Customers { get; }

        public IFeedbackRepository Feedbacks { get; }

        public IImageFeedbackRepository FeedbackImages { get; }

        public IOrderDetailRepository OrderDetails { get; }

        public IProductColorTypeRepository ProductColorTypes { get; }

        public IProductImageRepository ProductImages { get; }

        public IProfileRepository Profiles { get; }

        public ISearchHistoryRepository SearchHistories { get; }

        public IStoreRepository Stores { get; }

        public ISubCategoryRepository SubCategories { get; }

        public ITypeRepository Types { get; }

        public ICategoryTypeRepository CategoryTypes { get; }
        Task<int> CommitAsync();
    }
}
