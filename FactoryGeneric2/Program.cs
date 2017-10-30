using System;
using System.Reflection.Metadata.Ecma335;

namespace FactoryGeneric2
{
    class Program
    {
        static void Main(string[] args)
        {
            var f = new Factory();  // factory produces animals
            var a = f.CreateLink();
            f.Produces<Internal>();     // from now on factory produces birds
            var b = f.CreateLink();
            Console.WriteLine(b.Type);
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
