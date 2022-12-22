namespace Mediator;

public interface IMediator
{
    public void Notify(Component component, string message);
}
