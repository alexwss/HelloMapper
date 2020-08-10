using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HelloMapper.Domain.Core;
using HelloMapper.CrossCutting;
using AutoMapper;

namespace HelloMapper.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMapper _mapper;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMapper mapper)
        {
            _logger = logger;
            _mapper = mapper;
        }

        [HttpGet]
        public WeatherForecast Get()
        {
            var rng = new Random();
            var source = Enumerable.Range(1, 5).Select(index => new WeatherFromAPIService
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureFahrenheit = rng.Next(-20, 55)
            })
            .FirstOrDefault();

            _logger.LogInformation($"Casting WeatherFromAPIService to WeatherForecast");

            return _mapper.Map<WeatherFromAPIService, WeatherForecast>(source);
        }

    }
}