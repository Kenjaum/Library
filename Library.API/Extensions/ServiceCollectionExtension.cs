using Library.Core.Repositories;
using Library.Core.Services;
using Library.Infrastructure.Auth;
using Library.Infrastructure.Persistence.Repositories;

namespace Library.API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ILoanRepository, LoanRepository>();

            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}
