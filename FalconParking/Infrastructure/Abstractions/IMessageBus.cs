using FalconParking.Infrastructure.Abstractions.Queries;
using FalconParking.Infrastructure.Abstractions.Commands;
using System.Threading;
using System.Threading.Tasks;

namespace FalconParking.Infrastructure.Abstractions
{
    public interface IMessageBus
    {
        Task<TResponse> SendAsync<TResponse>(ICommand<TResponse> request, CancellationToken cancellationToken = default);
        Task<TResponse> SendAsync<TResponse>(IQuery<TResponse> request, CancellationToken cancellationToken = default);
    }
}
