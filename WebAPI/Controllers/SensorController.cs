﻿using ConsoleApp.Models;
using Microsoft.AspNetCore.Mvc;
using SensorAPI.Interfaces;

namespace SensorAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SensorController : ControllerBase
    {
        public readonly IDataGeneratorService _dataGeneratorService;

        public SensorController(IDataGeneratorService dataGeneratorService)
        {
            _dataGeneratorService = dataGeneratorService;
        }

        [HttpGet("latest")]
        public ActionResult<SensorReading> GetLatestReading()
        {
            var reading = _dataGeneratorService.GetLatestReading();
            if (reading == null) return NotFound();
            return Ok(reading);
        }

        //// GET api/<SensorController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<SensorController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/<SensorController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<SensorController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
