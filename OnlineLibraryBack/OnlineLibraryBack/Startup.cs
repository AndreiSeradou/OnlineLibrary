using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineLibraryBack.Configuration;
using DataAccessLayer.Data;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;
using DataAccessLayer.Entities;
using DataAccessLayer.Configuration;
using BusinessLayer.Configuration;
using OnlineLibraryPresentationLayer.Configuration;
using Configuration.GeneralConfiguration;

namespace OnlineLibraryBack
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.RegisterRepositories().RegisterService().RegisterDbContext(Configuration.GetConnectionString(GeneralConfiguration.DbConnection));
            services.RegisterBLMappingConfig();
            services.RegisterDLMappingConfig();
            services.RegisterPLMappingConfig();

            services.Configure<JwtConfig>(Configuration.GetSection(GeneralConfiguration.JwtConfig));

            services.AddHttpContextAccessor();

            var key = Encoding.ASCII.GetBytes(Configuration[GeneralConfiguration.JwtSecret]);

            var tokenValidationParams = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                RequireExpirationTime = false,
                ClockSkew = TimeSpan.Zero
            };

            services.AddSingleton(tokenValidationParams);

            services.AddAuthentication(options => {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(jwt => {
                jwt.SaveToken = true;
                jwt.TokenValidationParameters = tokenValidationParams;
            });

            services.AddIdentity<User, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                        .AddEntityFrameworkStores<ApiDbContext>();

            services.AddControllers();
            

            services.AddCors(options =>
            {
                options.AddPolicy(GeneralConfiguration.Cors, builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

            services.AddAuthorization(options =>
            {
                options.AddPolicy(GeneralConfiguration.Policy,
                    policy => policy.RequireClaim(GeneralConfiguration.PolicyClaim));
            });
        }

        
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
           
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseCors(GeneralConfiguration.Cors);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
