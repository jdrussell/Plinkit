using System;
using System.Collections.Generic;
using System.Linq;
using Plinkit.Domain.Configuration;
using Plinkit.Domain.Models;
using Plinkit.Domain.Models.Links;
using Plinkit.Domain.Repositories;
using Plinkit.UI.Services;

namespace Plinkit.UI.ViewModels
{
    public class DailyLinksViewModel
    {                   
        private readonly IRepository<DailyLinksContainer> _repository;
        private DailyLinksContainer _container;
        private bool _persistNewLinksCollection;

        public DateTime Date;     
        public IEnumerable<DailyLink> WebDevelopmentLinks
        {
            get
            {
                return _container.Links.OfType<WebDevelopmentLink>();
            }
        }

        public IEnumerable<DailyLink> EntityFrameworkLinks
        {
            get
            {
                return _container.Links.OfType<EntityFrameworkLink>();
            }
        }

        public IEnumerable<DailyLink> VisualStudioLinks
        {
            get
            {
                return _container.Links.OfType<VisualStudioLink>();
            }
        }

        public IEnumerable<DailyLink> JavascriptLinks
        {
            get
            {
                return _container.Links.OfType<JavascriptLink>();
            }
        }

        public IEnumerable<DailyLink> CleanCodeLinks
        {
            get
            {
                return _container.Links.OfType<CleanCodeLink>();
            }
        }

        public IEnumerable<DailyLink> ProductivityLinks
        {
            get
            {
                return _container.Links.OfType<ProductivityLink>();
            }
        }

        public IEnumerable<DailyLink> UnitTestingLinks
        {
            get
            {
                return _container.Links.OfType<UnitTestingLink>();
            }
        }

        public IEnumerable<DailyLink> ComputerScienceLinks
        {
            get
            {
                return _container.Links.OfType<ComputerScienceLink>();
            }
        }

        public IEnumerable<DailyLink> FunctionalProgrammingAndFSharpLinks
        {
            get
            {
                return _container.Links.OfType<FunctionalProgrammingAndFSharpLink>();
            }
        }

        public IEnumerable<DailyLink> ComputingTechnologyLinks
        {
            get
            {
                return _container.Links.OfType<ComputingTechnologyLink>();
            }
        }

        public IEnumerable<DailyLink> UncleBobLinks
        {
            get
            {
                return _container.Links.OfType<UncleBobLink>();
            }
        }

        public DailyLinksViewModel(IRepository<DailyLinksContainer> repository, DateTime date)
        {
            Date = date;
            _repository = repository;
            SetupData();
        }

        private void SetupData()
        {
            SetDailyLinksContainer();
            SetLinksData();
        }

        private void SetDailyLinksContainer()
        {
            //_container = _repository.GetByDate(Date);
            if (_container == null)
            {
                _container = new DailyLinksContainer
                    {
                        Date = Date,
                        Links = new List<DailyLink>()
                    };
                _persistNewLinksCollection = true;
            }
        }

        private void SetLinksData()
        {
            if (_persistNewLinksCollection)
            {
                BuildDailyLinksContainerFromRssFeeds();
                //SaveNewDailyLinksContainer();
            }
            else
                BuildDailyLinksContainerFromRssFeeds();
        }

        private void BuildDailyLinksContainerFromRssFeeds()
        {
            SetWebDevelopmentLinks();
            SetEntityFrameworkLinks();
            SetVisualStudioLinks();
            SetJavascriptLinks();
            SetCleanCodeLinks();
            SetProductivityLinks();
            SetUnitTestingLinks();
            SetComputerScienceLinks();
            SetFunctionalProgrammingAndFSharpLinks();
            SetComputingTechnologyLinks();
            SetUncleBobLinks();
        }

        private void SetWebDevelopmentLinks()
        {
            using (var rssReader = new RssReader(RssFeeds.WebDevelopment,
                                                 new RssWebCaller(),
                                                 Date))
            {
                var links = rssReader.GetFeed();
                _container.Links.AddRange(links);
            }            
        }

        private void SetEntityFrameworkLinks()
        {
            using (var rssReader = new RssReader(RssFeeds.EntityFramework,
                                                 new RssWebCaller(),
                                                 Date))
            {
                var links = rssReader.GetFeed();
                _container.Links.AddRange(links);
            }            
        }

        private void SetVisualStudioLinks()
        {
            using (var rssReader = new RssReader(RssFeeds.VisualStudio,
                                                 new RssWebCaller(),
                                                 Date))
            {
                var links = rssReader.GetFeed();
                _container.Links.AddRange(links);
            }            
        }

        private void SetJavascriptLinks()
        {
            using (var rssReader = new RssReader(RssFeeds.Javascript,
                                                 new RssWebCaller(),
                                                 Date))
            {
                var links = rssReader.GetFeed();
                _container.Links.AddRange(links);
            }            
        }

        private void SetCleanCodeLinks()
        {
            using (var rssReader = new RssReader(RssFeeds.CleanCode,
                                                 new RssWebCaller(),
                                                 Date))
            {
                var links = rssReader.GetFeed();
                _container.Links.AddRange(links);
            }            
        }

        private void SetProductivityLinks()
        {
            using (var rssReader = new RssReader(RssFeeds.Productivity,
                                                 new RssWebCaller(),
                                                 Date))
            {
                var links = rssReader.GetFeed();
                _container.Links.AddRange(links);
            }            
        }

        private void SetUnitTestingLinks()
        {
            using (var rssReader = new RssReader(RssFeeds.UnitTesting,
                                                 new RssWebCaller(),
                                                 Date))
            {
                var links = rssReader.GetFeed();
                _container.Links.AddRange(links);
            }            
        }

        private void SetComputerScienceLinks()
        {
            using (var rssReader = new RssReader(RssFeeds.ComputerScience,
                                                 new RssWebCaller(),
                                                 Date))
            {
                var links = rssReader.GetFeed();
                _container.Links.AddRange(links);
            }            
        }

        private void SetFunctionalProgrammingAndFSharpLinks()
        {
            using (var rssReader = new RssReader(RssFeeds.FunctionalProgrammingAndFSharp,
                                                 new RssWebCaller(),
                                                 Date))
            {
                var links = rssReader.GetFeed();
                _container.Links.AddRange(links);
            }                 
        }

        private void SetComputingTechnologyLinks()
        {
            using (var rssReader = new RssReader(RssFeeds.ComputingTechnology,
                                                 new RssWebCaller(),
                                                 Date))
            {
                var links = rssReader.GetFeed();
                _container.Links.AddRange(links);
            }              
        }

        private void SetUncleBobLinks()
        {
            using (var rssReader = new RssReader(RssFeeds.UncleBob,
                                                 new RssWebCaller(),
                                                 Date))
            {
                var links = rssReader.GetFeed();
                _container.Links.AddRange(links);
            }            
        }

        private void SaveNewDailyLinksContainer()
        {
            _repository.Add(_container);
        }
    }
}