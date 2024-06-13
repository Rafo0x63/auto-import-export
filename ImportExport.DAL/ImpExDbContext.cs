using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ImportExport.Model;
using Microsoft.EntityFrameworkCore;


namespace ImportExport.DAL
{
    public class ImpExDbContext : IdentityDbContext<AppUser>
    {
        public ImpExDbContext (DbContextOptions<ImpExDbContext> options) : base(options) 
        { 
        
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Dealer> Dealers { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Location>().HasData(
                new Location { ID = 1, Country = "Germany", Address = "Alexanderplatz 1", City = "Berlin" },
                new Location { ID = 2, Country = "Sweden", Address = "Gamla stan", City = "Stockholm" },
                new Location { ID = 3, Country = "Netherlands", Address = "Dam Square", City = "Amsterdam" },
                new Location { ID = 4, Country = "Belgium", Address = "Grand Place", City = "Brussels" }
                );

            modelBuilder.Entity<Dealer>().HasData(
                new Dealer { ID = 1, Name = "RPM Cars", Email = "rpm@info.com", LocationID = 1, PhoneNumber = "8395994874" },
                new Dealer { ID = 2, Name = "AutoHaus", Email = "autohaus@example.com", LocationID = 2, PhoneNumber = "1234567890" },
                new Dealer { ID = 3, Name = "CarCenter", Email = "carcenter@example.com", LocationID = 3, PhoneNumber = "0987654321" },
                new Dealer { ID = 4, Name = "CarWorld", Email = "carworld@example.com", LocationID = 4, PhoneNumber = "5555555555" }
                );

            modelBuilder.Entity<Car>().HasData(
                new Car { ID = 1, Make = "Nissan", Model = "S15", Fuel = "Gasoline", FuelConsumption = 8.4f, DealerID = 1, Mileage = 98000, Power = 250, PreviousOwners = 2, Price = 24000, Transmission = "Manual", Year = "2002" },
                new Car { ID = 2, Make = "BMW", Model = "M3", Fuel = "Gasoline", FuelConsumption = 10.2f, DealerID = 2, Mileage = 75000, Power = 425, PreviousOwners = 1, Price = 45000, Transmission = "Manual", Year = "2016" },
                new Car { ID = 3, Make = "Audi", Model = "A4", Fuel = "Diesel", FuelConsumption = 6.8f, DealerID = 3, Mileage = 55000, Power = 190, PreviousOwners = 1, Price = 32000, Transmission = "Automatic", Year = "2018" },
                new Car { ID = 4, Make = "Mercedes-Benz", Model = "E-Class", Fuel = "Gasoline", FuelConsumption = 9.5f, DealerID = 4, Mileage = 80000, Power = 320, PreviousOwners = 2, Price = 38000, Transmission = "Automatic", Year = "2015" },
                new Car { ID = 5, Make = "Volkswagen", Model = "Passat", Fuel = "Diesel", FuelConsumption = 5.7f, DealerID = 1, Mileage = 65000, Power = 150, PreviousOwners = 1, Price = 25000, Transmission = "Automatic", Year = "2017" },
                new Car { ID = 6, Make = "Ford", Model = "Focus", Fuel = "Gasoline", FuelConsumption = 6.2f, DealerID = 2, Mileage = 70000, Power = 125, PreviousOwners = 1, Price = 18000, Transmission = "Manual", Year = "2019" },
                new Car { ID = 7, Make = "Toyota", Model = "Corolla", Fuel = "Hybrid", FuelConsumption = 4.5f, DealerID = 3, Mileage = 40000, Power = 120, PreviousOwners = 1, Price = 22000, Transmission = "Automatic", Year = "2020" },
                new Car { ID = 8, Make = "Honda", Model = "Civic", Fuel = "Gasoline", FuelConsumption = 6.5f, DealerID = 4, Mileage = 50000, Power = 150, PreviousOwners = 1, Price = 20000, Transmission = "Manual", Year = "2018" },
                new Car { ID = 9, Make = "Hyundai", Model = "i30", Fuel = "Diesel", FuelConsumption = 5.8f, DealerID = 1, Mileage = 60000, Power = 110, PreviousOwners = 1, Price = 19000, Transmission = "Manual", Year = "2017" },
                new Car { ID = 10, Make = "Renault", Model = "Clio", Fuel = "Gasoline", FuelConsumption = 5.2f, DealerID = 1, Mileage = 45000, Power = 100, PreviousOwners = 1, Price = 15000, Transmission = "Manual", Year = "2019" },
                new Car
                    {
                        ID = 11,
                        Make = "Renault",
                        Model = "Megane",
                        Fuel = "Gasoline",
                        FuelConsumption = 6.2f,
                        DealerID = 3,
                        Mileage = 85000,
                        Power = 150,
                        PreviousOwners = 2,
                        Price = 22000,
                        Transmission = "Manual",
                        Year = "2019"
                    }
                );


        }
    }
}
