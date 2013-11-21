using Plinkit.Domain.Models.Links;
using Plinkit.UI.Configuration;

namespace Plinkit.UI.Factories
{
    public class DailyLinkFactory
    {
        public static DailyLink BuildDailyLink(string feedUrl)
        {
            if (feedUrl == RssFeeds.WebDevelopment)
                return new WebDevelopmentLink();
            if (feedUrl == RssFeeds.EntityFramework)
                return new EntityFrameworkLink();
            if(feedUrl == RssFeeds.VisualStudio)
                return new VisualStudioLink();
            if (feedUrl == RssFeeds.Javascript)
                return new JavascriptLink();
            if (feedUrl == RssFeeds.CleanCode)
                return new CleanCodeLink();
            if (feedUrl == RssFeeds.Productivity)
                return new ProductivityLink();
            if (feedUrl == RssFeeds.UnitTesting)
                return new UnitTestingLink();
            if (feedUrl == RssFeeds.ComputerScience)
                return new ComputerScienceLink();
            if (feedUrl == RssFeeds.FunctionalProgrammingAndFSharp)
                return new FunctionalProgrammingAndFSharpLink();
            if (feedUrl == RssFeeds.ComputingTechnology)
                return new ComputingTechnologyLink();
            if (feedUrl == RssFeeds.UncleBob)
                return new UncleBobLink();
            return new UndefinedLink();
        }
    }
}