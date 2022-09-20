using FluentValidation;
using Microsoft.EntityFrameworkCore;
using gp_Portal.Application.Common.Interfaces;

namespace gp_Portal.Application.Linea.Commands.UpdateLineaBE;
public class UpdateLineaBECommandValidator : AbstractValidator<UpdateLineaBECommand>
{
    private readonly IApplicationDbContext _context;

    public UpdateLineaBECommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.Name)
            .NotEmpty().WithMessage("Nombre is required.")
            .MaximumLength(200).WithMessage("Title must not exceed 200 characters.")
            .MustAsync(BeUniqueTitle).WithMessage("The specified title already exists.");

        RuleFor(v => v.Route)
            .NotEmpty().WithMessage("Ruta is required.")
            .MaximumLength(200).WithMessage("Title must not exceed 200 characters.")
            .MustAsync(BeUniqueTitle).WithMessage("The specified title already exists.");

        RuleFor(v => v.Direction)
            .NotEmpty().WithMessage("Direccion is required.");


        RuleFor(v => v.Status)
            .NotEmpty().WithMessage("Estado is required.");
            
    }

    public async Task<bool> BeUniqueTitle(UpdateLineaBECommand model, string title, CancellationToken cancellationToken)
    {
        return await _context.Lineas
            .Where(l => l.Id != model.Id)
            .AllAsync(l => l.Name != title, cancellationToken);
            

    }
}
