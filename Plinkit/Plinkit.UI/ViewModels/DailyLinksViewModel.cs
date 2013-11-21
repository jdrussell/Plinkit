using System;
using System.Collections.Generic;
using System.Linq;
using Plinkit.Domain.Models;
using Plinkit.Domain.Models.Links;
using Plinkit.Domain.Repositories;
using Plinkit.UI.Configuration;
using Plinkit.UI.Services;

namespace Plinkit.UI.ViewModels
{
    public class DailyLinksViewModel
    {
        private readonly DateTime _date;
        private readonly RssReader _webDevelopmentRssReader = new RssReader(RssFeeds.WebDevelopment);
        private readonly RssReader _entityFrameworkRssReader = new RssReader(RssFeeds.EntityFramework);        
        private readonly RssReader _visualStudioRssReader = new RssReader(RssFeeds.VisualStudio);
        private readonly RssReader _javascriptRssReader = new RssReader(RssFeeds.Javascript);
        private readonly RssReader _cleanCodeRssReader = new RssReader(RssFeeds.CleanCode);
        private readonly RssReader _productivityRssReader = new RssReader(RssFeeds.Productivity);
        private readonly RssReader _unitTestingRssReader = new RssReader(RssFeeds.UnitTesting);
        private readonly RssReader _computerScienceRssReader = new RssReader(RssFeeds.ComputerScience);
        private readonly RssReader _functionalProgrammingRssReader = new RssReader(RssFeeds.FunctionalProgrammingAndFSharp);
        private readonly RssReader _computingTechnologyRssReader = new RssReader(RssFeeds.ComputingTechnology);
        private readonly RssReader _uncleBobRssReader = new RssReader(RssFeeds.UncleBob);

        private readonly IRepository<DailyLinksContainer> _repository;
        private DailyLinksContainer _container;
        private bool _persistNewLinksCollection;

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
            _date = date;
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
            //_container = _repository.GetByDate(_date);
            if (_container == null)
            {
                _container = new DailyLinksContainer
                    {
                        Date = _date,
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
            _container.Links.AddRange(_webDevelopmentRssReader.GetFeed());
        }

        private void SetEntityFrameworkLinks()
        {
            _container.Links.AddRange(_entityFrameworkRssReader.GetFeed());
        }

        private void SetVisualStudioLinks()
        {
            _container.Links.AddRange(_visualStudioRssReader.GetFeed());
        }

        private void SetJavascriptLinks()
        {
            _container.Links.AddRange(_javascriptRssReader.GetFeed());
        }

        private void SetCleanCodeLinks()
        {
            _container.Links.AddRange(_cleanCodeRssReader.GetFeed());
        }

        private void SetProductivityLinks()
        {
            _container.Links.AddRange(_productivityRssReader.GetFeed());
        }

        private void SetUnitTestingLinks()
        {
            _container.Links.AddRange(_unitTestingRssReader.GetFeed());
        }

        private void SetComputerScienceLinks()
        {
            _container.Links.AddRange(_computerScienceRssReader.GetFeed());
        }

        private void SetFunctionalProgrammingAndFSharpLinks()
        {
            _container.Links.AddRange(_functionalProgrammingRssReader.GetFeed());
        }

        private void SetComputingTechnologyLinks()
        {
            _container.Links.AddRange(_computingTechnologyRssReader.GetFeed());
        }

        private void SetUncleBobLinks()
        {
            _container.Links.AddRange(_uncleBobRssReader.GetFeed());
        }

        private void SaveNewDailyLinksContainer()
        {
            _repository.Add(_container);
        }
    }
}