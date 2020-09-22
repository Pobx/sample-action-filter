using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace sample_action_filter.Controllers {
  [ApiController]
  [Route ("[controller]")]
  public class WeatherForecastController : ControllerBase {
    private static readonly string[] Summaries = new [] {
      "Freezing",
      "Bracing",
      "Chilly",
      "Cool",
      "Mild",
      "Warm",
      "Balmy",
      "Hot",
      "Sweltering",
      "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController (ILogger<WeatherForecastController> logger) {
      _logger = logger;
    }

    [HttpGet]
    public ActionResult<MyResponse<IEnumerable<WeatherForecast>>> Get () {
      var rng = new Random ();

      var result = Enumerable.Range (1, 5).Select (index => new WeatherForecast {
        Date = DateTime.Now.AddDays (index),
          TemperatureC = rng.Next (-20, 55),
          Summary = Summaries[rng.Next (Summaries.Length)]
      }).ToList ();

      return Ok (result);

    }

    [HttpPost]
    public IActionResult insert ([FromBody] TestPop criteria) {
      return Created ("", criteria);
    }

    [HttpPut]

    public IActionResult update ([FromBody] TestPop criteria) {
      return Ok (criteria);
    }

    [HttpDelete]
    public IActionResult delete () {
      return NoContent ();
    }

    [HttpPut ("test-exception")]
    public IActionResult test_exception () {
      throw new System.Exception ("Hello from exepction !!!");
    }
  }

}