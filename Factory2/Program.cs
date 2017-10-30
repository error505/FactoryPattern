using System;

namespace Factory2
{
    class Program
    {
        static void Main(string[] args)
        {
            var internalDownloadLink = LinkFactory.CreateLink<Internal>();
            var externallDownloadLink = LinkFactory.CreateLink<External>();
            var tableDownInt = new TableDownloadItemModel();
            var internalLink = internalDownloadLink.ModelForLink(tableDownInt);
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
        TableDownloadItemModel ModelForLink(TableDownloadItemModel model);
    }

    public class Internal : ILink
    {
        public TableDownloadItemModel ModelForLink(TableDownloadItemModel tblDownload)
        {
            var tableDownInt = new TableDownloadItemModel();
            var tableExt = new TableDownloadItemModel { Type = "External" };

            return !string.IsNullOrEmpty(tblDownload.Type) && tblDownload.Type == "Internal" ? tableDownInt : tableExt;
        }
    }

    public class External : ILink
    {
        public TableDownloadItemModel ModelForLink(TableDownloadItemModel tblDownload)
            => new TableDownloadItemModel { Type = "Externall" };
    }


    public class TableDownloadItemModel
    {
        public string Type { get; set; } = "Internal";

        public string Description { get; set; } = "New Desription";

        public int Size { get; set; } = 20;

        public string Icon { get; set; } = "PDF";
    }
}
