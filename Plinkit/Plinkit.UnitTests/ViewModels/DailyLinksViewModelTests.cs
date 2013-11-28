using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using Plinkit.Domain.Models;
using Plinkit.Domain.Models.Links;
using Plinkit.Domain.Repositories;
using Plinkit.UI.Services;
using Plinkit.UI.ViewModels;

namespace Plinkit.UnitTests.ViewModels
{
    [TestFixture]
    public class DailyLinksViewModelTests
    {
        [Test]
        public void WebDevelopmentLinks_WithGivenInput_ReturnsCorrectResult()
        {
            var readerFactory = new MockReaderFactory<WebDevelopmentLink>();
            var viewModel = new DailyLinksViewModel(GetMockRepository(), DateTime.Now,
                                                    readerFactory.GetMockReader(), new FakeReader(),
                                                    new FakeReader(), new FakeReader(),
                                                    new FakeReader(), new FakeReader(),
                                                    new FakeReader(), new FakeReader(),
                                                    new FakeReader(), new FakeReader(),
                                                    new FakeReader());
            var result = viewModel.WebDevelopmentLinks.ToList();
            Assert.AreEqual(result.Count, 2);
            Assert.AreEqual(result[0].Description, "Link 1");
            Assert.AreEqual(result[1].Description, "Link 2");
        }

        [Test]
        public void EntityFrameworkLinks_WithGivenInput_ReturnsCorrectResult()
        {
            var readerFactory = new MockReaderFactory<EntityFrameworkLink>();
            var viewModel = new DailyLinksViewModel(GetMockRepository(), DateTime.Now,
                                                    new FakeReader(), readerFactory.GetMockReader(),
                                                    new FakeReader(), new FakeReader(),
                                                    new FakeReader(), new FakeReader(),
                                                    new FakeReader(), new FakeReader(),
                                                    new FakeReader(), new FakeReader(),
                                                    new FakeReader());
            var result = viewModel.EntityFrameworkLinks.ToList();
            Assert.AreEqual(result.Count, 2);
            Assert.AreEqual(result[0].Description, "Link 1");
            Assert.AreEqual(result[1].Description, "Link 2");
        }

        [Test]
        public void VisualStudioLink_WithGivenInput_ReturnsCorrectResult()
        {
            var readerFactory = new MockReaderFactory<VisualStudioLink>();
            var viewModel = new DailyLinksViewModel(GetMockRepository(), DateTime.Now,
                                                    new FakeReader(), new FakeReader(),
                                                    readerFactory.GetMockReader(), new FakeReader(),
                                                    new FakeReader(), new FakeReader(),
                                                    new FakeReader(), new FakeReader(),
                                                    new FakeReader(), new FakeReader(),
                                                    new FakeReader());
            var result = viewModel.VisualStudioLinks.ToList();
            Assert.AreEqual(result.Count, 2);
            Assert.AreEqual(result[0].Description, "Link 1");
            Assert.AreEqual(result[1].Description, "Link 2");
        }

        [Test]
        public void JavascriptLink_WithGivenInput_ReturnsCorrectResult()
        {
            var readerFactory = new MockReaderFactory<JavascriptLink>();
            var viewModel = new DailyLinksViewModel(GetMockRepository(), DateTime.Now,
                                                    new FakeReader(), new FakeReader(),
                                                    new FakeReader(), readerFactory.GetMockReader(),
                                                    new FakeReader(), new FakeReader(),
                                                    new FakeReader(), new FakeReader(),
                                                    new FakeReader(), new FakeReader(),
                                                    new FakeReader());
            var result = viewModel.JavascriptLinks.ToList();
            Assert.AreEqual(result.Count, 2);
            Assert.AreEqual(result[0].Description, "Link 1");
            Assert.AreEqual(result[1].Description, "Link 2");
        }

        [Test]
        public void CleanCodeLink_WithGivenInput_ReturnsCorrectResult()
        {
            var readerFactory = new MockReaderFactory<CleanCodeLink>();
            var viewModel = new DailyLinksViewModel(GetMockRepository(), DateTime.Now,
                                                    new FakeReader(), new FakeReader(),
                                                    new FakeReader(), new FakeReader(),
                                                    readerFactory.GetMockReader(), new FakeReader(),
                                                    new FakeReader(), new FakeReader(),
                                                    new FakeReader(), new FakeReader(),
                                                    new FakeReader());
            var result = viewModel.CleanCodeLinks.ToList();
            Assert.AreEqual(result.Count, 2);
            Assert.AreEqual(result[0].Description, "Link 1");
            Assert.AreEqual(result[1].Description, "Link 2");
        }

        [Test]
        public void ProductivityLink_WithGivenInput_ReturnsCorrectResult()
        {
            var readerFactory = new MockReaderFactory<ProductivityLink>();
            var viewModel = new DailyLinksViewModel(GetMockRepository(), DateTime.Now,
                                                    new FakeReader(), new FakeReader(),
                                                    new FakeReader(), new FakeReader(),
                                                    new FakeReader(), readerFactory.GetMockReader(),
                                                    new FakeReader(), new FakeReader(),
                                                    new FakeReader(), new FakeReader(),
                                                    new FakeReader());
            var result = viewModel.ProductivityLinks.ToList();
            Assert.AreEqual(result.Count, 2);
            Assert.AreEqual(result[0].Description, "Link 1");
            Assert.AreEqual(result[1].Description, "Link 2");
        }

        [Test]
        public void UnitTestingLink_WithGivenInput_ReturnsCorrectResult()
        {
            var readerFactory = new MockReaderFactory<UnitTestingLink>();
            var viewModel = new DailyLinksViewModel(GetMockRepository(), DateTime.Now,
                                                    new FakeReader(), new FakeReader(),
                                                    new FakeReader(), new FakeReader(),
                                                    new FakeReader(), new FakeReader(),
                                                    readerFactory.GetMockReader(), new FakeReader(),
                                                    new FakeReader(), new FakeReader(),
                                                    new FakeReader());
            var result = viewModel.UnitTestingLinks.ToList();
            Assert.AreEqual(result.Count, 2);
            Assert.AreEqual(result[0].Description, "Link 1");
            Assert.AreEqual(result[1].Description, "Link 2");
        }

        [Test]
        public void ComputerScienceLink_WithGivenInput_ReturnsCorrectResult()
        {
            var readerFactory = new MockReaderFactory<ComputerScienceLink>();
            var viewModel = new DailyLinksViewModel(GetMockRepository(), DateTime.Now,
                                                    new FakeReader(), new FakeReader(),
                                                    new FakeReader(), new FakeReader(),
                                                    new FakeReader(), new FakeReader(),
                                                    new FakeReader(), readerFactory.GetMockReader(),
                                                    new FakeReader(), new FakeReader(),
                                                    new FakeReader());
            var result = viewModel.ComputerScienceLinks.ToList();
            Assert.AreEqual(result.Count, 2);
            Assert.AreEqual(result[0].Description, "Link 1");
            Assert.AreEqual(result[1].Description, "Link 2");
        }

        [Test]
        public void FunctionalProgrammingAndFSharpLink_WithGivenInput_ReturnsCorrectResult()
        {
            var readerFactory = new MockReaderFactory<FunctionalProgrammingAndFSharpLink>();
            var viewModel = new DailyLinksViewModel(GetMockRepository(), DateTime.Now,
                                                    new FakeReader(), new FakeReader(),
                                                    new FakeReader(), new FakeReader(),
                                                    new FakeReader(), new FakeReader(),
                                                    new FakeReader(), new FakeReader(),
                                                    readerFactory.GetMockReader(), new FakeReader(),
                                                    new FakeReader());
            var result = viewModel.FunctionalProgrammingAndFSharpLinks.ToList();
            Assert.AreEqual(result.Count, 2);
            Assert.AreEqual(result[0].Description, "Link 1");
            Assert.AreEqual(result[1].Description, "Link 2");
        }

        [Test]
        public void ComputingTechnologyLink_WithGivenInput_ReturnsCorrectResult()
        {
            var readerFactory = new MockReaderFactory<ComputingTechnologyLink>();
            var viewModel = new DailyLinksViewModel(GetMockRepository(), DateTime.Now,
                                                    new FakeReader(), new FakeReader(),
                                                    new FakeReader(), new FakeReader(),
                                                    new FakeReader(), new FakeReader(),
                                                    new FakeReader(), new FakeReader(),
                                                    new FakeReader(), readerFactory.GetMockReader(),
                                                    new FakeReader());
            var result = viewModel.ComputingTechnologyLinks.ToList();
            Assert.AreEqual(result.Count, 2);
            Assert.AreEqual(result[0].Description, "Link 1");
            Assert.AreEqual(result[1].Description, "Link 2");
        }

        [Test]
        public void UncleBobLink_WithGivenInput_ReturnsCorrectResult()
        {
            var readerFactory = new MockReaderFactory<UncleBobLink>();
            var viewModel = new DailyLinksViewModel(GetMockRepository(), DateTime.Now,
                                                    new FakeReader(), new FakeReader(),
                                                    new FakeReader(), new FakeReader(),
                                                    new FakeReader(), new FakeReader(),
                                                    new FakeReader(), new FakeReader(),
                                                    new FakeReader(), new FakeReader(),
                                                    readerFactory.GetMockReader());
            var result = viewModel.UncleBobLinks.ToList();
            Assert.AreEqual(result.Count, 3);
            Assert.AreEqual(result[0].Description, "Link 1");
            Assert.AreEqual(result[1].Description, "Link 2");
            Assert.AreEqual(result[2].Title, "Uncle Bob Blog Archive");
        }

        [Test]
        public void GetCategoryLinkClass_ForSelectedCategory_ReturnsCorrectStyle()
        {
            var viewModel = new DailyLinksViewModel {SelectedCategory = " wEBDevelopment  "};
            var result = viewModel.GetCategoryLinkClass("webDEVELOPment ");
            Assert.AreEqual(result, "active");
        }

        [Test]
        public void GetCategoryLinkClass_ForUnSelectedCategory_ReturnsCorrectStyle()
        {
            var viewModel = new DailyLinksViewModel { SelectedCategory = " wEBDevelopment  " };
            var result = viewModel.GetCategoryLinkClass("aDifferentCategory");
            Assert.AreEqual(result, "");
        }

        private IRepository<DailyLinksContainer> GetMockRepository()
        {
            var repository = new Mock<IRepository<DailyLinksContainer>>();
            return repository.Object;
        }
    }

    class FakeReader : IRssReader
    {
        public string Url { get; set; }
        public IEnumerable<DailyLink> RssItems { get { return new List<DailyLink>(); } }
        public string FeedTitle { get { return "Test Feed Title"; } }
        public string FeedDescription { get { return "Test Feed Description"; } }
        public IEnumerable<DailyLink> GetFeed()
        {
            return new List<DailyLink>();
        }
        public void Dispose(){ }
    }

    class TestLink : DailyLink { }
    
    class MockReaderFactory<T> where T : DailyLink
    {
        public IRssReader GetMockReader()
        {
            var reader = new Mock<IRssReader>();
            reader.Setup(r => r.GetFeed()).Returns(BuildFakeLinks());
            return reader.Object;
        }

        private IEnumerable<T> BuildFakeLinks()
        {
            var link1 = Activator.CreateInstance<T>();
            link1.Description = "Link 1";
            var link2 = Activator.CreateInstance<T>();
            link2.Description = "Link 2";
            return new List<T>
                {
                   link1,
                   link2,
                };
        }
    }
}
