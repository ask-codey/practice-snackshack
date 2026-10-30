namespace SnackShack;

// One sale: a number of one snack, sold on a day such as "Mon". It's finished.
public class Sale
{
    public Snack Snack { get; }
    public int Quantity { get; }
    public string Day { get; }

    public Sale(Snack snack, int quantity, string day)
    {
        Snack = snack;
        Quantity = quantity;
        Day = day;
    }
}
