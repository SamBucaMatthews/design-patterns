namespace Mediator;

public class MethodCallInterceptor
{
    public List<(string componentName, string methodCall)> MethodCalls { get; } = new();

    public void RecordMethodCall(string componentName, string methodCall)
    {
        MethodCalls.Add((componentName, methodCall));
    }
}
