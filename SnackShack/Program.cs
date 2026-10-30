using SnackShack;

List<Snack> menu = SampleData.Menu();
SnackReport report = new SnackReport(menu, SampleData.Sales(menu));

Console.WriteLine("$1.50 or less:");
foreach (Snack snack in report.UnderPrice(1.50m))
{
    Console.WriteLine($"  {snack.Name} {snack.Price:C}");
}

Console.WriteLine($"Sweet snacks: {string.Join(", ", report.NamesInCategory("Sweet"))}");
Console.WriteLine($"Items sold: {report.TotalItemsSold()}");
Console.WriteLine($"Revenue: {report.Revenue():C} (Wednesday: {report.RevenueOn("Wed"):C})");
Console.WriteLine($"Best seller: {report.BestSeller()}");
Console.WriteLine($"Never sold: {string.Join(", ", report.NeverSold())}");

foreach (string line in report.CategorySummary())
{
    Console.WriteLine(line);
}
