using System;
using System.ComponentModel.DataAnnotations;

namespace CommonLibrary.Models
{
    public class Accident
    {
        public long Id { get; set; }
        public DateTime OccurenceDate { get; set; }
        public string TransactionId { get; set; }
        public string VehicleId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Message { get; set; }
    }
}
