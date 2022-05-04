using System;
using ClearMeasure.Palermo.Core;
using ClearMeasure.Palermo.Core.Lists;
using NUnit.Framework;
using Shouldly;

namespace ClearMeasure.Palermo.UnitTests;

[TestFixture]
public class SampleEnumsTester
{
    [Test]
    public void ShouldParseByName()
    {
        (RelationshipEnum.Father == 0).ShouldBe(true);
        ((short)RelationshipEnum.Mother == 1).ShouldBe(true);

        RelationshipEnum.Father.ToString().ShouldBe("Father");

        Enum.Parse<RelationshipEnum>("Father").ShouldBe(RelationshipEnum.Father);
    }

    [Test]
    public void ShouldUseAnnotations()
    {
        RelationshipAnnotated.GreatGrandfather.ToDescriptionString().ShouldBe("Great Grandfather");

        var values = EnumOptionValue<RelationshipAnnotated>.GetValues();
        foreach (var value in values)
        {
            Console.WriteLine($"{value.Name} - {value.Value}");
        }
    }
}