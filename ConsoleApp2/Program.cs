using System;

namespace GenericFactory
{
    class Program
    {
        static void Main(string[] args)
        {
            var internalDownloadLink = LinkFactory.CreateLink<Internal>();
            var externallDownloadLink = LinkFactory.CreateLink<External>();
            var internalLink = internalDownloadLink.ModelForLink();
            Console.WriteLine(internalLink.Type);
            Console.ReadKey();
        }
    }

    public abstract class LinkFactory
    {
        public static T CreateLink<T>() where T : ILink, new()
        {
            return new T();
        }
    }

    public interface ILink
    {
         TableDownloadItemModel ModelForLink();
    }

    public class Internal : ILink
    {
        public TableDownloadItemModel ModelForLink() => new TableDownloadItemModel();
    }

    public class External : ILink
    {
        public TableDownloadItemModel ModelForLink()
            => new TableDownloadItemModel(){Type = "Externall"};
    }


    public class TableDownloadItemModel
    {
        public string Type { get; set; } = "Internal";

        public string Description { get; set; } = "New Desription";

        public int Size { get; set; } = 20;

        public string Icon { get; set; } = "PDF";
    }
}
