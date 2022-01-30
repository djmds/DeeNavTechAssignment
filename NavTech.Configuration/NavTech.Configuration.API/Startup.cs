using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Identity.Web;
using NavTech.Configuration.Common;
using NavTech.Configuration.DataAccess;
using NavTech.Configuration.Models;
using NavTech.Configuration.Repository.IRepository;
using NavTech.Configuration.Repository.Repository;
using NavTech.Configuration.Service.ClientService;
using NavTech.Configuration.Service.IServiceContracts;
using NavTech.Configuration.Service.ServiceImplementations;
using Newtonsoft.Json;
using System;

namespace NavTech.Configuration.API
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
            services.AddMicrosoftIdentityWebApiAuthentication(Configuration);
            services.AddDbContext<ConfigurationContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("ConfigurationContext")));

            services.AddHttpClient(nameof(SourceTypeEnum.Merchant), httpClient =>
            {
                httpClient.BaseAddress = new Uri(Configuration["Merchant:BaseAddress"]);
            });

            services.AddHttpClient(nameof(SourceTypeEnum.CustomerReview), httpClient =>
            {
                httpClient.BaseAddress = new Uri(Configuration["CustomerReview:BaseAddress"]);
            });

            services.AddHttpClient("TokenClient", httpClient =>
            {
            });

            services.AddScoped<IConfigurationService, ConfigurationService>();
            services.AddScoped<IConfigurationRepository, ConfigurationRepository>();
            services.AddScoped<IHttpClientService, HttpClientService>();
            services.AddScoped<ITokenService, TokenService>();

            services.AddAutoMapper(cfg =>
              cfg.AddProfile<ConfigurationProfile>());
            services.AddMvcCore().AddFluentValidation();
            services.AddControllers().AddNewtonsoftJson(opt =>
            {
                opt.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
            services.AddSwaggerGen();
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
