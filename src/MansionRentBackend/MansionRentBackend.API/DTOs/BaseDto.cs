using Autofac;

namespace MansionRentBackend.API.DTOs;

public class BaseDto
{
    protected ILifetimeScope _scope;

    public BaseDto()
    {
    }

    public virtual void ResolveDependency(ILifetimeScope scope)
    {
        _scope = scope;
    }
}