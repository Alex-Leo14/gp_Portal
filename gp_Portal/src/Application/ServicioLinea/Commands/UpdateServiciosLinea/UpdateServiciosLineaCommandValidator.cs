using FluentValidation;

namespace gp_Portal.Application.ServicioLinea.Commands.UpdateServiciosLinea;
public class UpdateServiciosLineaCommandValidator : AbstractValidator<UpdateServiciosLineaCommand>
{
    public UpdateServiciosLineaCommandValidator()
    {
        RuleFor(v => v.StartTime)
            .NotEmpty();
    }
}
