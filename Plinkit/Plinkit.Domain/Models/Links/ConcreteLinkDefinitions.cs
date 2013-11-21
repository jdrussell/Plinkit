using Plinkit.Domain.Enums;
using Plinkit.Domain.Extensions;

namespace Plinkit.Domain.Models.Links
{
    public class WebDevelopmentLink : DailyLink
    {
        public override string GetCategory()
        {
            return LinkCategories.WebDevelopment.GetDescription();
        }
    }

    public class EntityFrameworkLink : DailyLink
    {
        public override string GetCategory()
        {
            return LinkCategories.EntityFramework.GetDescription();
        }
    }

    public class VisualStudioLink : DailyLink
    {
        public override string GetCategory()
        {
            return LinkCategories.VisualStudio.GetDescription();
        }
    }

    public class JavascriptLink : DailyLink
    {
        public override string GetCategory()
        {
            return LinkCategories.Javascript.GetDescription();
        }
    }

    public class CleanCodeLink : DailyLink
    {
        public override string GetCategory()
        {
            return LinkCategories.CleanCode.GetDescription();
        }
    }

    public class ProductivityLink : DailyLink
    {
        public override string GetCategory()
        {
            return LinkCategories.Productivity.GetDescription();
        }
    }

    public class UnitTestingLink : DailyLink
    {
        public override string GetCategory()
        {
            return LinkCategories.UnitTesting.GetDescription();
        }
    }

    public class ComputerScienceLink : DailyLink
    {
        public override string GetCategory()
        {
            return LinkCategories.ComputerScience.GetDescription();
        }
    }

    public class FunctionalProgrammingAndFSharpLink : DailyLink
    {
        public override string GetCategory()
        {
            return LinkCategories.FunctionalProgrammingAndFSharp.GetDescription();
        }
    }

    public class ComputingTechnologyLink : DailyLink
    {
        public override string GetCategory()
        {
            return LinkCategories.ComputingTechnology.GetDescription();
        }
    }

    public class UncleBobLink : DailyLink
    {
        public override string GetCategory()
        {
            return LinkCategories.UncleBob.GetDescription();
        }
    }

    public class UndefinedLink : DailyLink
    {
        public override string GetCategory()
        {
            return LinkCategories.Undefined.GetDescription();
        }
    }
}
