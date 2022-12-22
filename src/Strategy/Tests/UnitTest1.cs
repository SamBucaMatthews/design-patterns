namespace Strategy.Tests;

public class Tests
{
    [Test]
    public void BookConsignment_GivenCourierOneBooking_ReturnsCourierOneBookingReference()
    {
        var booking = new Booking(Courier.One, "Some details");

        var consignmentManager = new ConsignmentManager();

        var bookingReference = consignmentManager.BookConsignment(booking);
        
        Assert.That(bookingReference, Does.StartWith("CourierOneReference:"));
    }
    
    [Test]
    public void BookConsignment_GivenCourierTwoBooking_ReturnsCourierTwoBookingReference()
    {
        var booking = new Booking(Courier.Two, "Some details");

        var consignmentManager = new ConsignmentManager();

        var bookingReference = consignmentManager.BookConsignment(booking);
        
        Assert.That(bookingReference, Does.StartWith("CourierTwoReference:"));
    }
}