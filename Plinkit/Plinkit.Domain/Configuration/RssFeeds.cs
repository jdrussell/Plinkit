using Plinkit.Domain.Enums;

namespace Plinkit.Domain.Configuration
{
    public class RssFeeds
    {
        private const string WebDevelopmentFeed = "https://www.google.co.uk/search?lr=lang_en&hl=en&q=asp+net+mvc+developer+blog+-jobs+-newslawonline+-%22experience+with%22+-stackoverflow&lr=lang_en&hl=en&tbm=blg&output=rss&tbs=qdr:d,lr:lang_1en";                                                  
        private const string EntityFrameworkFeed = "https://www.google.co.uk/search?lr=lang_en&hl=en&q=%22entity+framework%22+linq+blog+-job+-stackoverflow&tbm=blg&output=rss&tbs=qdr:d,lr:lang_1en";
        private const string VisualStudioFeed = "https://www.google.co.uk/search?lr=lang_en&q=%22visual+studio%22+tools+blog+-stackoverflow&tbm=blg&output=rss&tbs=qdr:d,lr:lang_1en";
        private const string JavascriptFeed = "https://www.google.co.uk/search?lr=lang_en&hl=en&q=javascript+js+blog+-stackoverflow&tbm=blg&output=rss&tbs=qdr:d,lr:lang_1en";
        private const string CleanCodeFeed = "https://www.google.co.uk/search?client=firefox-a&hs=EbG&rls=org.mozilla:en-US:official&q=software+best+practice+-stackoverflow&tbm=blg&output=rss&tbs=qdr:d,lr:lang_1en";
        private const string ProductivityFeed = "https://www.google.co.uk/search?q=developer+productivity+blog+-stackoverflow+-%22real estate%22&client=firefox-a&hs=PdG&rls=org.mozilla:en-US:official&tbm=blg&output=rss&tbs=qdr:d,lr:lang_1en";
        private const string UnitTestingFeed = "https://www.google.co.uk/search?q=unit+testing+tdd+blog+-stackoverflow&client=firefox-a&hs=myv&rls=org.mozilla:en-US:official&tbm=blg&output=rss&tbs=qdr:d,lr:lang_1en";
        private const string ComputerScienceFeed = "https://www.google.co.uk/search?client=firefox-a&hs=RkG&rls=org.mozilla:en-US:official&q=%22computer+science%22+algorithms+blog+-stackoverflow&tbm=blg&output=rss&tbs=qdr:d,lr:lang_1en";
        private const string FunctionalProgrammingAndFSharpFeed = "https://www.google.co.uk/search?client=firefox-a&hs=e8v&rls=org.mozilla:en-US:official&q=f%23+functional+blog&tbm=blg&output=rss&tbs=qdr:w,lr:lang_1en";
        private const string ComputingTechnologyFeed = "https://www.google.co.uk/search?q=computing+technology+blog+-stackoverflow&client=firefox-a&hs=HpG&rls=org.mozilla:en-US:official&tbm=blg&output=rss&tbs=qdr:d,lr:lang_1en";
        private const string UncleBobFeed = "https://www.google.co.uk/search?q=%22robert+c+martin%22+blog+-stackoverflow&lr=lang_en&hl=en&tbm=blg&output=rss&tbs=qdr:m,lr:lang_1en";

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