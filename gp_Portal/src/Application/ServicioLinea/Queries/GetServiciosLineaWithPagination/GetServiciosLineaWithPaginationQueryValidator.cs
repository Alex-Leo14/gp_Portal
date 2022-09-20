using FluentValidation;

namespace gp_Portal.Application.ServicioLinea.Queries.GetServiciosLineaWithPagination;
public class GetServiciosLineaWithPaginationQueryValidator : AbstractValidator<GetServiciosLineaWithPaginationQuery>
{
    public GetServiciosLineaWithPaginationQueryValidator()
    {
        RuleFor(x => x.LineaId)
            .NotEmpty().WithMessage("IdLinea is required.");

        //RuleFor(x => x.PageNumber)
        //    .GreaterThanOrEqualTo(1).WithMessage("PageNumber at least greater than or equal to 1.");

        //RuleFor(x => x.PageSize)
        //    .GreaterThanOrEqualTo(1).WithMessage("PageSize at least greater than or equal to 1.");
    }
}
