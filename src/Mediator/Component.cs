namespace Mediator;

public class Component
{
    protected IMediator Mediator = null!;

    public void SetMediator(IMediator mediator)
    {
        Mediator = mediator;
    }
}
