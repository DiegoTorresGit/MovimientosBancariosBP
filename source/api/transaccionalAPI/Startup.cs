using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using transaccionalAPI.Context;
using transaccionalAPI.Models;
using transaccionalAPI.Repositories;
using transaccionalAPI.Repositories.Implements;

namespace transaccionalAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "transaccionalAPI", Version = "v1" });
            });
            services.AddDbContext<ApplicationDBContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("Conexion")));
            services.AddScoped<ITipoCuentaRepository, TipoCuentaRepository>();
            services.AddScoped<ICuentasRepository, CuentasRepository>();
            services.AddScoped<IPersonaRepository, PersonaRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IMovimientosRepository, MovimientosRepository>();
            services.AddScoped<IEstadoCuenta, EstadoCuentaRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "transaccionalAPI v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
