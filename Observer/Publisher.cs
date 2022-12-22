namespace Observer;

public class Publisher : IPublisher<Notification>
{
    private readonly List<ISubscriber<Notification>> _subscribers = new();

    public void Subscribe(ISubscriber<Notification> subscriber)
    {
        _subscribers.Add(subscriber);
    }

    public void Unsubscribe(ISubscriber<Notification> subscriber)
    {
        _subscribers.Remove(subscriber);
    }

    public void Notify(Notification notification)
    {
        foreach (var subscriber in _subscribers)
        {
            subscriber.Update(notification);
        }
    }
}
