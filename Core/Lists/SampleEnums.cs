using System.ComponentModel;

namespace ClearMeasure.Palermo.Core.Lists;

public enum RelationshipEnum : short
{
    Father = 0,
    Mother = 1,
    Son = 2,
    Daughter = 3,
    Uncle = 4,
    Aunt = 5,
    Grandfather = 6,
    Grandmother = 7,
    GreatGrandfather = 8,
    GreatGrandmother = 9
}

public enum RelationshipAnnotated : short
{
    [Description("Father")]
    Father = 0,
    [Description("Mother")]
    Mother = 1,
    [Description("Son")]
    Son = 2,
    [Description("Daughter")]
    Daughter = 3,
    [Description("Uncle")]
    Uncle = 4,
    [Description("Aunt")]
    Aunt = 5,
    [Description("Grandfather")]
    Grandfather = 6,
    [Description("Grandmother")]
    Grandmother = 7,
    [Description("Great Grandfather")]
    GreatGrandfather = 8,
    [Description("Great Grandmother")]
    GreatGrandmother = 9
}
public enum BidType
{
    [Description("By the head")]
    ByTheHead,
    [Description("By the pound")]
    ByThePound
}