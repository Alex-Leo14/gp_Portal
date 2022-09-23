using FluentValidation;

namespace gp_Portal.Application.ServicioLinea.Queries.GetServiciosLineaWithPagination;
public class GetServiciosLineaWithPaginationQueryValidator : AbstractValidator<GetServiciosLineaWithPaginationQuery>
{
    public GetServiciosLineaWithPaginationQueryValidator()
    {
        RuleFor(x => x.LineaId)
            .NotEmpty().WithMessage("IdLinea is required.");

    }
}