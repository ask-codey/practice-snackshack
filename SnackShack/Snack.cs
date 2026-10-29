namespace SnackShack;

// One snack on the menu. It's finished.
public class Snack
{
    public string Name { get; }
    public string Category { get; }
    public decimal Price { get; }
    public int Calories { get; }

    public Snack(string name, string category, decimal price, int calories)
    {
        Name = name;
        Category = category;
        Price = price;
        Calories = calories;
    }
}
