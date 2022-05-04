using System;
using ClearMeasure.Palermo.Core;
using ClearMeasure.Palermo.Core.Lists;
using NUnit.Framework;
using Shouldly;

namespace ClearMeasure.Palermo.UnitTests;

[TestFixture]
public class EnumExtensionsTester
{
    [Test]
    public void BidTypeShouldHaveDescriptions()
    {
        BidType.ByTheHead.ToDescriptionString().ShouldBe("By the head");
    }

    [Test]
    public void ShouldGetDescription()
    {
        TestEnum.Value.ToDescriptionString().ShouldBe("description");
    }

    [Test]
    public void ShouldGetDescriptionListForFlags()
    {
        var flag1 = TestFlags.One;
        var flag2 = TestFlags.One | TestFlags.Two;
        var flag3 = TestFlags.One | TestFlags.Three;
        var flag4 = TestFlags.One | TestFlags.Two | TestFlags.Three;
        flag1.ToDescriptionString().ShouldBe("description 1");
        flag2.ToDescriptionString().ShouldBe("description 1, description 2");
        flag3.ToDescriptionString().ShouldBe("description 1, description 3");
        flag4.ToDescriptionString().ShouldBe("description 1, description 2, description 3");
    }

    [Test]
    public void ShouldGetDescriptionListForFlagsWithZero()
    {
        var flag0 = TestFlagsWithZero.Zero;
        var flag1 = TestFlagsWithZero.One;
        var flag2 = TestFlagsWithZero.One | TestFlagsWithZero.Two;
        var flag3 = TestFlagsWithZero.One | TestFlagsWithZero.Three;
        var flag4 = TestFlagsWithZero.One | TestFlagsWithZero.Two | TestFlagsWithZero.Three;
        flag0.ToDescriptionString().ShouldBe("zero");
        flag1.ToDescriptionString().ShouldBe("description 1");
        flag2.ToDescriptionString().ShouldBe("description 1, description 2");
        flag3.ToDescriptionString().ShouldBe("description 1, description 3");
        flag4.ToDescriptionString().ShouldBe("description 1, description 2, description 3");
    }

    enum TestEnum
    {
        [System.ComponentModel.Description("description")] Value
    }

    [Flags]
    enum TestFlags
    {
        [System.ComponentModel.Description("description 1")] One = 1,
        [System.ComponentModel.Description("description 2")] Two = 2,
        [System.ComponentModel.Description("description 3")] Three = 4
    }
    [Flags]
    enum TestFlagsWithZero
    {

        [System.ComponentModel.Description("zero")] Zero = 0,
        [System.ComponentModel.Description("description 1")] One = 1,
        [System.ComponentModel.Description("description 2")] Two = 2,
        [System.ComponentModel.Description("description 3")] Three = 4
    }

}