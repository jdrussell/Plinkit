using System;
using System.Collections.Generic;
using System.Net;
using System.Xml;
using Plinkit.Domain.Models.Links;
using Plinkit.UI.Factories;

namespace Plinkit.UI.Services
{
    [Serializable]
    public class RssReader : IDisposable
    {       
        private string _url;
        private string _feedTitle;
        private string _feedDescription;
        private List<DailyLink> _rssItems = new List<DailyLink>();
        private bool _IsDisposed;        

        public RssReader()
        {
            _url = string.Empty;
        }
    
        public RssReader(string feedUrl)
        {
            _url = feedUrl;
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
                
            string xmlStr;
            var wc = new WebClient();
            //var cred = new NetworkCredential("HYMANS\\jrussell", "*&er1n6!");
            //var p = new WebProxy("10.122.10.33:80", true, null, cred);
            //WebRequest.DefaultWebProxy = p;
            //wc.Proxy = p;
            using (wc)
            {
                xmlStr = wc.DownloadString(_url);
            }
            var xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlStr);
            ParseDocElements(xmlDoc.SelectSingleNode("//channel"), "title", ref _feedTitle);
            ParseDocElements(xmlDoc.SelectSingleNode("//channel"), "description", ref _feedDescription);
            ParseRssItems(xmlDoc);      
            return _rssItems;     
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
                item.Title = title.Replace("</b>","").Replace("<b>","");
                item.Description = description
                    .Replace("</em>", "").Replace("<em>", "")
                    .Replace("</b>", "").Replace("<b>", ""); 
                item.Link = link;
                item.Date = DateTime.Now;
                _rssItems.Add(item);
            }
        }

        private void ParseDocElements(XmlNode parent, string xPath, ref string property)
        {
            XmlNode node = parent.SelectSingleNode(xPath);
            if (node != null)
                property = node.InnerText;
            else
                property = "Unresolvable";
        }  

        private void Dispose(bool disposing)
        {
            if (disposing && !_IsDisposed)
            {
                _rssItems.Clear();
                _url = null;
                _feedTitle = null;
                _feedDescription = null;
            }

            _IsDisposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}