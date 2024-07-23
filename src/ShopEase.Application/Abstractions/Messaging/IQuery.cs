using MediatR;
using ShopEase.Application.Common;

namespace ShopEase.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}
