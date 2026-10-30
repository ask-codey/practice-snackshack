namespace SnackShack;

// The Snack Shack's menu and one week of sales, for the program to report on. It's finished.
public static class SampleData
{
    public static List<Snack> Menu()
    {
        return new List<Snack>
        {
            new Snack("Chips", "Salty", 1.50m, 160),
            new Snack("Pretzels", "Salty", 1.75m, 110),
            new Snack("Popcorn", "Salty", 2.00m, 130),
            new Snack("Cookie", "Sweet", 1.25m, 210),
            new Snack("Brownie", "Sweet", 2.50m, 240),
            new Snack("Candy Bar", "Sweet", 1.75m, 250),
            new Snack("Apple", "Healthy", 0.90m, 95),
            new Snack("Banana", "Healthy", 0.75m, 105),
            new Snack("Trail Mix", "Healthy", 2.25m, 170),
            new Snack("Granola Bar", "Healthy", 1.50m, 190)
        };
    }

    public static List<Sale> Sales(List<Snack> menu)
    {
        Snack Find(string name) => menu.Find(snack => snack.Name == name)!;

        return new List<Sale>
        {
            new Sale(Find("Chips"), 3, "Mon"),
            new Sale(Find("Cookie"), 2, "Mon"),
            new Sale(Find("Apple"), 1, "Mon"),
            new Sale(Find("Chips"), 2, "Tue"),
            new Sale(Find("Brownie"), 1, "Tue"),
            new Sale(Find("Popcorn"), 4, "Wed"),
            new Sale(Find("Cookie"), 3, "Wed"),
            new Sale(Find("Banana"), 2, "Wed"),
            new Sale(Find("Chips"), 2, "Thu"),
            new Sale(Find("Candy Bar"), 2, "Thu"),
            new Sale(Find("Trail Mix"), 1, "Fri"),
            new Sale(Find("Cookie"), 1, "Fri"),
            new Sale(Find("Popcorn"), 2, "Fri")
        };
    }
}
