namespace ProcessManager.API.Process.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Application.Process.Models.Queries;
    using Application.Process.Models.Queries.Responses;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("[controller]")]
    public class ProcessController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProcessController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        /// <summary>
        /// Retrieves a specific process
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<GetProcessQueryResponse>> Get([FromQuery] GetProcessQuery query)
        {
            try
            {
                return await this.mediator.Send(query);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }
    }
}
