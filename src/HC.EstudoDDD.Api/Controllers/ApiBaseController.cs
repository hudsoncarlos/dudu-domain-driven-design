using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Flunt.Notifications;
using HC.EstudoDDD.Application.Models;

namespace HC.EstudoDDD.Api.Controllers
{
    public class ApiBaseController : ControllerBase
    {
        //protected BadRequestObjectResult BadRequestObjectResult(IReadOnlyCollection<Notification> notifications)
        //    => new(new ErrorModel(notifications));

        //protected ObjectResult InternalServerError(Exception ex)
        //    => new ObjectResult(ex.Message) { StatusCode = StatusCode.Status500InternalServerError };
    }
}
