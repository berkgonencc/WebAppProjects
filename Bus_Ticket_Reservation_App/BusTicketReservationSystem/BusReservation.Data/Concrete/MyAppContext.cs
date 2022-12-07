using BusReservation.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusReservation.Data.Concrete
{
    public class MyAppContext : DbContext
    {
        public MyAppContext(DbContextOptions<MyAppContext> options) : base(options)
        {

        }
        public DbSet<Bus> Buses { get; set; }
        public DbSet<Trip> Trips { get; set; }
        public DbSet<Passenger> Passengers { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Ticket> Tickets { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bus>().HasData(
                new Bus() { BusId = 1, BusName = "MAN", TotalSeats = 20 },
                new Bus() { BusId = 2, BusName = "Volvo", TotalSeats = 30 },
                new Bus() { BusId = 3, BusName = "Mercedes", TotalSeats = 40 }
                );

            modelBuilder.Entity<City>().HasData(
                new City() { CityId = 1, CityName = "Istanbul" },
                new City() { CityId = 2, CityName = "Belgrade" },
                new City() { CityId = 3, CityName = "Berlin" },
                new City() { CityId = 4, CityName = "Amsterdam" },
                new City() { CityId = 5, CityName = "Paris" },
                new City() { CityId = 6, CityName = "Madrid" },
                new City() { CityId = 7, CityName = "Vienna" }
                );

            modelBuilder.Entity<Passenger>().HasData(
                new Passenger() { PassengerId = 1, Fname = "Berk", Lname = "Gonenc", PhoneNumber = "5309999999", Email = "berkgonencc@gmail.com" },
                new Passenger() { PassengerId = 2, Fname = "Ipek", Lname = "Gonenc", PhoneNumber = "5319999999", Email = "ipksml@gmail.com" },
                new Passenger() { PassengerId = 3, Fname = "Kunta", Lname = "Gonenc", PhoneNumber = "5319999999", Email = "ipksml@gmail.com" },
                new Passenger() { PassengerId = 4, Fname = "Hakan", Lname = "Ataman", PhoneNumber = "5329999999", Email = "hkntmn@gmail.com" },
                new Passenger() { PassengerId = 5, Fname = "Canberk", Lname = "Bulut", PhoneNumber = "5339999999", Email = "cnbk@gmail.com" }
                );

            modelBuilder.Entity<Ticket>().HasData(
                new Ticket() { TicketId = 1, PassengerId = 1, TripId = 1, SeatNo = 3 },
                new Ticket() { TicketId = 2, PassengerId = 2, TripId = 1, SeatNo = 4 },
                new Ticket() { TicketId = 3, PassengerId = 3, TripId = 2, SeatNo = 5 },
                new Ticket() { TicketId = 4, PassengerId = 4, TripId = 3, SeatNo = 6 },
                new Ticket() { TicketId = 5, PassengerId = 5, TripId = 4, SeatNo = 7 }
                );
            modelBuilder.Entity<Trip>().HasData(
                new Trip() { TripId = 1, DepartureTime = "12:00", ReservationDate = "2023-08-20", TicketPrice = 300, DepartureCityId = 1, ArrivalCityId = 2, EstimatedTime = "11:00", BusId = 1 },
                new Trip() { TripId = 2, DepartureTime = "14:00", ReservationDate = "2023-08-20", TicketPrice = 300, DepartureCityId = 1, ArrivalCityId = 2, EstimatedTime = "11:00", BusId = 2 },
                new Trip() { TripId = 3, DepartureTime = "16:00", ReservationDate = "2023-08-20", TicketPrice = 400, DepartureCityId = 1, ArrivalCityId = 2, EstimatedTime = "11:00", BusId = 3 },
                new Trip() { TripId = 4, DepartureTime = "18:00", ReservationDate = "2023-08-20", TicketPrice = 600, DepartureCityId = 1, ArrivalCityId = 2, EstimatedTime = "11:00", BusId = 2 },
                new Trip() { TripId = 5, DepartureTime = "20:00", ReservationDate = "2023-08-20", TicketPrice = 600, DepartureCityId = 1, ArrivalCityId = 2, EstimatedTime = "11:00", BusId = 1 }
                );
        }
    }
}
