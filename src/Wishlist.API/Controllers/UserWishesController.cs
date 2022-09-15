using Microsoft.AspNetCore.Mvc;

namespace Wishlist.API.Controllers; 

[ApiController]
[Route("user/wishes")]
public class UserWishesController : ControllerBase {

    [HttpGet]
    public IActionResult GetRandomWish() {
        return Ok(Random.Shared.Next(1, 50));
    }
}