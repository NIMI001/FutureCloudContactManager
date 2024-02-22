using FutureCloudContactManager.Email;
using FutureCloudContactManager.Infrastructure.Persistent;
using FutureCloudContactManager.Models;
using FutureCloudContactManager.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace FutureCloudContactManager.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureDbContext (this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddDbContext<ContactContext>(options => options.UseSqlServer(configuration.GetConnectionString("ToluwanimiLocalDB")));
        }
        public static void ConfigureEmailService(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSetting>(configuration.GetSection("SmtpSettings"));
            services.AddScoped<IEmailService, EmailService>();
        }

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole>(o =>
            {
                o.SignIn.RequireConfirmedEmail = false;
                o.User.RequireUniqueEmail = true;
                o.Password.RequireDigit = true;
                o.Password.RequireUppercase = true;
                o.Password.RequireNonAlphanumeric = true;
                o.Password.RequiredLength = 8;
            }).AddEntityFrameworkStores<ContactContext>()
            .AddDefaultTokenProviders();
        }


        public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("JwtSettings");
            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings["validIssuer"],
                    ValidAudience = jwtSettings["validAudience"],
                    IssuerSigningKey = new
                    SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["TokenKey"]))
                };
            });
        }
        public static void ConfigureTokenService(this IServiceCollection services)
        {
            services.AddScoped<ITokenService, TokenService>();
        }
    }
    
}
