using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Wishlist.PublicApi.Features.Wishlists.CreateWishlist;

public class CreateWishCommand : IRequest<Guid>
{
    [Required]
    public string Title { get; set; }
    
    [Required]
    public string Description { get; set; }

    [Range(1, int.MaxValue)]
    public long UserId { get; set; }
}

public class CreateWishHandler : IRequestHandler<CreateWishCommand, Guid>
{
    private readonly INeo4JNodeCrudService _neo4JNodeCrudService;

    public CreateWishHandler(INeo4JNodeCrudService neo4JNodeCrudService)
    {
        _neo4JNodeCrudService = neo4JNodeCrudService;
    }

    public async Task<Guid> Handle(CreateWishCommand request, CancellationToken cancellationToken)
    {
        var wishlist = new Wishlist.Domain.Entities.Wishlist(request.Title, request.Description, request.UserId);
        var result = await _neo4JNodeCrudService.CreateAsync(wishlist);
        return result.Uid;
    }
}