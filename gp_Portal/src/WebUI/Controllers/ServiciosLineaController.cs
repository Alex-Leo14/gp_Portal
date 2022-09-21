
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using gp_Portal.Application.Common.Models;
using gp_Portal.Application.ServicioLinea.Queries.GetServiciosLineaWithPagination;
using gp_Portal.Application.ServicioLinea.Commands.CreateServiciosLinea;
using gp_Portal.Application.ServicioLinea.Commands.UpdateServiciosLinea;
using gp_Portal.Application.ServicioLinea.Commands.DeleteServiciosLinea;
using gp_Portal.Application.Linea.Queries.GetLineaBE;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace gp_Portal.WebUI.Controllers;

[AllowAnonymous]
public class ServiciosLineaController : ApiControllerBase
{
    //[HttpGet]
    //public async Task<ActionResult<PaginatedList<Application.ServicioLinea.Queries.GetServiciosLineaWithPagination.ServiciosLineaDto>>> GetServiciosLineaWithPagination([FromQuery] GetServiciosLineaWithPaginationQuery query)
    //{
    //    return await Mediator.Send(query);
    //}

    [HttpGet]
    public async Task<ActionResult<ServiciosLineaVm>> ListByLineaId(int ID)
    {
   
        
            return await Mediator.Send(new GetServiciosLineaQuery(ID));


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
