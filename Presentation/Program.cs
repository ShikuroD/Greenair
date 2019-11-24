using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Threading.Tasks;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.Entities;
using Infrastructure;
using ApplicationCore.Interfaces;
namespace Presentation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                try
                {
                    var greenairContext = services.GetRequiredService<GreenairContext>();


                    IUnitOfWork unit = new UnitOfWork(greenairContext);
                    //greenairContext.Employers.RemoveRange(greenairContext.Employers);
                    //greenairContext.Customers.RemoveRange(AskNoTracking(greenairContext.Customers.ToList()));
                    //greenairContext.Set<Maker>().RemoveRange(greenairContext.Set<Maker>());
                    // greenairContext.Set<Job>().RemoveRange(greenairContext.Set<Job>());

                    //greenairContext.SaveChanges();
                    // var t = unit.Customers.GetBy("002");
                    // if (t == null)
                    // {
                    //     Console.WriteLine("NULL");
                    // }
                    // else
                    // {
                    //     t.FirstName = "Yasuo20gg";
                    //     unit.Customers.Update(t);
                    //     greenairContext.SaveChanges();
                    // }
                    //var t = unit.Customers.GetBy("003");
                    // foreach (var t in temp)


                    // Console.WriteLine(t.FirstName);
                    int t = 1324354;
                    var s = String.Format("{0:00000}", t);
                    Console.WriteLine(s);
                    DataSeed.Initialize(greenairContext);


                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "Database error occured when putting data.");
                }
            }
            host.Run();

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
    }
}