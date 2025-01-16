using Domain.Interfaces.IRepositories;
using Persistence.DatabaseContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TikilazapeeDbContext _context;


        public UnitOfWork(TikilazapeeDbContext context, 
               IAccountRepository accounts,
               IBrandRepository brands,
               ICartItemRepository cartItems,
               ICategoryRepository categories,
               IProductRepository products,
               IOrderRepository orders,
               IColorRepository colors,
               ICustomerRepository customers,
               IFeedbackRepository feedbacks,
               IImageFeedbackRepository feedbackImages,
               IOrderDetailRepository orderDetails,
               IProductColorTypeRepository productColorTypes,
               IProductImageRepository productImages,
               IProfileRepository profiles,
               ISearchHistoryRepository searchHistories,
               IStoreRepository stores,
               ISubCategoryRepository subCategories,
               ITypeRepository types,
               ICategoryTypeRepository categoryTypes)
        {
            Accounts = accounts;
            Brands = brands;
            CartItems = cartItems;
            Categories = categories;
            Products = products;
            Orders = orders;
            Colors = colors;
            Customers = customers;
            Feedbacks = feedbacks;
            FeedbackImages = feedbackImages;
            OrderDetails = orderDetails;
            ProductColorTypes = productColorTypes;
            ProductImages = productImages;
            Profiles = profiles;
            SearchHistories = searchHistories;
            Stores = stores;
            SubCategories = subCategories;
            Types = types;
            CategoryTypes = categoryTypes;
            _context = context;
        }

   
        public IAccountRepository Accounts { get; private set; }

        public IBrandRepository Brands { get; private set; }

        public ICartItemRepository CartItems { get; private set; }

        public ICategoryRepository Categories { get; private set; }

        public IProductRepository Products { get; private set; }

        public IOrderRepository Orders { get; private set; }

        public IColorRepository Colors { get; private set; }

        public ICustomerRepository Customers { get; private set; }

        public IFeedbackRepository Feedbacks { get; private set; }

        public IImageFeedbackRepository FeedbackImages { get; private set; }

        public IOrderDetailRepository OrderDetails { get; private set; }

        public IProductColorTypeRepository ProductColorTypes { get; private set; }

        public IProductImageRepository ProductImages { get; private set; }

        public IProfileRepository Profiles { get; private set; }

        public ISearchHistoryRepository SearchHistories { get; private set; }

        public IStoreRepository Stores { get; private set; }

        public ISubCategoryRepository SubCategories { get; private set; }

        public ITypeRepository Types { get; private set; }

        public ICategoryTypeRepository CategoryTypes { get; private set; }

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
