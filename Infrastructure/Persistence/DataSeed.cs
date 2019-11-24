using ApplicationCore.Entities;
using System.Linq;
using System;
using ApplicationCore;
namespace Infrastructure.Persistence
{
    public class DataSeed
    {
        public static void Initialize(GreenairContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Jobs.Any())
            {
                context.Jobs.AddRange(
                    new Job("000", "Administrator"),
                    new Job("001", "Customer Manager"),
                    new Job("002", "Employee Manager"),
                    new Job("003", "Flight Manager")
                );
                context.SaveChanges();
            }
            if (!context.Makers.Any())
            {
                var address = new Address("123", "ABC", "Hogwart", "Gotham", "Newyork", "USA");
                var address2 = new Address("123", "ABC", "Hogwart", "Gotham", "Newyork", "USA");
                context.Makers.AddRange(
                    new Maker("000", "BOEING", new Address("123", "ABC", "Hahaha", "Gotham", "Newyork", "USA")),
                    new Maker("001", "BAMBOO", address2),
                    new Maker("002", "Mc.King", new Address("457", "AN Duong Vuong", "10", "5", "", "Viet Nam"))
                );
                context.SaveChanges();
            }
            if (!context.Planes.Any())
            {
                context.Planes.AddRange(
                    new Plane("000", 40, "000"),
                    new Plane("001", 50, "000"),
                    new Plane("002", 30, "001"),
                    new Plane("003", 40, "001"),
                    new Plane("004", 35, "002")
                );
                context.SaveChanges();
            }
            if (!context.Airports.Any())
            {

                context.SaveChanges();
            }

            if (!context.Employers.Any())
            {
                var addr = new Address("123", "ABC", "hahahaha", "Gotham", "Newyork", "USA");
                context.Employers.AddRange(
                new Employer
                    (
                        "001",
                        "Trieu Ng Quoc",
                        "Viet",
                        new DateTime(1999, 12, 7),
                        "0904897191",
                        addr,
                        STATUS.AVAILABLE,
                        15000,
                        "001"
                    ),
                new Employer
                    (
                        "002",
                        "Vu Tuong",
                        "Giang",
                        new DateTime(1999, 12, 8),
                        "0904891597",
                        new Address("123", "gfd", "fsd", "sdf", "fs", "fsd"),
                        STATUS.AVAILABLE,
                        18000,
                        "002"
                    )
                );
                context.SaveChanges();
            }

            if (!context.Customers.Any())
            {
                context.Customers.AddRange(
                new Customer
                    (
                        "003",
                        "Do Trung",
                        "Hieu",
                        new DateTime(1999, 12, 10),
                        "0903774110",
                        new Address("456", "gfd", "fsd", "sdf", "fs", "fsd"),
                        STATUS.AVAILABLE,
                        "abc@gmail.com"
                    ),
                    new Customer
                    (
                        "004",
                        "Phung Quoc",
                        "Hai",
                        new DateTime(1999, 12, 5),
                        "0903774147",
                        new Address("789", "gfd", "fsd", "sdf", "fs", "fsd"),
                        STATUS.AVAILABLE,
                        "abrrc@gmail.com"
                    )
                );
                context.SaveChanges();
            }



        }

    }
}