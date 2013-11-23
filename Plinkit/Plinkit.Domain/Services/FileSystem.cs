using System.Xml;

namespace Plinkit.Domain.Services
{
    public interface IFileSystem
    {
        void Save(string url, XmlDocument file);
    }
    public class FileSystem : IFileSystem
    {
        public void Save(string filename, XmlDocument file)
        {
            file.Save(filename);
        }
    }
}