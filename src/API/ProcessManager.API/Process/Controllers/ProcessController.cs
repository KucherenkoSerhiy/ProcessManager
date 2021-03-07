namespace ProcessManager.API.Process.Controllers
{
    using System;
    using System.Threading.Tasks;
    using Application.Process.Models.Commands;
    using Application.Process.Models.Queries;
    using Application.Process.Models.Queries.Responses;
    using CQRS;
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
        /// Retrieves a process by id
        /// </summary>
        /// <param name="id">id of a process</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<GetProcessQueryResponse>> Get(string id)
        {
            try
            {
                var query = new GetProcessQuery {Id = id};
                return await this.mediator.Send(query);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Retrieves multiple processes
        /// </summary>
        /// <param name="query">Used to specify filters</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<GetProcessesQueryResponse>> Get([FromQuery] GetProcessesQuery query)
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

        /// <summary>
        /// Creates a new process
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("create")]
        public async Task<ActionResult<CommandResponse>> Create([FromBody] CreateProcessCommand command)
        {
            try
            {
                return await this.mediator.Send(command);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

        [HttpPatch("update")]
        public async Task<ActionResult<CommandResponse>> Update([FromBody] UpdateProcessCommand command)
        {
            try
            {
                return await this.mediator.Send(command);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }

        [HttpDelete("delete")]
        public async Task<ActionResult<CommandResponse>> Delete([FromBody] DeleteProcessCommand command)
        {
            try
            {
                return await this.mediator.Send(command);
            }
            catch (Exception ex)
            {
                return this.BadRequest(ex.Message);
            }
        }
    }
}
