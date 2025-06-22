using AsyncMediator.Extensions.DependencyInjection.Demo.UseCases.PresentWeatherForecast;
using Microsoft.AspNetCore.Mvc;

namespace AsyncMediator.Extensions.DependencyInjection.Demo.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IMediator mediator;

    public WeatherForecastController(IMediator mediator)
    {
        this.mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IEnumerable<WeatherForecast>> Get()
    {
        PresentWeatherForecastCriteria criteria = new();
        PresentWeatherForecastResponse response = await mediator.Query<PresentWeatherForecastCriteria, PresentWeatherForecastResponse>(criteria);

        return response.WeatherForecasts;
    }
}
