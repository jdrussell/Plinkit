namespace Plinkit.UI.Configuration
{
    public class RssFeeds
    {        
        private const string WebDevelopmentFeed = "https://www.google.co.uk/search?lr=lang_en&hl=en&q=%22asp+net%22+mvc+html+5+blog+-job+-newslawonline+-download+-%22experience+with%22&tbm=blg&output=rss&tbs=qdr:d,lr:lang_1en";
        private const string EntityFrameworkFeed = "https://www.google.co.uk/search?lr=lang_en&hl=en&q=%22entity+framework%22+linq+blog&tbm=blg&output=rss&tbs=qdr:d,lr:lang_1en";
        private const string VisualStudioFeed = "https://www.google.co.uk/search?lr=lang_en&q=%22visual+studio%22+tools+blog&tbm=blg&output=rss&tbs=qdr:d,lr:lang_1en";
        private const string JavascriptFeed = "https://www.google.co.uk/search?q=javascript+js+blog&tbm=blg&output=rss&tbs=qdr:d,lr:lang_1en";
        private const string CleanCodeFeed = "https://www.google.co.uk/search?client=firefox-a&hs=EbG&rls=org.mozilla:en-US:official&q=software+best+practice&tbm=blg&output=rss&tbs=qdr:d,lr:lang_1en";
        private const string ProductivityFeed = "https://www.google.co.uk/search?q=developer+productivity+blog&client=firefox-a&hs=PdG&rls=org.mozilla:en-US:official&tbm=blg&output=rss&tbs=qdr:d,lr:lang_1en";
        private const string UnitTestingFeed = "https://www.google.co.uk/search?q=unit+testing+tdd+blog&client=firefox-a&hs=myv&rls=org.mozilla:en-US:official&tbm=blg&output=rss&tbs=qdr:d,lr:lang_1en";
        private const string ComputerScienceFeed = "https://www.google.co.uk/search?client=firefox-a&hs=RkG&rls=org.mozilla:en-US:official&q=%22computer+science%22+algorithms+blog&tbm=blg&output=rss&tbs=qdr:d,lr:lang_1en";
        private const string FunctionalProgrammingAndFSharpFeed = "https://www.google.co.uk/search?client=firefox-a&hs=e8v&rls=org.mozilla:en-US:official&q=f%23+%22functional+programming%22+blog&tbm=blg&output=rss&tbs=qdr:d,lr:lang_1en";
        private const string ComputingTechnologyFeed = "https://www.google.co.uk/search?q=computing+technology+blog&client=firefox-a&hs=HpG&rls=org.mozilla:en-US:official&tbm=blg&output=rss&tbs=qdr:d,lr:lang_1en";
        private const string UncleBobFeed = "https://www.google.co.uk/search?lr=lang_en&q=%22clean+coder%22+blog&hl=en&tbm=blg&output=rss&tbs=qdr:w,lr:lang_1en";

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
    }
}