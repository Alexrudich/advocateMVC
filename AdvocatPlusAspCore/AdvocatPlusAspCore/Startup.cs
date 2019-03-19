﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvocatPlusAspCore.Models.Feedback;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace AdvocatPlusAspCore
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
                SmtpPassword = "myastrovskaya3",
                SmtpServer = "smtp.mail.ru",
                SmtpUsername = "nastya0921@mail.ru"
            };
            EmailAddress FromEmailAddress = new EmailAddress
            {
                Address = "nastya0921@mail.ru",
                Name = "Анастасия Рудич"
            };
            services.AddSingleton<EmailServerConfiguration>(config);
            services.AddTransient<IEmailService, MailKitEmailService>();
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
