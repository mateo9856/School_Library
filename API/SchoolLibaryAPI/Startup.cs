using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using AutoMapper;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using SchoolLibaryAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolLibaryAPI
{
    [EnableCors("AllowAllOrigins")]
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<LibaryDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("LibaryDatabase")));
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins", builder => builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });
            services.AddScoped<ILibaryRepository, LibaryRepository>();
            services.AddScoped<ILoanRepository, LoanRepository>();
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddAutoMapper(c=>c.AddProfile<AutoMapping>(), typeof(Startup));
            services.AddControllers();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseCors("AllowAllOrigins");
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
