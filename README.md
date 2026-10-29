# Practice: SnackShack

Practice code for the lesson **Practice: SnackShack** in the C# Full-Stack Bootcamp on [ask-codey.com](https://www.ask-codey.com).

The Snack Shack sells chips, cookies and apples from a counter, and its owner has questions: what's cheap, what sells best, what never sells, and how much money came in on Wednesday. You'll answer each one with LINQ.

## What's here

- `SnackShack/Snack.cs`, `Sale.cs`: a snack on the menu, and one sale of it. Ready to use.
- `SnackShack/SampleData.cs`: the menu and a week of sales, for the program. Ready to use.
- `SnackShack/SnackReport.cs`: the questions, for you to answer. The requirements are in the comment at the top.
- `SnackShack.Tests`: tests for `SnackReport`, with their own small menu. You don't need to change these.

## What to do

Write each method of `SnackReport` with LINQ. Most are one chain of methods, with no `foreach` at all.

Run the program with **Ctrl+F5**, and the tests with **Test > Run All Tests** (or `dotnet test`).

## Tips

- Start with the easy ones: `NamesInCategory`, `TotalItemsSold`, `AllUnder`.
- Money from a sale is `sale.Snack.Price * sale.Quantity`, inside a `Sum`.
- `FindByName`: `FirstOrDefault`, comparing with `Equals(name, StringComparison.OrdinalIgnoreCase)`.
- `BestSeller` and `CategorySummary` need `GroupBy`: group the sales, then `Sum` each group's quantities.
- `NeverSold`: a snack never sold is one where no sale (`!sales.Any(...)`) is of that snack.
- `Page`: `Skip` the snacks on the pages before, then `Take` one page.

## Hand it in

When it works, push your solution to a public repo of your own on GitHub, then paste that repo's address into **Submit your exercise** on the lesson page at [ask-codey.com](https://www.ask-codey.com). That's what completes the lesson. The lesson page shows the Git commands, step by step.
