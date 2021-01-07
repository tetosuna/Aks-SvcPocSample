﻿using System;
using System.Collections.Generic;
using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Mvc;
using CommonLibrary.Models;
using Newtonsoft.Json;
using Microsoft.Extensions.Configuration;
using GwWebApi01.Kafka;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GwWebApi01.Controllers
{
    [Route("api/[controller]")]
    public class AccidentListController : ControllerBase
    {
        private IConfiguration _configuration;
        private TelemetryClient _telemetryClient;
        private ILogger _logger;

        private string brokerList = "";
        private string topic = "";

        public AccidentListController(IConfiguration configuraion, TelemetryClient telemetryClient, ILogger<AccidentListController> logger)
        {
            _telemetryClient = telemetryClient;
            _configuration = configuraion;
            _logger = logger;

            brokerList = _configuration.GetValue<string>("BROKER_LIST");
            topic = _configuration.GetValue<string>("TOPIC");
        }

        // POST api/AccidentList
        [HttpPost]
        public StatusCodeResult Post([FromBody]RootObject rootObject)
        {
            //_telemetryClient.TrackTrace(rootObject.DateTime + ":" + rootObject.CountryCode);
            List<string> tList = new List<string>();

            foreach(Accident i in rootObject.Accidents)
            {
                var guid = Guid.NewGuid().ToString();
                i.TransactionId = guid;
                tList.Add(guid);

            }
            try
            {
                using (var kafkaClient = new MyKafkaProducer(brokerList, topic))
                {
                    var jstr = JsonConvert.SerializeObject(rootObject);
                    //_telemetryClient.TrackTrace(jstr);
                    _logger.LogInformation(jstr);
                    kafkaClient.produce(jstr);
                    //_logger.LogInformation($"Delivered at '{deliveryLog.topicTimeStamp}' to topic '{deliveryLog.topic}' offset '{deliveryLog.offset}'");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.InnerException.Message);
                return StatusCode(500);
            }
            return StatusCode(200);
        }
        // Get api/AccidentList for probe request send by application gateway
        [HttpGet]
        public string Get()
        {
            try
            {
                _logger.LogInformation("requet receive");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.InnerException.Message);
            }
            return "api/AccidentList";
        }
    }
}
