using MediatR;
using Microsoft.AspNetCore.Mvc;
using WL.PublicApi.Features.Wishlists.Create;

namespace WL.PublicApi.Controllers;

public class UserWishlistController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public UserWishlistController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateWishlistCommand command)
    {
        return await _mediator.Send(command);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Update(int id/*, [FromBody] UpdateWishlistCommand command*/)
    {
        // if (id != command.Id)
        // {
            // return BadRequest();
        // }

        // await _mediator.Send(command);

        return NoContent();
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        // var result = await _mediator.Send(new GetWishlistQuery { Id = id });
        return new JsonResult(null);
    }
    
    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] int page, [FromQuery] int pageSize)
    {
        // var result = await _mediator.Send(new GetListWishlistsQuery { Page = page, PageSize = pageSize });
        return new JsonResult(null);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> MarkAsDelete(int id)
    {
        // await Mediator.Send(new MarkAsDeleteWishlistCommand(id));

        return NoContent();
    }
}