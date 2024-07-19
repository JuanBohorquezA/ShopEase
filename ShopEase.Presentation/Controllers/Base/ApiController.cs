using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ShopEase.WebApi.Controllers.Base;

[ApiController]
public abstract class ApiController : ControllerBase
{
    protected readonly ISender Sender;

    protected ApiController(ISender sender)
    {
        Sender = sender;
    }
}
