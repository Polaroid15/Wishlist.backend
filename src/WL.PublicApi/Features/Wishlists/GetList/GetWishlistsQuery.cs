// using MediatR;
// using WL.Application.Common.Models;
//
// namespace WL.PublicApi.Features.Wishlists.GetList;
//
// public class GetWishlistsQuery : IRequest<PaginatedList<Wishlist.Domain.Entities.Wishlist>>
// {
//     
// }
//
// public class GetWishlistsHandler : IRequestHandler<GetWishlistsQuery, PaginatedList<Wishlist.Domain.Entities.Wishlist>>
// {
//     public async Task<PaginatedList<Wishlist.Domain.Entities.Wishlist>> Handle(GetWishlistsQuery request, CancellationToken cancellationToken)
//     {
//         throw new NotImplementedException();
//     }
// }