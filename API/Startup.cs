using AutoMapper;
using FalconParkingAPI.Mappings;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Domain.Abstractions.Repositories;
using Domain;
using Infrastructure.Repositories;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Domain.Events;
using System.Threading;
using Application.Abstractions;
using Application.MessageBus;
using Application.Events;
using System.Reflection;
using System;
using Application.Events.Handlers;

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

            //Prevent the reference loop in parkinglots and slots
            services.AddControllers();

            services.AddScoped<IMessageBus, MessageBus>();

            //We use any class from the FalconParking project to add MediatR to its queries, commands, events, and handlers
            services.AddMediatR(typeof(DomainEvent).Assembly);
            services.AddMediatR(typeof(ParkingLotEventHandlers).Assembly);

            //Mappers
            services.AddAutoMapper(typeof(RequestMappingsProfile).Assembly);
            //Repositories
            services.AddScoped<IParkingLotRepository, ParkingLotRepository>();
            services.AddTransient<IParkingLotViewRepository, ParkingLotViewRepository>();
            services.AddScoped<IParkingSlotRepository, ParkingSlotRepository>();
            services.AddTransient<IParkingSlotViewRepository, ParkingSlotViewRepository>();

            //services.AddSession();
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

            //app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
