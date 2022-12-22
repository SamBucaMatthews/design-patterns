namespace Observer;

public interface ISubscriber<T>
{
    void Update(T notification);
}
