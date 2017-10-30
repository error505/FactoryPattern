// Abstract Factory pattern

using System;

namespace AbstractFactory
{
    /// <summary> 
    /// MainApp startup class for Real-World 
    /// Abstract Factory Design Pattern. 
    /// </summary> 
    class Program
    {
        /// <summary> 
        /// Entry point into console application. 
        /// </summary> 
        public static void Main()
        {
            
            LinkFactory factory = new LinkCreationFactory();
            var world = new LinkWorld(factory);
            world.RunLinkCreation();
            Console.ReadKey();
        }
    }
    /// <summary> 
    /// The 'AbstractFactory' abstract class 
    /// </summary> 
    abstract class LinkFactory
    {
        public abstract InternalLink CreateInternalLink();
        public abstract ExternalLink CreateExternalLink();
    }

    /// <summary> 
    /// The 'ConcreteFactory1' class 
    /// </summary> 
    class LinkCreationFactory : LinkFactory
    {
        public override InternalLink CreateInternalLink()
        {
            return new InternalDownload();
        }
        public override ExternalLink CreateExternalLink()
        {
            return new ExternalDownload();
        }
    }

    /// <summary> 
    /// The 'AbstractProductA' abstract class 
    /// </summary> 
    abstract class InternalLink
    {
    }
    /// <summary> 
    /// The 'AbstractProductB' abstract class 
    /// </summary> 
    abstract class ExternalLink
    {
        public abstract void Create(InternalLink h);
    } /// <summary> 
      /// The 'ProductA1' class 
      /// </summary> 
    class InternalDownload : InternalLink
    {
    }
    /// <summary> 
    /// The 'ProductB1' class 
    /// </summary> 
    class ExternalDownload : ExternalLink
    {
        public override void Create(InternalLink h)
        { 
            Console.WriteLine(this.GetType().Name + " Uses " + h.GetType().Name);
        }
    }

    /// <summary> 
    /// The 'Client' class 
    /// </summary> 
    class LinkWorld
    {
        private InternalLink _internalLink; private ExternalLink _externalLink;
        // Constructor 
        public LinkWorld(LinkFactory factory)
        {
            _externalLink = factory.CreateExternalLink();
            _internalLink = factory.CreateInternalLink();
        }
        public void RunLinkCreation()
        {
            _externalLink.Create(_internalLink);
        }
    }
}