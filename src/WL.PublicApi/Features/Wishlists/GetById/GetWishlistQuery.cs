// using System.ComponentModel.DataAnnotations;
// using MediatR;
// using WL.Infrastructure.Persistence.Repositories;
// using Wishlist = Wishlist.Domain.Entities.Wishlist;
//
// namespace Wishlist.PublicApi.Features.Wishlists.GetById;
//
// public class GetWishlistQuery : IRequest<Domain.Entities.Wishlist>
// {
//     [Required]
//     public Guid Id { get; set; }
// }
//
// public class GetWishHandler : IRequestHandler<GetWishlistQuery, Domain.Entities.Wishlist>
// {
//     private readonly WishlistRepository _wishlistRepository;
//
//     public GetWishHandler(WishlistRepository wishlistRepository)
//     {
//         _wishlistRepository = wishlistRepository;
//     }
//
//
//     public async Task<Wishlist> Handle(GetWishlistQuery request, CancellationToken cancellationToken)
//     {
//         // var entity = await _wishlistRepository.GetAsync<Domain.Entities.Wishlist>(x => x.Uid == request.Id);
//         return new Wishlist();
//     }
// }