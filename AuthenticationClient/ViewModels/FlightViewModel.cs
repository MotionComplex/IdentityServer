using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuthenticationClient.ViewModels
{
    public class FlightViewModel
    {
        public Guid UID { get; set; }

        public string FlightNr { get; set; }

        public string Departure { get; set; }

        public string Destination { get; set; }

        public DateTime DepartureDate { get; set; }

        public DateTime ArrivalDate { get; set; }
    }
}
