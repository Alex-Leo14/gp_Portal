using FluentValidation;

namespace gp_Portal.Application.ServicioLinea.Commands.CreateServiciosLinea;
public class CreateServiciosLineaCommandValidator : AbstractValidator<CreateServiciosLineaCommand>
{
    public CreateServiciosLineaCommandValidator()
    {
        RuleFor(v => v.StartTime)
            .NotEmpty();
    }
}
