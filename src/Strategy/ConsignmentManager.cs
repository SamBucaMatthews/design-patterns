namespace Strategy;

public class ConsignmentManager
{
    private IConsignmentBooker _consignmentBooker = null!;

    public string BookConsignment(Booking booking)
    {
        _consignmentBooker = booking.Courier switch
        {
            Courier.One => new CourierOneBooker(),
            Courier.Two => new CourierTwoBooker(),
            _ => throw new ArgumentOutOfRangeException()
        };

        return _consignmentBooker.BookConsignment(booking.Details);
    }
}
