using MediatR;
using Microsoft.AspNetCore.Mvc;
using WL.PublicApi.Filters;

namespace WL.PublicApi.Controllers;

[ApiController]
[ApiExceptionFilter]
[Route("api/[controller]")]
public abstract class ApiControllerBase : ControllerBase
{
    private ISender? _mediator;

    protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
}