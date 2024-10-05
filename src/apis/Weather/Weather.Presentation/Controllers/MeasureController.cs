using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Weather.Application.Measures.Queries.GetMeasures;

namespace Weather.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class MeasureController : ControllerBase
{
    protected readonly IMediator _mediator;
    public MeasureController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Authorize(Policy = "admin")]
    public async Task<IActionResult> Get([FromQuery] string InitialDate, [FromQuery] string FinalDate)
    {
        GetMeasuresCommand request = new GetMeasuresCommand {
            InitialDate = DateTime.Parse(InitialDate),
            FinalDate = DateTime.Parse(FinalDate)
        };
        var response = await _mediator.Send(request);
        return Ok(response);
    }
}
