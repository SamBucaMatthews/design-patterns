namespace Mediator;

public class ComponentTwo : Component
{
    public void ComponentTwoMethodOne()
    {
        Mediator.Notify(this, nameof(ComponentTwoMethodOne));
    }
    
    public void ComponentTwoMethodTwo()
    {
        Mediator.Notify(this, nameof(ComponentTwoMethodTwo));
    }
}
