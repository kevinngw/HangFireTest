using System;
using System.Collections.Generic;
using System.Linq;
using Hangfire;
using Hangfire.Mongo;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(WebApplication1.Startup))]

namespace WebApplication1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            GlobalConfiguration.Configuration.UseMongoStorage("mongodb://docker.local:32768/", "ApplicationDatabase");
            //GlobalConfiguration.Configuration.UseMongoStorage("<connection string or its name>","");

            //GlobalConfiguration.Configuration.UseSqlServerStorage("<connection string or its name>");

            app.UseHangfireDashboard();
            app.UseHangfireServer();
        }
    }
}
