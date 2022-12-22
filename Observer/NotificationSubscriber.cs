namespace Observer;

public class NotificationSubscriber : ISubscriber<Notification>
{
    public readonly List<Notification> Notifications = new();
    
    public virtual void Update(Notification notification)
    {
        Notifications.Add(notification);
    }
}
