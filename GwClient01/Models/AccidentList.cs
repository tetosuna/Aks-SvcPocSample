using System;
using System.Collections.Generic;

namespace GwClient01.Models
{
    // kafkaに書き込むデータのモデル
    public class AccidentList
    {
        public string dateTime { get; set; }
        public string countryCode { get; set; }
        public Accident[] accidentList { get; set; }
    }
    public class Accident
    {
        public string occurenceDate { get; set; }
        public string transactionId { get; set; }
        public string vehicleId { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string message { get; set; }
    }

    public class RootObject
    {
        public string dateTime { get; set; }
        public string CountryCode { get; set; }
        public Accident_[] Accidents { get; set; }
    }
    public class Accident_
    {
        public string OccurenceDate { get; set; }
        public string TransactionId { get; set; }
        public string VehicleId { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Message { get; set; }
    }


    /*
    public class Rootobject
    {
        public string dateTime { get; set; }
        public string countryCode { get; set; }
        public Acccident[] acccidents { get; set; }
    }

    public class Acccident
    {
        public string occurenceDate { get; set; }
        public string transactionId { get; set; }
        public string vehicleId { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string message { get; set; }
    }
    */
    // クライアントから受診するデータのモデル
    public class RescieveAccidentList
    {
        DateTime dateTime { get; set; }
        String nation { get; set; }
        List<RescieveAccident> accidentList { get; set; }
    }
    public class RescieveAccident
    {
        DateTime occurenceDate { get; set; }
        int vehicleId { get; set; }
        string address { get; set; }
        string city { get; set; }
        string message { get; set; }
    }
}
