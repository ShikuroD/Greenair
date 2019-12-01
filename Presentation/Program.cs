
using System.Runtime.CompilerServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Interfaces;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ApplicationCore.Services;
using AutoMapper;
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

                    //unit.Employees.RemoveRange(unit.Employees.GetAll());
                    //unit.Customers.RemoveRange(unit.Customers.GetAll());

                    // var cus = unit.Planes.GetByAsync(null).GetAwaiter().GetResult();
                    // if (cus == null) Console.WriteLine("NULL cus"); else Console.WriteLine(cus.MakerId);


                    // var cus2 = unit.Customers.getCustomerByName("Phung qUoc hai").GetAwaiter().GetResult();
                    // if (cus2 == null) Console.WriteLine("NULL cus"); else Console.WriteLine("{0} {1}", cus2.ElementAt(0).Id, cus2.ElementAt(0).FullName);


                    // var acc = unit.Accounts.GetByAsync("cus4").GetAwaiter().GetResult();
                    // if (acc == null) Console.WriteLine("NULL acc"); else Console.WriteLine(acc.Username);

                    // var acc2 = unit.Accounts.getAccountByPersonId("00006").GetAwaiter().GetResult();
                    // if (acc2 == null) Console.WriteLine("NULL acc"); else Console.WriteLine(acc2.Username);

                    greenairContext.SaveChanges();
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