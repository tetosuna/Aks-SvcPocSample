using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CommonLibrary.Models
{
    public class Vehicle
    {
        //[Key]
        int Id { get; set; }
        string Vin { get; set; }
        string Dealer { get; set; }
        string OwnerId { get; set; }

    }
}
