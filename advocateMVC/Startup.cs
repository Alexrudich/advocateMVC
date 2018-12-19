using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using advocateMVC.Models.Feedback;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace advocateMVC
{
    public class Startup
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfiguration _config;
        private readonly ILoggerFactory _loggerFactory;

        public Startup(IHostingEnvironment env, IConfiguration config,
            ILoggerFactory loggerFactory)
        {
            _env = env;
            _config = config;
            _loggerFactory = loggerFactory;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            var logger = _loggerFactory.CreateLogger<Startup>();

            if (_env.IsDevelopment())
            {
                logger.LogInformation("Development environment"); // Development service configuration
            }
            else
            {
                logger.LogInformation($"Environment: {_env.EnvironmentName}"); // Non-development service configuration
            }

            EmailServerConfiguration config = new EmailServerConfiguration
            {
                SmtpPassword = "password",
                SmtpServer = "smtp.gmail.com",
                SmtpUsername = "kenarius7@gmail.com"
            };
            EmailAddress FromEmailAddress = new EmailAddress
            {
                Address = "kenarius7@gmail.com",
                Name = "Alex Rudich"
            };
            services.AddSingleton<EmailServerConfiguration>(config);
            services.AddTransient<IEmailService, MailKitEmailService> ();
            services.AddSingleton<EmailAddress>(FromEmailAddress);
            services.AddMvc();

        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
