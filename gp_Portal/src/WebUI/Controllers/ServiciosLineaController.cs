﻿
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using gp_Portal.Application.Common.Models;
using gp_Portal.Application.ServicioLinea.Queries.GetServiciosLineaWithPagination;
using gp_Portal.Application.ServicioLinea.Commands.CreateServiciosLinea;
using gp_Portal.Application.ServicioLinea.Commands.UpdateServiciosLinea;
using gp_Portal.Application.ServicioLinea.Commands.DeleteServiciosLinea;

namespace gp_Portal.WebUI.Controllers;

[AllowAnonymous]
public class ServiciosLineaController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedList<ServiciosLineaBriefDto>>> GetServiciosLineaWithPagination([FromQuery] GetServiciosLineaWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateServiciosLineaCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, UpdateServiciosLineaCommand command)
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
        await Mediator.Send(new DeleteServiciosLineaCommand(id));

        return NoContent();
    }
}