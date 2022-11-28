using Confitec.Application.AutoMapper;
using Confitec.Identidade.API.Configuration;
using Confitec.Infra.Data.Context;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NSE.Identidade.API.Extensions;
using System.Text;

namespace Confitec.Identidade.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<AplicationDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

         
            var appSettingSetion = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingSetion);

            var appSettings = appSettingSetion.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services.AddAuthentication();
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "API Usuarios",
                Description = "Esta API faz parte do teste tecnico para a Confitec",
                Contact = new OpenApiContact() { Name = "Silas Prado", Email = "Silas988@hotmail.com", Url = new Uri("https://www.linkedin.com/in/silas-prado-desenvolvedor") }
            }));
            //services.AddControllersWithViews(options =>
            //{
            //    options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
            //});

            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            services.AddDependencyInjectionConfiguration();
            services.AddAutoMapperConfiguration();

        }
        public void Configure(WebApplication app, IWebHostEnvironment environment)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();
        }
    }
}
