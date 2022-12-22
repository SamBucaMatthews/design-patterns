namespace Mediator;

public class ComponentOne : Component
{
    public void ComponentOneMethodOne()
    {
        Mediator.Notify(this, nameof(ComponentOneMethodOne));
    }

    public void ComponentOneMethodTwo()
    {
        Mediator.Notify(this, nameof(ComponentOneMethodTwo));
    }
}
