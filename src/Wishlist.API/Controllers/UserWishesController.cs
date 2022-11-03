using System;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Wishlist.Core.Entities.WishlistAggregate;

namespace Wishlist.API.Controllers;

[ApiController]
[Route("user/wishes")]
public class UserWishesController : ControllerBase
{
    private readonly IMediator _mediator;

    public UserWishesController(IMediator mediator) {
        _mediator = mediator;
    }
    
    [HttpGet]
    public IActionResult GetRandomWish() {
        var wlItem = new WishlistItem("new wl item", "desce", 5, 1);
        // _mediator.Send(wlItem);
        return Ok(Random.Shared.Next(1, 50));
    }
}