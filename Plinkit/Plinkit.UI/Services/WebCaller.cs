using System;
using System.Net;

namespace Plinkit.UI.Services
{
    public interface IWebCaller : IDisposable
    {
        string GetRssXml(string url);
    }

    public class RssWebCaller : IWebCaller
    {
        private bool _disposed;

        public string GetRssXml(string url)
        {
            string result = "";
            var wc = new WebClient();
            using (wc)
            {
                result = wc.DownloadString(url);
            }
            return result;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~RssWebCaller()
        {
            Dispose(false);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;
            _disposed = true;
        }
    }
}