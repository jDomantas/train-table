using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NodaTime;
using NodaTime.Serialization.JsonNet;
using Serilog;
using System.Collections.Generic;
using TrainTable.Contract;
using TrainTable.Evaluators;
using TrainTable.Repositories;
using TrainTable.Services;
using TrainTable.Validators;

namespace TrainTable
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
            services
                .AddMvc()
                .AddJsonOptions(opt => opt
                    .SerializerSettings
                    .ConfigureForNodaTime(DateTimeZoneProviders.Tzdb));

            Log.Logger = new LoggerConfiguration()
                .WriteTo.Console()
                .MinimumLevel.Debug()
                .CreateLogger();

            services.AddSingleton<IRepository<Driver>, HardcodedDriverRepository>();
            services.AddSingleton<IRepository<Train>, HardcodedTrainRepository>();

            services.AddSingleton<IEvaluator, DispersionEvaluator>();

            services.AddSingleton<IChecker, AtLeastTwelveHoursOfRestBetweenShifts>();
            services.AddSingleton<IChecker, NoAssignmentsCollideChecker>();
            services.AddSingleton<IChecker, NoMoreThanFortyEightHoursInSevenDaysChecker>();
            services.AddSingleton<IChecker, NoMoreThanSixDaysPerWeekChecker>();
            services.AddSingleton<IChecker, NoMoreThanTwoNightShiftsInARowChecker>();
            services.AddSingleton<IChecker, ThirtyFiveConescutiveHoursOfRestPerWeekChecker>();

            var sp = services.BuildServiceProvider();
            var checker = new CompositeChecker(sp.GetService<IEnumerable<IChecker>>());
            services.AddSingleton<IChecker>(checker);

            services.AddSingleton<RandomSchedulingService>();
            services.AddSingleton<PrioritizingSchedulingService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
