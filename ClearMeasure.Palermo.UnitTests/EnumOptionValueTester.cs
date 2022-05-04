using ClearMeasure.Palermo.Core;
using NUnit.Framework;
using Shouldly;

namespace ClearMeasure.Palermo.UnitTests;

[TestFixture]
public class EnumOptionValueTester
{
    [Test]
    public void ShouldStoreDescriptionAsName()
    {
        var enumOptions = EnumOptionValue<TestEnum>.GetValues();
        enumOptions[0].Name.ShouldBe("Test name 1");
        enumOptions[1].Name.ShouldBe("Test name 2");
    }

    [Test]
    public void ShouldStoreEnumAsValue()
    {
        var enumOptions = EnumOptionValue<TestEnum>.GetValues();
        enumOptions[0].Value.ShouldBe(TestEnum.EnumValue1);
        enumOptions[1].Value.ShouldBe(TestEnum.EnumValue2);
    }
}

enum TestEnum
{
    [System.ComponentModel.Description("Test name 1")]
    EnumValue1,
    [System.ComponentModel.Description("Test name 2")]
    EnumValue2,

}