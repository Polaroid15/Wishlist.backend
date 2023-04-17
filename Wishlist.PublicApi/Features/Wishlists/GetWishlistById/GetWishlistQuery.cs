using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Wishlist.PublicApi.Features.Wishlists.GetWishlistById;

public class GetWishlistQuery : IRequest<Domain.Entities.Wishlist>
{
    [Required]
    public Guid Id { get; set; }
}

public class GetWishHandler : IRequestHandler<GetWishlistQuery, Domain.Entities.Wishlist>
{
    private readonly INeo4JNodeCrudService _neo4JNodeCrudService;

    public GetWishHandler(INeo4JNodeCrudService neo4JNodeCrudService)
    {
        _neo4JNodeCrudService = neo4JNodeCrudService;
    }

    public async Task<Domain.Entities.Wishlist> Handle(GetWishlistQuery request, CancellationToken cancellationToken)
    {
        var entity = await _neo4JNodeCrudService.GetAsync<Domain.Entities.Wishlist>(x => x.Uid == request.Id);
        return entity;
    }
}