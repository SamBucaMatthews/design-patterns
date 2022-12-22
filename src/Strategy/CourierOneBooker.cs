namespace Strategy;

public class CourierOneBooker : IConsignmentBooker
{
    public string BookConsignment(string details)
    {
        /* Realistically this would have Courier specific code to go
         and book a consignment and give us back a reference */
        
        return $"CourierOneReference: {new Random().Next()}";
    }
}
