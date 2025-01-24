using Domain.Interfaces.IRepositories;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public static class DependenceInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<ICartItemRepository, CartItemRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryTypeRepository, CategoryTypeRepository>();
            services.AddScoped<IColorRepository, ColorRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IFeedbackRepository,FeedbackRepository>();
            services.AddScoped<IImageFeedbackRepository, ImageFeedbackRepository>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductColorTypeRepository, ProductColorTypeRepository>();
            services.AddScoped<IProductImageRepository, ProductImageRepository>();
            services.AddScoped<IProfileRepository, ProfileRepository>();
            services.AddScoped<IRoleRepository,RoleRepository>();
            services.AddScoped<ISearchHistoryRepository, SearchHistoryRepository>();
            services.AddScoped<IStoreRepository, StoreRepository>();
            services.AddScoped<ISubCategoryRepository,SubCategoryRepository>();
            services.AddScoped<ITypeRepository, TypeRepository>();
            return services;
        }
    }
}
