using FluentValidation;
using MediatR;

namespace Api.Modules.Carreras.Application.Features.CreateCarrera;

public record CreateCarreraRequest(
    string Code, 
    string Name, 
    string Description,
    IReadOnlyList<Guid>? MateriasIds
);

public record CreateCarreraCommand(
    string Code, 
    string Name, 
    string Description,
    IReadOnlyList<Guid>? MateriasIds
): IRequest<Guid>;


public class CreateCarreraCommandValidator : AbstractValidator<CreateCarreraCommand>
{
    public CreateCarreraCommandValidator()
    {
        RuleFor(x => x.Code).NotEmpty();
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();

        RuleFor(x => x.MateriasIds)
            .Must(ids => ids?.Distinct().Count() == ids?.Count)
            .WithMessage("MateriasIds must be unique")
            .When(x => x.MateriasIds is not null);
    }
}