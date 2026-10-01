using FluentValidation;
using MediatR;

namespace Api.Modules.Carreras.Application.Features.UpdateCarrera;

public record UpdateCarreraRequest(
    string? Code, 
    string? Name, 
    string? Description,
    IReadOnlyList<Guid>? MateriasIds
);

public record UpdateCarreraCommand(
    Guid Id, 
    string? Code, 
    string? Name, 
    string? Description,
    IReadOnlyList<Guid>? MateriasIds
): IRequest<Guid>;


public class UpdateCarreraCommandValidator : AbstractValidator<UpdateCarreraCommand>
{
    public UpdateCarreraCommandValidator()
    {
        RuleFor(x => x.Code).MaximumLength(20).When(x => x.Code is not null);
        RuleFor(x => x.Name).MaximumLength(100).When(x => x.Name is not null);
        RuleFor(x => x.Description).MaximumLength(1000).When(x => x.Description is not null);

        RuleFor(x => x.MateriasIds)
            .Must(ids => ids?.Distinct().Count() == ids?.Count)
            .WithMessage("MateriasIds must be unique")
            .When(x => x.MateriasIds is not null);
    }
}