using System.ComponentModel;

namespace Plinkit.Domain.Enums
{
    public enum LinkCategories
    {
        [Description("Undefined")]
        Undefined = 0,
        [Description("Web Development")]
        WebDevelopment = 1,
        [Description("Entity Framework")]
        EntityFramework = 2,
        [Description("Visual Studio")]
        VisualStudio = 3,
        [Description("Javascript")]
        Javascript = 4,
        [Description("Clean Code")]
        CleanCode = 5,
        [Description("Productivity")]
        Productivity = 6,
        [Description("Unit Testing")]
        UnitTesting = 7,
        [Description("Computer Science")]
        ComputerScience = 8,
        [Description("Functional Programming and F#")]
        FunctionalProgrammingAndFSharp = 9,
        [Description("Computing Technology")]
        ComputingTechnology = 10,
        [Description("Uncle Bob")]
        UncleBob = 11
    }
}
