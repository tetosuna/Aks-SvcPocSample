using System;
namespace CommonLibrary.Models
{
    public class RootObject
    {
        public DateTime DateTime { get; set; }
        public string CountryCode { get; set; }
        public Accident[] Accidents { get; set; }
    }
}
