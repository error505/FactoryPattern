using System;
using System.Reflection.Metadata.Ecma335;

namespace FactoryGeneric2
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new Factory();
            var create = factory.CreateLink();
            factory.Produces<Internal>();     
            var createLink = factory.CreateLink();
            Console.WriteLine(createLink.Type);
            Console.ReadKey();
        }
    }
    public class Factory
    {
        private Type _outputType = typeof(Link);

        public void Produces<T>() where T : Link, new()
        {
            _outputType = typeof(T);
        }

        public Link CreateLink()
        {
            return (Link)Activator.CreateInstance(_outputType);
        }
    }

    public class Link
    {
        public virtual string Type { get; set; }
        public string Url { get; set; }
    }

    public class Internal : Link
    {
        public override string Type { get; set; } = "Internal";
        public string Path { get; set; }
    }

    public class External : Link
    {
        public override string Type { get; set; } = "External";
        public string HttpUrl { get; set; }
    }
}
