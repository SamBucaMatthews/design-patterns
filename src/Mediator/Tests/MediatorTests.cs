namespace Mediator.Tests;

public class Tests
{
    private MethodCallInterceptor _methodCallInterceptor = null!;

    [SetUp]
    public void SetUp()
    {
        _methodCallInterceptor = new MethodCallInterceptor();
    }
    
    [Test]
    public void MethodOneOfComponentOne_CallsMethodTwoOfComponentTwo()
    {
        var componentOne = new ComponentOne();
        var componentTwo = new ComponentTwo();

        _ = new ComponentOneAndTwoMediator(componentOne, componentTwo, _methodCallInterceptor);

        componentOne.ComponentOneMethodOne();
        
        Assert.That(_methodCallInterceptor.MethodCalls, Has.Count.EqualTo(1));
        Assert.That(_methodCallInterceptor.MethodCalls[0].componentName, Is.EqualTo(nameof(ComponentTwo)));
        Assert.That(
            _methodCallInterceptor.MethodCalls[0].methodCall,
            Is.EqualTo(nameof(ComponentTwo.ComponentTwoMethodTwo)));
    }
    
    [Test]
    public void MethodOneOfComponentTwo_CallsMethodTwoOfComponentOne()
    {
        var componentOne = new ComponentOne();
        var componentTwo = new ComponentTwo();

        _ = new ComponentOneAndTwoMediator(componentOne, componentTwo, _methodCallInterceptor);

        componentTwo.ComponentTwoMethodOne();
        
        Assert.That(_methodCallInterceptor.MethodCalls, Has.Count.EqualTo(1));
        Assert.That(_methodCallInterceptor.MethodCalls[0].componentName, Is.EqualTo(nameof(ComponentOne)));
        Assert.That(
            _methodCallInterceptor.MethodCalls[0].methodCall,
            Is.EqualTo(nameof(ComponentOne.ComponentOneMethodTwo)));
    }
}