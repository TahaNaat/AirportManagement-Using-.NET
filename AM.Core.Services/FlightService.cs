﻿using AM.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Services
{
    public class FlightService : IFlightService
    {
        public IList<Flight> Flights { get; set; }

        public IList<DateTime> GetFlightDates(string destination)
        {
           IList<DateTime> dates = new List<DateTime>();
            foreach (var flight in Flights)
            {
                if (flight.Destination == destination)
                {
                    dates.Add(flight.FlightDate);
                }
            }
            return dates;
        }
        public IList<DateTime> GetFlightDates_lINQ(string destination)
        {
            //fonction avancee de linq
            /* return Flights.Where(f => f.Destination == destination)
                           .Select(f => f.FlightDate)
                           .ToList();*/
            //linq integree  
            return (from f in Flights
                    where f.Destination == destination
                    select f.FlightDate).ToList();


        }
        public IList<Flight> GetFlights(string filterType, string filterValue)
        {
            IList<Flight> flights = new List<Flight>();
            switch (filterType)
            {
                case "Destination":
                    foreach (var flight in Flights)
                    {
                        if (flight.Destination == filterValue)
                        {
                            flights.Add(flight);
                        }
                    }
                    break;
                case "Departure":
                    foreach (var flight in Flights)
                    {
                        if (flight.Departure == filterValue)
                        {
                            flights.Add(flight);
                        }
                    }
                    break;
                case "FlightDate":
                    foreach (var flight in Flights)
                    {
                        if (flight.FlightDate.ToString() == filterValue)
                        {
                            flights.Add(flight);
                        }
                    }
                    break;
                case "FlightId":
                    foreach (var flight in Flights)
                    {
                        if (flight.FlightId.ToString() == filterValue)
                        {
                            flights.Add(flight);
                        }
                    }
                    break;
                case "EffectiveArrival":
                    foreach (var flight in Flights)
                    {
                        if (flight.EffectiveArrival.ToString() ==filterValue)
                        {
                            flights.Add(flight);
                        }
                    }
                    break;
                case "EstimateDuration":
                    foreach (var flight in Flights)
                    {
                        if (flight.EstimateDuration.ToString() == filterValue)
                        {
                            flights.Add(flight);
                        }
                    }
                    break;
               
            }
            return flights;
            

        }

        public void ShowFlightDetails(Plane plane)
        {
            var result = from f in Flights
                         where f.MyPlane.PlaneId == plane.PlaneId
                         select new { date = f.FlightDate, destination = f.Destination };
            foreach (var r in result)
            {
                Console.WriteLine("FlightDate:" + r.date + ";Destination:" + r.destination);
            }
        }
     
        public int GetWeeklyFlightNumber(DateTime date)
        {
            return (from f in Flights
                    where f.FlightDate >= date
                    && f.FlightDate < date.AddDays(7)
                    select f).Count(); //type anonyme

        }
        public double GetDurationAverage(string destination)
        {
            return (from f in Flights
                    where f.Destination.ToString() == destination
                    select f.EstimateDuration).Average();
        }
        public IList<Flight> SortFlights()
        {
            return (from f in Flights
                    orderby f.EstimateDuration descending
                    select f).ToList();
        }
        /*public IList<Passenger> GetThreeOlderTravellers(Flight flight)
        {
            return (from p in flight.Passengers
                    orderby p.Age descending //orderby p.BirthDate
                    select p).Take(3).ToList();
        }*/
        public void ShowGroupedFlights()
        {
          
            IEnumerable<IGrouping<string, Flight>> result = from f in Flights
                                                            group f by f.Destination.ToString();
            foreach (var grp in result)
            {
                Console.WriteLine(grp.Key);
                foreach (var f in grp)
                {
                    Console.WriteLine(f);

                }
            }
        }
    }
}
