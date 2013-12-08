using Plinkit.Domain.Enums;

namespace Plinkit.Domain.Configuration
{
    public class RssFeeds
    {
        private const string WebDevelopmentFeed = "https://www.google.co.uk/search?lr=lang_en&hl=en&q=asp.net+AND+mvc+OR+%22web+development%22+OR+html5+blog+-jobs+-newslawonline+-%22experience+with%22+-stackoverflow+-blogspot.com+-freelancer.com&tbm=blg&output=rss&tbs=qdr:d,lr:lang_1en";
        private const string EntityFrameworkFeed = "https://www.google.co.uk/search?lr=lang_en&hl=en&q=%22entity+framework%22+OR+%22EF+5%22+OR+%22EF+6%22+OR+%28linq+AND+c%23%29+-job+-marketing+-blogspot.com&tbm=blg&output=rss&tbs=qdr:d,lr:lang_1en";
        private const string VisualStudioFeed = "https://www.google.co.uk/search?lr=lang_en&q=%22visual+studio%22+tools+blog+-stackoverflow+-consultant+-worlddesignernews&tbm=blg&output=rss&tbs=qdr:d,lr:lang_1en";
        private const string JavascriptFeed = "https://www.google.co.uk/search?lr=lang_en&hl=en&q=javascript+js+blog+-stackoverflow+-freelancer.com&tbm=blg&output=rss&tbs=qdr:d,lr:lang_1en";
        private const string CleanCodeFeed = "https://www.google.co.uk/search?lr=lang_en&client=firefox-a&rls=org.mozilla:en-US:official&q=c%23+%22best+practice%22+OR+%22clean+code%22+OR+%22design+patterns%22+OR+%22oo+technique%22+-job+-stackoverflow.com+-consultant+-seev.co.il&tbm=blg&output=rss&tbs=qdr:d,lr:lang_1en";
        private const string ProductivityFeed = "https://www.google.co.uk/search?lr=lang_en&q=developer+productivity+blog+-stackoverflow+-%22real estate%22&client=firefox-a&hs=PdG&rls=org.mozilla:en-US:official&tbm=blg&output=rss&tbs=qdr:d,lr:lang_1en";
        private const string UnitTestingFeed = "https://www.google.co.uk/search?lr=lang_en&client=firefox-a&hs=ET7&rls=org.mozilla:en-US:official&q=%22test+driven+development%22+OR+%22behaviour+driven+development%22+OR+%22unit+testing%22+OR+%22bdd%22+OR+nunit+-blogspot.com+-lte+-job+-hire+-hiring&tbm=blg&output=rss&tbs=qdr:d,lr:lang_1en";
        private const string ComputerScienceFeed = "https://www.google.co.uk/search?lr=lang_en&client=firefox-a&rls=org.mozilla:en-US:official&q=%22computer+science%22+OR+%22algorithms%22+OR+%22software+architecture%22+blog+-stackoverflow+-job+-university&tbm=blg&output=rss&tbs=qdr:d,lr:lang_1en";
        private const string FunctionalProgrammingAndFSharpFeed = "https://www.google.co.uk/search?client=firefox-a&hs=e8v&rls=org.mozilla:en-US:official&q=f%23+functional+blog&tbm=blg&output=rss&tbs=qdr:w,lr:lang_1en";
        private const string ComputingTechnologyFeed = "https://www.google.co.uk/search?lr=lang_en&client=firefox-a&rls=org.mozilla:en-US:official&q=technology+OR+itworld+OR+arstechnica+-stackoverflow&tbm=blg&output=rss&tbs=qdr:d,lr:lang_1en";
        private const string UncleBobFeed = "https://www.google.co.uk/search?lr=lang_en&q=%22robert+c+martin%22+blog+-stackoverflow&lr=lang_en&hl=en&tbm=blg&output=rss&tbs=qdr:m,lr:lang_1en";

        public static string WebDevelopment { get { return WebDevelopmentFeed; } }
        public static string EntityFramework { get { return EntityFrameworkFeed; } }
        public static string VisualStudio{ get { return VisualStudioFeed; } }
        public static string Javascript { get { return JavascriptFeed; } }
        public static string CleanCode { get { return CleanCodeFeed; } }
        public static string Productivity { get { return ProductivityFeed; } }
        public static string UnitTesting { get { return UnitTestingFeed; } }
        public static string ComputerScience { get { return ComputerScienceFeed; } }
        public static string FunctionalProgrammingAndFSharp { get { return FunctionalProgrammingAndFSharpFeed; } }
        public static string ComputingTechnology { get { return ComputingTechnologyFeed; } }
        public static string UncleBob { get { return UncleBobFeed; } }   
     
        public static int GetCategoryIdByFeedUrl(string feedUrl)
        {
            if (feedUrl == WebDevelopmentFeed)
                return (int) LinkCategories.WebDevelopment;
            if (feedUrl == EntityFrameworkFeed)
                return (int)LinkCategories.EntityFramework;
            if (feedUrl == VisualStudioFeed)
                return (int)LinkCategories.VisualStudio;
            if (feedUrl == JavascriptFeed)
                return (int)LinkCategories.Javascript;
            if (feedUrl == CleanCodeFeed)
                return (int)LinkCategories.CleanCode;
            if (feedUrl == ProductivityFeed)
                return (int)LinkCategories.Productivity;
            if (feedUrl == UnitTestingFeed)
                return (int)LinkCategories.UnitTesting;
            if (feedUrl == ComputerScienceFeed)
                return (int)LinkCategories.ComputerScience;
            if (feedUrl == FunctionalProgrammingAndFSharpFeed)
                return (int)LinkCategories.FunctionalProgrammingAndFSharp;
            if (feedUrl == ComputingTechnologyFeed)
                return (int)LinkCategories.ComputingTechnology;
            if (feedUrl == UncleBobFeed)
                return (int)LinkCategories.UncleBob;
            return (int) LinkCategories.Undefined;
        }
    }
}