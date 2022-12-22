namespace Observer;

public interface IPublisher<T>
{
    void Subscribe(ISubscriber<T> subscriber);

    void Unsubscribe(ISubscriber<T> subscriber);

    void Notify(T notification);
}
