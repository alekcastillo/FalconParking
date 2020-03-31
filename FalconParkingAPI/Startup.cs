using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using FalconParking.Infrastructure.Commands;
using FalconParking.Infrastructure.Commands.Handlers;
using FalconParkingAPI.Mappings;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using FalconParking.Domain.Abstractions.Repositories;
using FalconParking.Domain;
using FalconParking.Infrastructure.Repositories;
using FalconParking.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace FalconParkingAPI
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
            services.AddEntityFrameworkNpgsql().AddDbContext<FalconParkingDbContext>(opt =>
                opt.UseNpgsql(Configuration.GetConnectionString("FalconParkingDbConnection"),
                b => b.MigrationsAssembly("FalconParkingAPI")));
            services.AddControllers();
            //Mediator handlers
            services.AddMediatR(typeof(OccupyParkingSlotCommand).Assembly, typeof(OccupyParkingSlotCommandHandler).Assembly);
            //Mappers
            services.AddAutoMapper(typeof(RequestMappingsProfile).Assembly);
            //Repositories
            services.AddTransient<IParkingLotRepository, ParkingLotRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
