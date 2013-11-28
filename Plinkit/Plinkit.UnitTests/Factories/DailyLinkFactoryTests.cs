using NUnit.Framework;
using Plinkit.Domain.Configuration;
using Plinkit.Domain.Models.Links;
using Plinkit.UI.Factories;

namespace Plinkit.UnitTests.Factories
{
    [TestFixture]
    public class DailyLinkFactoryTests
    {
        [Test]
        public void BuildDailyLink_WhenGivenWebDevelopmentFeedUrl_BuildCorrectLinkType()
        {
            var feedUrl = RssFeeds.WebDevelopment;
            var result = DailyLinkFactory.BuildDailyLink(feedUrl);
            Assert.IsInstanceOf(typeof(WebDevelopmentLink), result);
        }

        [Test]
        public void BuildDailyLink_WhenGivenEntityFrameworkFeedUrl_BuildCorrectLinkType()
        {
            var feedUrl = RssFeeds.EntityFramework;
            var result = DailyLinkFactory.BuildDailyLink(feedUrl);
            Assert.IsInstanceOf(typeof(EntityFrameworkLink), result);
        }

        [Test]
        public void BuildDailyLink_WhenGivenVisualStudioFeedUrl_BuildCorrectLinkType()
        {
            var feedUrl = RssFeeds.VisualStudio;
            var result = DailyLinkFactory.BuildDailyLink(feedUrl);
            Assert.IsInstanceOf(typeof(VisualStudioLink), result);
        }

        [Test]
        public void BuildDailyLink_WhenGivenJavascriptFeedUrl_BuildCorrectLinkType()
        {
            var feedUrl = RssFeeds.Javascript;
            var result = DailyLinkFactory.BuildDailyLink(feedUrl);
            Assert.IsInstanceOf(typeof(JavascriptLink), result);
        }
    }
}
