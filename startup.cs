using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Music3.Infrastructure.UnitOfWork;
using Npgsql;
using Music3.Application;
using Music3.Infrastructure.Repositories;
using Music3.Domain;
using Music3.Infrastructure.Cross_Cutting.LoggingFactory;
using Serilog;
using PostgresSink;
using AspNet.Security.OpenIdConnect.Primitives;
//using OpenIddict.Core;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using PostgresSink;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using AutoMapper;
using Music3.Domain.PartyAgg;
using Music3.Domain.PersonAgg;
using Music3.Domain.ArtistAgg;
using Music3.Domain.TrackAgg;
using Music3.Domain.AlbumAgg;

namespace MusicDSL
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();

            //Log.Logger = new LoggerConfiguration()
            //    .Enrich.FromLogContext()
            //    .WriteTo.PostgreSqlServer(Configuration.GetConnectionString("fed"), "logs")
            //    .WriteTo.LiterateConsole()
            //    .CreateLogger();

        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            var connection = new NpgsqlConnection(Configuration.GetConnectionString("fed"));

            services.AddDbContext<FirstGenUnitOfWork>(option => option.UseNpgsql(connection));
            services.AddDbContext<SecondGenUnitOfWork>(option => option.UseNpgsql(connection));
            services.AddDbContext<ThirdGenUnitOfWork>(option => option.UseNpgsql(connection));

            services.AddScoped<MainUnitOfWork, MainUnitOfWork>();

            services.AddScoped<IPartyService, PartyService>();
            services.AddScoped<IPartyRepository, PartyRepository>();

            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IPersonRepository, PersonRepository>();

            services.AddScoped<IArtistService, ArtistService>();
            services.AddScoped<IArtistRepository, ArtistRepository>();

            services.AddScoped<ITrackService, TrackService>();
            services.AddScoped<ITrackRepository, TrackRepository>();

            services.AddScoped<IAlbumService, AlbumService>();
            services.AddScoped<IAlbumRepository, AlbumRepository>();

            //InitializePolicies(services);

            services.AddMvc();
            services.AddAutoMapper();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IApplicationLifetime appLifetime)
        {

            FedLogger.LoggerFactory = loggerFactory.AddSerilog();

            app.UseCors(builder =>
            {
                builder.WithOrigins("http://192.168.143.180:4200", "http://localhost:4200");
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
            });

            //Disable automatic JWT -> WS-Federation claims mapping used by the JWT middleware:
            //JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            //JwtSecurityTokenHandler.DefaultOutboundClaimTypeMap.Clear();


            // Authenticate users on a separate server
            //app.UseJwtBearerAuthentication(new JwtBearerOptions
            //{
            //    Audience = "FedAuth",
            //    Authority = "http://localhost:5110/",
            //    AutomaticAuthenticate = true,
            //    AutomaticChallenge = true,
            //    RequireHttpsMetadata = false,
            //    TokenValidationParameters = new TokenValidationParameters
            //    {
            //        NameClaimType = OpenIdConnectConstants.Claims.Name,
            //        RoleClaimType = OpenIdConnectConstants.Claims.ROle
            //    }
            //});

            //loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            //loggerFactory.AddDebug();

            app.UseMvc();
            appLifetime.ApplicationStopped.Register(Log.CloseAndFlush);

        }

        //private void InitializePolicies(IServiceCollection services)
        //{
        //    var scopeFactory = services.BuildServiceProvider()
        //                        .GetRequiredService<IServiceScopeFactory>();

        //    services.AddAuthorization(options =>
        //    {
        //        using (var scope = scopeFactory.CreateScope())
        //        {
        //            var provider = scope.ServiceProvider;

        //            using (var unitOfWork = provider.GetRequiredService<MainUnitOfWork>())
        //            {
        //                var permissions = unitOfWork._thirdGenUnitOfWork
        //            }
        //        }
        //    });
        //}

    }
}
