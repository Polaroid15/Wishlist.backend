using System.ComponentModel.DataAnnotations;
using MediatR;
using WL.Application.Common.Interfaces;

namespace WL.PublicApi.Features.Wishlists.Create;

public class CreateWishlistCommand : IRequest<Guid>
{
    [Required]
    public string Title { get; set; }
    
    [Required]
    public string Description { get; set; }

    [Range(1, int.MaxValue)]
    public long UserId { get; set; }
}

public class CreateWishlistHandler : IRequestHandler<CreateWishlistCommand, Guid>
{
    private readonly IWishlistItemRepository _repository;

    public CreateWishlistHandler(IWishlistItemRepository repository)
    {
        _repository = repository;
    }

    public async Task<Guid> Handle(CreateWishlistCommand request, CancellationToken cancellationToken)
    {
        // var wishlist = new Wishlist();
        return Guid.NewGuid();
    }
}