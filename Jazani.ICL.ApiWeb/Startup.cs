using Autofac;
using Autofac.Extensions.DependencyInjection;
using Jazani.Comunes.Base.ApiWeb.Auth.Base;
using Jazani.Comunes.Base.Infraestructura.Errores;
using Jazani.Comunes.Cargadores.Bd;
using Jazani.Comunes.Cargadores.Generales;
using Jazani.Comunes.Seguridad.Infraestructura.Modulos;
using Jazani.ICL.Datos.Infraestructura.Configuraciones.Abstracciones;
using Jazani.ICL.Datos.Infraestructura.Configuraciones.Implementaciones;
using Jazani.ICL.Datos.Infraestructura.Contextos.Abstracciones;
using Jazani.ICL.Datos.Infraestructura.Contextos.Implementaciones;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Jazani.ICL.ApiWeb
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
            services.AddControllers().AddNewtonsoftJson();
            services.AddAutofac();
            services.AddAutoMapper(Assembly.Load("Jazani.ICL.Servicios"));
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            //services.AddDbContext<ConexionJazani>(options => options.UseOracle(Configuration.GetConnectionString("OracleConnection")));

            services.AddAuthentication(ComunesAuthenticationOptions.DefaultScemeName).AddScheme<ComunesAuthenticationOptions, ComunesAuthenticationHandler>(
               ComunesAuthenticationOptions.DefaultScemeName, opts => { }
               );

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Jazani.ApiWeb", Version = "v1" });
            });
        }
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new SeguridadModule(Configuration));

            builder.RegisterModule(new
                CargarOracleEF<ICLContexto,
                IICLConfiguracion,
               ICLConfiguracion, IICLUnidadDeTrabajo>(Configuration, "bd_icl", "Jazani.ICL.Datos"));

            builder.RegisterModule(new ServicioCargador("Jazani.ICL.Servicios"));
            //builder.RegisterModule(new ConfiguracionModule(Configuration));

        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Jazani.ICL.ApiWeb v1"));
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseCors(builder =>
            {
                builder.AllowAnyHeader()
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .Build();
            });

            app.UseRouting();
            app.UseExceptionHandler(errorApp => errorApp.UseCustomErrors(env, true));
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
