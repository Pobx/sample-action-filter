using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace sample_action_filter {
  public class WeatherForecast {
    public DateTime Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF => 32 + (int) (TemperatureC / 0.5556);

    public string Summary { get; set; }
  }

  public class TestPop {
    [Required (ErrorMessage = "สิเอา Id เด้อ แก๋วววว")]
    public int? Id { get; set; }

    [Required (ErrorMessage = "อยากได๊ Name เด้อ ฮ่วยยยย")]
    public string Name { get; set; }
  }

  public class MyResponse<T> {
    public DateTime CurrentDateTime { get; } = DateTime.UtcNow;
    public List<string> ErrorsMessage { get; set; } = new List<string> ();
    public T Entities { get; set; }
  }
}