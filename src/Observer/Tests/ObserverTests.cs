namespace Observer.Tests;

public class ObserverTests
{
    private readonly Notification _notification = new("Something happened!");

    private Publisher _publisher = null!;

    [SetUp]
    public void SetUp()
    {
        _publisher = new Publisher();
    }
    
    [Test]
    public void Notify_GivenMultipleSubscribers_UpdatesEachSubscriber()
    {
        var subscriber1 = new NotificationSubscriber();
        var subscriber2 = new NotificationSubscriber();
        var subscriber3 = new NotificationSubscriber();

        _publisher.Subscribe(subscriber1);
        _publisher.Subscribe(subscriber2);
        _publisher.Subscribe(subscriber3);

        _publisher.Notify(_notification);
        
        Assert.Multiple(() =>
        {
            Assert.That(subscriber1.Notifications, Has.Count.EqualTo(1));
            Assert.That(subscriber2.Notifications, Has.Count.EqualTo(1));
            Assert.That(subscriber3.Notifications, Has.Count.EqualTo(1));
        });
        
        Assert.Multiple(() =>
        {
            Assert.That(subscriber1.Notifications[0], Is.EqualTo(_notification));
            Assert.That(subscriber2.Notifications[0], Is.EqualTo(_notification));
            Assert.That(subscriber3.Notifications[0], Is.EqualTo(_notification));
        });
    }

    [Test]
    public void Notify_GivenUnsubscribedSubscriber_UpdatesOnlySubscribedSubscribers()
    {
        var subscriber1 = new NotificationSubscriber();
        var subscriber2 = new NotificationSubscriber();
        
        _publisher.Subscribe(subscriber1);
        _publisher.Subscribe(subscriber2);
        
        _publisher.Unsubscribe(subscriber2);
        
        _publisher.Notify(_notification);
        
        Assert.Multiple(() =>
        {
            Assert.That(subscriber1.Notifications, Has.Count.EqualTo(1));
            Assert.That(subscriber2.Notifications, Is.Empty);
            Assert.That(subscriber1.Notifications[0], Is.EqualTo(_notification));
        });
    }
}