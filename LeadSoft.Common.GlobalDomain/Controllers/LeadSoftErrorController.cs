using LeadSoft.Common.GlobalDomain.DTOs;
using LeadSoft.Common.Library.Constants;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Net;

namespace LeadSoft.Common.GlobalDomain.Controllers
{
    /// <summary>
    /// Default and abstract LeadSoft Error controller. For common/private methods
    /// Swagger ignores it by setting below
    /// </summary>
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public abstract class LeadSoftErrorController : ControllerBase
    {
        /// <summary>
        /// Error method
        /// </summary>
        /// <returns>Problem pattern: Stack trace with a title</returns>
        [Route("Error")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [Produces(Constant.ApplicationProblemJson)]
        [AllowAnonymous]
        public IActionResult Error()
        {
            IExceptionHandlerFeature context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            Exception exception = context.Error; // Your exception

            DTOErrorResponse dtoResponse = new(HttpStatusCode.InternalServerError, "Internal Server Error.", $"Original message: '{exception.Message}'");
            dtoResponse.HandleException(exception);

            Response.StatusCode = (int)dtoResponse.Status;
            Response.Headers.Add("ErrorCount", dtoResponse.ErrorCount.ToString());

            return StatusCode(Response.StatusCode, dtoResponse);
        }
    }
}
