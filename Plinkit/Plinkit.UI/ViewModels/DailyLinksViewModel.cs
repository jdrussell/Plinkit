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
        private IRssReader _webDevelopmentReader;
        private IRssReader _entityFrameworkReader;
        private IRssReader _visualStudioReader;
        private IRssReader _javascriptReader;
        private IRssReader _cleanCodeReader;
        private IRssReader _productivityReader;
        private IRssReader _unitTestingReader;
        private IRssReader _computerScienceReader;
        private IRssReader _functionalProgrammingReader;
        private IRssReader _computingTechnologyReader;
        private IRssReader _uncleBobReader;

        public string SelectedCategory = "webDevelopment";
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

        public string GetCategoryLinkClass(string comparsionLink)
        {
            if (comparsionLink.Trim().ToUpper() == SelectedCategory.Trim().ToUpper())
                return "active";
            return "";
        }

        #region Unit test-focussed constructor
        public DailyLinksViewModel(IRepository<DailyLinksContainer> repository, DateTime date,
                                   IRssReader webDevelopmentReader,
                                   IRssReader entityFrameworkReader, IRssReader visualStudioReader,
                                   IRssReader javascriptReader, IRssReader cleanCodeReader,
                                   IRssReader productivityReader, IRssReader unitTestingReader,
                                   IRssReader computerScienceReader, IRssReader functionalProgrammingReader,
                                   IRssReader computingTechnologyReader, IRssReader uncleBobReader)
        {
            Date = date;
            _repository = repository;
            _webDevelopmentReader = webDevelopmentReader;
            _entityFrameworkReader = entityFrameworkReader;
            _visualStudioReader = visualStudioReader;
            _javascriptReader = javascriptReader;
            _cleanCodeReader = cleanCodeReader;
            _productivityReader = productivityReader;
            _unitTestingReader = unitTestingReader;
            _computerScienceReader = computerScienceReader;
            _functionalProgrammingReader = functionalProgrammingReader;
            _computingTechnologyReader = computingTechnologyReader;
            _uncleBobReader = uncleBobReader;
            SetupData();
        }
        #endregion

        public DailyLinksViewModel(IRepository<DailyLinksContainer> repository, DateTime date)
        {
            Date = date;
            _repository = repository;
            SetupRssReaders();
            SetupData();
        }

        public DailyLinksViewModel(IRepository<DailyLinksContainer> repository, 
                                   DateTime date,
                                   string selectedCategory)
        {                  
            _repository = repository;
            Date = date;  
            SelectedCategory = selectedCategory;                
            SetupRssReaders();
            SetupData();
        }

        private void SetupRssReaders()
        {
            _webDevelopmentReader = new RssReader(RssFeeds.WebDevelopment,
                                                  new RssWebCaller(),
                                                  Date);
            _entityFrameworkReader = new RssReader(RssFeeds.EntityFramework,
                                                   new RssWebCaller(),
                                                   Date);
            _visualStudioReader = new RssReader(RssFeeds.VisualStudio,
                                                new RssWebCaller(),
                                                Date);
            _javascriptReader = new RssReader(RssFeeds.Javascript,
                                              new RssWebCaller(),
                                              Date);
            _cleanCodeReader = new RssReader(RssFeeds.CleanCode,
                                             new RssWebCaller(),
                                             Date);
            _productivityReader = new RssReader(RssFeeds.Productivity,
                                                new RssWebCaller(),
                                                Date);
            _unitTestingReader = new RssReader(RssFeeds.UnitTesting,
                                               new RssWebCaller(),
                                               Date);
            _computerScienceReader = new RssReader(RssFeeds.ComputerScience,
                                                   new RssWebCaller(),
                                                   Date);
            _functionalProgrammingReader = new RssReader(RssFeeds.FunctionalProgrammingAndFSharp,
                                                         new RssWebCaller(),
                                                         Date);
            _computingTechnologyReader = new RssReader(RssFeeds.ComputingTechnology,
                                                       new RssWebCaller(),
                                                       Date);
            _uncleBobReader = new RssReader(RssFeeds.UncleBob,
                                            new RssWebCaller(),
                                            Date);
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
            using (_webDevelopmentReader)
            {
                var links = _webDevelopmentReader.GetFeed();
                _container.Links.AddRange(links);
            }            
        }

        private void SetEntityFrameworkLinks()
        {
            using (_entityFrameworkReader)
            {
                var links = _entityFrameworkReader.GetFeed();
                _container.Links.AddRange(links);
            }            
        }

        private void SetVisualStudioLinks()
        {
            using (_visualStudioReader)
            {
                var links = _visualStudioReader.GetFeed();
                _container.Links.AddRange(links);
            }            
        }

        private void SetJavascriptLinks()
        {
            using (_javascriptReader)
            {
                var links = _javascriptReader.GetFeed();
                _container.Links.AddRange(links);
            }            
        }

        private void SetCleanCodeLinks()
        {
            using (_cleanCodeReader)
            {
                var links = _cleanCodeReader.GetFeed();
                _container.Links.AddRange(links);
            }            
        }

        private void SetProductivityLinks()
        {
            using (_productivityReader)
            {
                var links = _productivityReader.GetFeed();
                _container.Links.AddRange(links);
            }            
        }

        private void SetUnitTestingLinks()
        {
            using (_unitTestingReader)
            {
                var links = _unitTestingReader.GetFeed();
                _container.Links.AddRange(links);
            }            
        }

        private void SetComputerScienceLinks()
        {
            using (_computerScienceReader)
            {
                var links = _computerScienceReader.GetFeed();
                _container.Links.AddRange(links);
            }            
        }

        private void SetFunctionalProgrammingAndFSharpLinks()
        {
            using (_functionalProgrammingReader)
            {
                var links = _functionalProgrammingReader.GetFeed();
                _container.Links.AddRange(links);
            }                 
        }

        private void SetComputingTechnologyLinks()
        {
            using (_computingTechnologyReader)
            {
                var links = _computingTechnologyReader.GetFeed();
                _container.Links.AddRange(links);
            }              
        }

        private void SetUncleBobLinks()
        {
            using (_uncleBobReader)
            {
                var links = _uncleBobReader.GetFeed();
                _container.Links.AddRange(links);
            }            
        }

        private void SaveNewDailyLinksContainer()
        {
            _repository.Add(_container);
        }
    }
}