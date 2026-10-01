using FluentValidation;
using MediatR;

namespace Api.Modules.Alumnos.Application.Features.CreateAlumno;

public record CreateAlumnoRequest(
    string Dni,
    string Name,
    string LastName,
    string Email
);

public record CreateAlumnoCommand(
    string Dni,
    string Name,
    string LastName,
    string Email
): IRequest<Guid>;


public class CreateAlumnoCommandValidator : AbstractValidator<CreateAlumnoCommand>
{
    public CreateAlumnoCommandValidator()
    {
        RuleFor(x => x.Dni).NotEmpty();
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
        RuleFor(x => x.Email).NotEmpty();
    }
}