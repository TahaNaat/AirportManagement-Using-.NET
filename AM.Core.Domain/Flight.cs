﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Core.Domain
{
    public class Flight
    {
        public string Destination { get; set; }
        public string Departure { get; set; }
        public DateTime FlightDate { get; set; }
        public int FlightId { get; set; }
        public DateTime EffectiveArrival { get; set; }
        public int EstimateDuration { get; set; }
        //public IList<Passenger> Passengers { get; set; }
        public virtual IList<Reservation> Reservations { get; set; }
        [ForeignKey("MyPlane")]
        public int? PlaneId { get; set; }
        //ou bien [ForeignKey("PlaneId")]
        public virtual Plane MyPlane { get; set; }
        public string Pilot { get; set; }

        public override string ToString()
        {
            return "Destination:" + Destination
                + " Depature:" + Departure
                + " FlightDate:" + FlightDate
                + " EffectiveArrival:" + EffectiveArrival
                + " EstimateDuration:" + EstimateDuration
                + " MyPlane:{" + MyPlane + "}"
                + " FlightId:" + FlightId
                + " Pilot:" + Pilot;
        }

        //public String Comment { get; set; }
    }
}
