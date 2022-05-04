using System;
using System.Linq;
using ClearMeasure.Palermo.Core.Lists;
using NUnit.Framework;
using Shouldly;

namespace ClearMeasure.Palermo.UnitTests;

[TestFixture]
public class ExpenseReportStatusTester
{
    [Test]
    public void ShouldShowFriendlyStatus()
    {
        ExpenseReportStatus.Draft.FriendlyName.ShouldBe("Drafting");
        ExpenseReportStatus.Draft.Code.ShouldBe("DFT");
    }

    [Test]
    public void ShouldEnumerateValues()
    {
        var statuses = ExpenseReportStatus.GetAllItems();
        foreach (var status in statuses)
        {
            Console.WriteLine($"{status.Code} - {status.FriendlyName}");
        }
    }

    [Test]
    public void ShouldParse()
    {
        ExpenseReportStatus.Parse("Draft").ShouldBe(ExpenseReportStatus.Draft);
        ((ExpenseReportStatus)"DFT").ShouldBe(ExpenseReportStatus.Draft);
    }

    [Test]
    public void ShouldAcceptLoadingFriendlyNameFromDataSource()
    {
        ExpenseReportStatus.Draft.FriendlyName = "Pending Draft";

        ExpenseReportStatus.Draft.ShouldBeSameAs(ExpenseReportStatus.Draft);

        ExpenseReportStatus.Draft.FriendlyName.ShouldBe("Pending Draft");

        var all = ExpenseReportStatus.GetAllItems();
        all.Single(status => status == ExpenseReportStatus.Draft).FriendlyName.ShouldBe("Pending Draft");

        ExpenseReportStatus.Draft.FriendlyName = "Drafting";//reset to default
    }

    [Test]
    public void ShouldLoadNewStatusesFromDatabase()
    {
        ExpenseReportStatus.LoadExtensions(new[]
        {
            new ExpenseReportStatus("BLK", "Blocked", "Is blocked", 10),
            new ExpenseReportStatus("PRI", "Priority", "High priority", 11)
        });

        var items = ExpenseReportStatus.GetAllItems();
        foreach (var item in items)
        {
            Console.WriteLine(item);
        }
    }
}