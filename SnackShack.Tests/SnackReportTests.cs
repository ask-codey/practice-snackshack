namespace SnackShack.Tests;

[TestClass]
public class SnackReportTests
{
    private static readonly Snack Chips = new Snack("Chips", "Salty", 1.50m, 160);
    private static readonly Snack Popcorn = new Snack("Popcorn", "Salty", 2.00m, 130);
    private static readonly Snack Cookie = new Snack("Cookie", "Sweet", 1.25m, 210);
    private static readonly Snack Brownie = new Snack("Brownie", "Sweet", 2.50m, 240);
    private static readonly Snack Apple = new Snack("Apple", "Healthy", 0.90m, 95);
    private static readonly Snack Granola = new Snack("Granola Bar", "Healthy", 1.50m, 190);

    private static List<Snack> Menu() => new List<Snack> { Chips, Popcorn, Cookie, Brownie, Apple, Granola };

    private static SnackReport Report(params Sale[] sales) => new SnackReport(Menu(), sales.ToList());

    private static List<string> Names(List<Snack> snacks) => snacks.Select(snack => snack.Name).ToList();

    [TestMethod]
    public void UnderPrice_SomeSnacks_CheapestFirstThenByName()
    {
        List<Snack> snacks = Report().UnderPrice(1.50m);

        CollectionAssert.AreEqual(new List<string> { "Apple", "Cookie", "Chips", "Granola Bar" }, Names(snacks));
    }

    [TestMethod]
    public void NamesInCategory_Sweet_AlphabeticalNames()
    {
        CollectionAssert.AreEqual(new List<string> { "Brownie", "Cookie" }, Report().NamesInCategory("Sweet"));
    }

    [TestMethod]
    public void FindByName_AnyCapitals_FindsTheSnackOrNull()
    {
        SnackReport report = Report();

        Assert.AreSame(Popcorn, report.FindByName("popcorn"));
        Assert.AreSame(Granola, report.FindByName("GRANOLA BAR"));
        Assert.IsNull(report.FindByName("Soup"));
    }

    [TestMethod]
    public void AllUnder_Calories_TrueOnlyWhenEverySnackIsUnder()
    {
        SnackReport report = Report();

        Assert.IsTrue(report.AllUnder(250));
        Assert.IsFalse(report.AllUnder(240));
    }

    [TestMethod]
    public void TotalItemsSold_Sales_AddsTheQuantities()
    {
        SnackReport report = Report(new Sale(Chips, 3, "Mon"), new Sale(Cookie, 2, "Mon"), new Sale(Chips, 4, "Tue"));

        Assert.AreEqual(9, report.TotalItemsSold());
    }

    [TestMethod]
    public void Revenue_Sales_AddsPriceTimesQuantity()
    {
        SnackReport report = Report(new Sale(Chips, 3, "Mon"), new Sale(Brownie, 2, "Tue"));

        Assert.AreEqual(9.50m, report.Revenue());
    }

    [TestMethod]
    public void RevenueOn_Day_CountsOnlyThatDay()
    {
        SnackReport report = Report(new Sale(Chips, 3, "Mon"), new Sale(Brownie, 2, "Tue"), new Sale(Apple, 1, "Mon"));

        Assert.AreEqual(5.40m, report.RevenueOn("Mon"));
        Assert.AreEqual(5.00m, report.RevenueOn("Tue"));
    }

    [TestMethod]
    public void BestSeller_Sales_IsTheSnackWithTheMostItems()
    {
        SnackReport report = Report(new Sale(Chips, 2, "Mon"), new Sale(Cookie, 3, "Mon"), new Sale(Chips, 2, "Tue"));

        Assert.AreEqual("Chips", report.BestSeller());
    }

    [TestMethod]
    public void BestSeller_Tie_IsFirstAlphabetically()
    {
        SnackReport report = Report(new Sale(Popcorn, 4, "Mon"), new Sale(Cookie, 4, "Mon"));

        Assert.AreEqual("Cookie", report.BestSeller());
    }

    [TestMethod]
    public void NeverSold_Sales_ListsTheMenuSnacksWithNoSales()
    {
        SnackReport report = Report(new Sale(Chips, 1, "Mon"), new Sale(Cookie, 1, "Mon"), new Sale(Apple, 1, "Tue"));

        CollectionAssert.AreEqual(new List<string> { "Brownie", "Granola Bar", "Popcorn" }, report.NeverSold());
    }

    [TestMethod]
    public void CategorySummary_Sales_OneLinePerCategoryInOrder()
    {
        SnackReport report = Report(
            new Sale(Chips, 3, "Mon"),
            new Sale(Cookie, 2, "Mon"),
            new Sale(Popcorn, 1, "Tue"),
            new Sale(Brownie, 1, "Wed"));

        CollectionAssert.AreEqual(
            new List<string> { "Salty: 4 sold, $6.50", "Sweet: 3 sold, $5.00" },
            report.CategorySummary());
    }

    [TestMethod]
    public void Page_First_IsTheFirstSnacksAlphabetically()
    {
        CollectionAssert.AreEqual(new List<string> { "Apple", "Brownie", "Chips", "Cookie" }, Names(Report().Page(1, 4)));
    }

    [TestMethod]
    public void Page_Last_HoldsWhatIsLeft()
    {
        CollectionAssert.AreEqual(new List<string> { "Granola Bar", "Popcorn" }, Names(Report().Page(2, 4)));
    }
}
