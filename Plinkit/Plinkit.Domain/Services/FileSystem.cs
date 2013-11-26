using System.IO;
using System.Xml;

namespace Plinkit.Domain.Services
{
    public interface IFileSystem
    {
        void Save(string url, XmlDocument file);
        bool Exists(string filename);
    }
    public class FileSystem : IFileSystem
    {
        public void Save(string filename, XmlDocument file)
        {
            file.Save(filename);
        }

        public bool Exists(string filename)
        {
            return File.Exists(filename);
        }
    }
}