using System.Collections.Generic;
using System.Threading.Tasks;

namespace Wishlist.SharedKernel.Interfaces;

public interface IDomainEventDispatcher
{
    Task DispatchAndClearEvents(IEnumerable<BaseEntity> entitiesWithEvents);
}