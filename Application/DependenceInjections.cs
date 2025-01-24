using Application.AutoMapper;
using Application.Services;
using Domain.Interfaces.IServices;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class DependenceInjections
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ApplicationMapper));
            services.AddScoped<IAccountService, AccountService>();
            services.AddScoped<IBrandService, BrandService>();
            services.AddScoped<ICartItemService, CartItemService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryTypeService, CategoryTypeService>();
            services.AddScoped<IColorService, ColorService>();
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IFeedbackService, FeedbackService>();
            services.AddScoped<IImageFeedbackService,ImageFeedbackService>();
            services.AddScoped<IOrderDetailService, OrderDetailService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IProductColorTypeService, ProductColorTypeService>();
            services.AddScoped<IProductImageService, ProductImageService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<ISearchHistoryService, SearchHistoryService>();
            services.AddScoped<IStoreService, StoreService>();
            services.AddScoped<ISubCategoryService, SubCategoryService>();
            services.AddScoped<ITypeService, TypeService>();
            services.AddScoped<IAuthenticateService, AuthenticateService>();
            services.AddScoped<ISenderService, EmailService>();
            return services;
        }
    }
}
