using System.Threading;
using System.Threading.Tasks;

namespace Application.Abstractions.Events
{
    public interface IDomainEventHandler<IDomainEvent>
    {
        Task Handle(IDomainEvent notification, CancellationToken cancellationToken);
    }
}
