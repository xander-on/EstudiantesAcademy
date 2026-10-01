
using MediatR;

namespace Api.Modules.Carreras.Application.Features.DeleteCarrera;

public record DeleteCarreraCommand(Guid Id):IRequest<Guid>;