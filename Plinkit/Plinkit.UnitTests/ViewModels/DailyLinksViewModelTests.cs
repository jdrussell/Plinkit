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
            var viewModel = new DailyLinksViewModel(GetMockRepository(), DateTime.Now,
                                                    GetMockWebDevelopmentReader(), new FakeReader(),
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
            var viewModel = new DailyLinksViewModel(GetMockRepository(), DateTime.Now,
                                                    new FakeReader(), GetMockEntityFrameworkReader(),
                                                    new FakeReader(), new FakeReader(),
                                                    new FakeReader(), new FakeReader(),
                                                    new FakeReader(), new FakeReader(),
                                                    new FakeReader(), new FakeReader(),
                                                    new FakeReader());
            var result = viewModel.EntityFrameworkLinks.ToList();
            Assert.AreEqual(result.Count, 2);
            Assert.AreEqual(result[0].Description, "Link 3");
            Assert.AreEqual(result[1].Description, "Link 4");
        }

        private IRssReader GetMockWebDevelopmentReader()
        {
            var reader = new Mock<IRssReader>();
            reader.Setup(r => r.GetFeed()).Returns(new List<DailyLink>
                {
                    new WebDevelopmentLink {Description = "Link 1"},
                    new WebDevelopmentLink {Description = "Link 2"},
                });
            return reader.Object;
        }

        private IRssReader GetMockEntityFrameworkReader()
        {
            var reader = new Mock<IRssReader>();
            reader.Setup(r => r.GetFeed()).Returns(new List<DailyLink>
                {
                    new EntityFrameworkLink {Description = "Link 3"},
                    new EntityFrameworkLink {Description = "Link 4"},
                });
            return reader.Object;
        }

        private IRssReader GetMockReader()
        {
            var reader = new Mock<IRssReader>();
            reader.Setup(r => r.GetFeed()).Returns(new List<DailyLink>
                {
                    new WebDevelopmentLink {Description = "Link 1"},
                    new WebDevelopmentLink {Description = "Link 2"},
                });
            return reader.Object;
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
}
