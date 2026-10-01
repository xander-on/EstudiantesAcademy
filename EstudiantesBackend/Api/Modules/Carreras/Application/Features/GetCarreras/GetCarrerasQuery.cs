using Api.Modules.Carreras.Application.Dtos;
using Api.Modules.Carreras.Domain;
using MediatR;

namespace Api.Modules.Carreras.Application.Features.GetCarreras;


public record GetCarrerasQuery(
    Guid? Id
): IRequest<CarreraResponse[]>;