namespace SnackShack;

// Answers questions about the Snack Shack's menu and sales. Write each method with LINQ: most are
// one chain of methods, without a single foreach.
//
// Requirements:
// - UnderPrice(maxPrice): the snacks on the menu that cost maxPrice or less, cheapest first, and snacks
//   with the same price in alphabetical order.
// - NamesInCategory(category): the names of the snacks in that category, in alphabetical order.
// - FindByName(name): the snack with that name, whatever its capitals ("chips" finds Chips), or null if
//   there isn't one.
// - AllUnder(calories): true if every snack on the menu has fewer calories than that.
// - TotalItemsSold(): how many snacks were sold altogether (the quantities added up).
// - Revenue(): the money taken: each sale's price times its quantity, added up.
// - RevenueOn(day): the same, for the sales on one day, such as "Mon".
// - BestSeller(): the name of the snack with the most items sold. If two tie, the one first in
//   alphabetical order.
// - NeverSold(): the names of the snacks on the menu with no sales, in alphabetical order.
// - CategorySummary(): one line per category that has sales, in alphabetical order, such as
//   "Salty: 13 sold, $22.50".
// - Page(pageNumber, pageSize): one page of the menu in alphabetical order. Page 1 is the first
//   pageSize snacks, page 2 the next pageSize, and so on.
public class SnackReport
{
    private readonly List<Snack> menu;
    private readonly List<Sale> sales;

    public SnackReport(List<Snack> menu, List<Sale> sales)
    {
        this.menu = menu;
        this.sales = sales;
    }

    public List<Snack> UnderPrice(decimal maxPrice)
    {
        return new List<Snack>();
    }

    public List<string> NamesInCategory(string category)
    {
        return new List<string>();
    }

    public Snack? FindByName(string name)
    {
        return null;
    }

    public bool AllUnder(int calories)
    {
        return false;
    }

    public int TotalItemsSold()
    {
        return 0;
    }

    public decimal Revenue()
    {
        return 0m;
    }

    public decimal RevenueOn(string day)
    {
        return 0m;
    }

    public string BestSeller()
    {
        return "";
    }

    public List<string> NeverSold()
    {
        return new List<string>();
    }

    public List<string> CategorySummary()
    {
        return new List<string>();
    }

    public List<Snack> Page(int pageNumber, int pageSize)
    {
        return new List<Snack>();
    }
}
