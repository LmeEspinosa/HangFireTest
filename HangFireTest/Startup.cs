using System;
using System.Threading.Tasks;
using Hangfire;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(HangFireTest.Startup))]

namespace HangFireTest
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseHangfireDashboard("/tareas");
            //var jobId = BackgroundJob.Enqueue(
            //    () => Console.WriteLine("Fire-and-forget!"));
            RecurringJob.AddOrUpdate(
                () => Console.WriteLine("Recurring!"),
                Cron.Daily);
        }
    }
}
