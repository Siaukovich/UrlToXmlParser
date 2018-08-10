namespace UriStringToXml.Console
{
    using DataConverter.Base;
    using DependencyResolver;
    using Ninject;

    class Program
    {
        /// <summary>
        /// Entry point.
        /// </summary>
        private static void Main()
        {
            using (IKernel kernel = new StandardKernel())
            {
                kernel.ResolveDependencies();

                var service = kernel.Get<IParserService<string, Url>>();

                service.Parse();
            }
        }
    }
}
