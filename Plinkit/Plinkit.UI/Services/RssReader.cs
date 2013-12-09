using System;
using System.Collections.Generic;
using System.Web;
using System.Xml;
using System.Text;
using Plinkit.Domain.Configuration;
using Plinkit.Domain.Models.Links;
using Plinkit.Domain.Services;
using Plinkit.UI.Factories;

namespace Plinkit.UI.Services
{
    public interface IRssReader : IDisposable
    {
        string Url { get; set; }        
        IEnumerable<DailyLink> RssItems { get; }
        string FeedTitle { get; }
        string FeedDescription { get; }
        IEnumerable<DailyLink> GetFeed();
    }

    [Serializable]
    public class RssReader : IRssReader
    {
        private DateTime _date;
        private string _url;
        private string _feedTitle;
        private string _feedDescription;
        private readonly List<DailyLink> _rssItems = new List<DailyLink>();        
        private readonly IWebCaller _webCaller;
        private IFileSystem _fileSystem;
        private bool _isDisposed;

        public RssReader()
        {
            _url = string.Empty;
        }

        public RssReader(string feedUrl, 
                         IWebCaller webCaller,
                         DateTime date)
        {
            _date = date;
            _url = feedUrl;
            _webCaller = webCaller;
            _fileSystem = new FileSystem();
        }

        public RssReader(string feedUrl,
                         IWebCaller webCaller,
                         IFileSystem fileSystem)
        {
            _url = feedUrl;
            _webCaller = webCaller;
            _fileSystem = fileSystem;
        }

        public string Url
        {
            get { return _url; }
            set { _url = value; }
        }

        public IEnumerable<DailyLink> RssItems
        {
            get { return _rssItems; }
        }
      
        public string FeedTitle
        {
            get { return _feedTitle; }
        }
        
        public string FeedDescription
        {
            get { return _feedDescription; }
        }

        public IEnumerable<DailyLink> GetFeed()
        {      
            if (String.IsNullOrEmpty(Url))        
                throw new ArgumentException("You must provide a feed URL");
           
            var xmlDocument = GetRssXmlDocument();
            ParseDocElements(xmlDocument.SelectSingleNode("//channel"), "title", ref _feedTitle);
            ParseDocElements(xmlDocument.SelectSingleNode("//channel"), "description", ref _feedDescription);
            ParseRssItems(xmlDocument);      
            return _rssItems;     
        }

        private XmlDocument GetRssXmlDocument()
        {            
            var filename = BuildFileName(Url);
            var xmlDocument = (!_fileSystem.Exists(filename) && _date == DateTime.Now.Date)
                ? GetXmlFromWeb() 
                : GetXmlFromSavedFile();
            return xmlDocument;
        }

        private XmlDocument GetXmlFromWeb()
        {
            string xmlStr;
            using (_webCaller)
            {
                xmlStr = _webCaller.GetRssXml(_url);
            }
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlStr);
            _fileSystem.Save(BuildFileName(Url), xmlDoc);
            return xmlDoc;
        }

        private XmlDocument GetXmlFromSavedFile()
        {
            var xmlDoc = new XmlDocument();
            var fileName = BuildFileName(Url);
            if (_fileSystem.Exists(fileName))
                xmlDoc.Load(fileName);            
            return xmlDoc;
        }

        private string BuildFileName(string url)
        {
            var categoryId = RssFeeds.GetCategoryIdByFeedUrl(url);
            var dateString = _date.ToString("ddMMyyyy");
            return string.Format("{0}{1}_{2}.xml",
                                 HttpContext.Current.Server.MapPath("~/DailyLinksXml/"),
                                 categoryId,
                                 dateString);
        }

        private void ParseRssItems(XmlDocument xmlDoc)
        {
            _rssItems.Clear();
            var nodes = xmlDoc.SelectNodes("rss/channel/item");
            foreach (XmlNode node in nodes)
            {
                string title = "", description = "", link = "";
                ParseDocElements(node, "title", ref title);
                ParseDocElements(node, "description", ref description);
                ParseDocElements(node, "link", ref link);
                var item = DailyLinkFactory.BuildDailyLink(Url);
                item.Title = title.Replace("</b>", "").Replace("<b>", "");
                var isTitleAcii = IsAscii(item.Title);
                item.Description = description
                    .Replace("</em>", "").Replace("<em>", "")
                    .Replace("</b>", "").Replace("<b>", "");
                item.Link = link;
                item.Date = DateTime.Now;
                if (isTitleAcii)
                    _rssItems.Add(item);
            }
        }

        private bool IsAscii(string value)
        {
            return Encoding.UTF8.GetByteCount(value) == value.Length;
        }

        private void ParseDocElements(XmlNode parent, string xPath, ref string property)
        {
            if (parent == null)
                return;
            XmlNode node = parent.SelectSingleNode(xPath);
            if (node != null)
                property = node.InnerText;
            else
                property = "Unresolvable";
        }  

        private void Dispose(bool disposing)
        {
            if (disposing && !_isDisposed)
            {
                _rssItems.Clear();
                _url = null;
                _feedTitle = null;
                _feedDescription = null;
                _fileSystem = null;
            }

            _isDisposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}