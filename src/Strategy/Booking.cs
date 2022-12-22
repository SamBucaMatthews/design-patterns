namespace Strategy;

public record Booking(Courier Courier, string Details)
{
    public Courier Courier = Courier;

    public string Details = Details;
}