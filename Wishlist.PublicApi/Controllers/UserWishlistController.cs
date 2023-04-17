using MediatR;
using Microsoft.AspNetCore.Mvc;
using Wishlist.PublicApi.Features.Wishlists.CreateWishlist;
using Wishlist.PublicApi.Features.Wishlists.GetWishlistById;

namespace Wishlist.PublicApi.Controllers;

public class UserWishlistController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public UserWishlistController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateWishCommand command)
    {
        return await _mediator.Send(command);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateWishCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await _mediator.Send(command);
        
        return NoContent();
    }
    
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var result = await _mediator.Send(new GetWishlistQuery { Id = id });
        return new JsonResult(result);
    }
    
    
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesDefaultResponseType]
    public async Task<IActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteTodoItemCommand(id));

        return NoContent();
    }
}