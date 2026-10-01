using Api.Modules.Shared.Application.Behaviors;
using Api.Modules.Shared.Infrastructure.Exceptions;
using FluentValidation;
using MediatR;

namespace Api.Modules.Shared;



public static class SharedModule
{
    public static void AddServices(IServiceCollection services)
    {
        services.AddMediatR(cfg =>
            cfg.RegisterServicesFromAssembly(typeof(SharedModule).Assembly)
        );

        services.AddValidatorsFromAssembly(typeof(SharedModule).Assembly);
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

        services.AddExceptionHandler<ValidationExceptionHandler>();
        services.AddProblemDetails();
    }
}

