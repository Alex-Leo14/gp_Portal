using MediatR;
using gp_Portal.Application.Linea.Commands.CreateLineaBE;
using gp_Portal.Application.Linea.Commands.DeleteLineaBE;
using gp_Portal.Application.Linea.Commands.UpdateLineaBE;
using gp_Portal.Application.Linea.Queries.GetLineaBE;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using gp_Portal.Application.ServicioLinea.Queries.GetServiciosLineaWithPagination;

namespace gp_Portal.WebUI.Controllers;

[AllowAnonymous]
public class LineaBEController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<LineaVm>> Get()
    {
        return await Mediator.Send(new GetLineaBEQuery());
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateLineaBECommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id,UpdateLineaBECommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteLineaBECommand(id));

        return NoContent();
    }
}
