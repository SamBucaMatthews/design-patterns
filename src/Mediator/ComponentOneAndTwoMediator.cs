namespace Mediator;

public class ComponentOneAndTwoMediator : IMediator
{
    private readonly ComponentOne _componentOne;
    private readonly ComponentTwo _componentTwo;
    private readonly MethodCallInterceptor _interceptor;

    public ComponentOneAndTwoMediator(
        ComponentOne componentOne,
        ComponentTwo componentTwo,
        MethodCallInterceptor interceptor)
    {
        _componentOne = componentOne;
        _componentTwo = componentTwo;
        _interceptor = interceptor;

        _componentOne.SetMediator(this);
        _componentTwo.SetMediator(this);
    }
    
    public void Notify(Component component, string message)
    {
        switch (message)
        {
            case nameof(ComponentOne.ComponentOneMethodOne):
                _interceptor.RecordMethodCall(nameof(ComponentTwo), nameof(ComponentTwo.ComponentTwoMethodTwo));
                _componentTwo.ComponentTwoMethodTwo();
                break;
            case nameof(ComponentTwo.ComponentTwoMethodOne):
                _interceptor.RecordMethodCall(nameof(ComponentOne), nameof(ComponentOne.ComponentOneMethodTwo));
                _componentOne.ComponentOneMethodTwo();
                break;
        }
    }
}
