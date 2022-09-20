using FluentValidation;
using Microsoft.EntityFrameworkCore;
using gp_Portal.Application.Common.Interfaces;

namespace gp_Portal.Application.Linea.Commands.CreateLineaBE;
public class CreateLineaBEtCommandValidator : AbstractValidator<CreateLineaBECommand>
{
    private readonly IApplicationDbContext _context;

    public CreateLineaBEtCommandValidator(IApplicationDbContext context)
    {
        _context = context;

        RuleFor(v => v.Name)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(200).WithMessage("Title must not exceed 200 characters.")
            .MustAsync(BeUniqueTitle).WithMessage("The specified title already exists.");

        RuleFor(v => v.Route)
            .NotEmpty().WithMessage("Title is required.")
            .MaximumLength(200).WithMessage("Title must not exceed 200 characters.")
            .MustAsync(BeUniqueTitle).WithMessage("The specified title already exists.");

        RuleFor(v => v.Direction)
            .NotEmpty().WithMessage("Title is required.");

        RuleFor(v => v.Status)
            .NotEmpty().WithMessage("Title is required.");
            
    }

    public async Task<bool> BeUniqueTitle(string title, CancellationToken cancellationToken)
    {
        return await _context.Lineas
            .AllAsync(l => l.Name != title, cancellationToken);
    }
}
