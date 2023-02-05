using Serilog.Core;
using Serilog.Events;
using Serilog;
using AutoMapper;
using DotnetApiBoilerplatev2._0.Core;
using DotnetApiBoilerplatev2._0.ProcessorManagers.DataProcessorManager;
using DotnetApiBoilerplatev2._0.ProcessorManager.AccountDetailsProcessorManager;
using DotnetApiBoilerplatev2._0.ExceptionHandlers;
using DotnetApiBoilerplatev2._0.Common;
using DotnetApiBoilerplatev2._0.Infrastructure;
using Microsoft.EntityFrameworkCore;
using DotnetApiBoilerplatev2._0.Core.Interfaces;
using DotnetApiBoilerplatev2._0.Core.Interfaces.AccountDetails;
using DotnetApiBoilerplatev2._0.Infrastructure.Repositories.AccountDetails;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;

namespace DotnetApiBoilerplatev2._0
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {

            var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("config/appsettings.json", optional: false, reloadOnChange: true)
             .AddJsonFile("secrets/secrets.json", optional: false, reloadOnChange: true);
            Configuration = builder.Build();

            var levelSwitch = new LoggingLevelSwitch();
            levelSwitch.MinimumLevel = LogEventLevel.Error;

            Log.Logger = new LoggerConfiguration()
                                .ReadFrom.Configuration(Configuration)
                                .MinimumLevel.Override("Microsoft", levelSwitch)
                                .MinimumLevel.Override("System.Net.Http.HttpClient", levelSwitch)
                                .CreateLogger();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            
            services.AddControllers(options =>
            {
                options.Filters.Add(new ConsumesAttribute("application/json"));
                options.Filters.Add(new ProducesAttribute("application/json"));
            });

            services.AddScoped<IDataProcessorManager, DataProcessorManager>();
            services.AddScoped<IAuthenticationProcessorManager, AuthenticationProcessorManager>();

            services.AddSingleton<IExceptionHandler, ExceptionHandler>();
            services.AddSingleton<CustomExceptionFilter>();

            services.AddTransient<DataContext>();
            services.AddSingleton<IUnitOfWork, UnitOfWork>();

            services.AddSingleton<IGroupAccountsRepository, GroupAccountsRepository>();
            services.AddSingleton<IRolesRepository, RolesRepository>();
            services.AddSingleton<IAccountsRepository, AccountsRepository>();

            services.AddOptions();

            services.AddMvc().AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.IgnoreNullValues = true;
            });

            services.AddHttpContextAccessor();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.BuildServiceProvider();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

            app.UseRouting();
            //app.UseAuthorization(); //TO DO: Add Authentication Scheme
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
