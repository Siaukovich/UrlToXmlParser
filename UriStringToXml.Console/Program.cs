namespace UriStringToXml.Console
{
    using Ninject;

    using UrlToXml;
    using UrlToXml.Interfaces;

    class Program
    {
        /// <summary>
        /// Entry point.
        /// </summary>
        private static void Main()
        {
            using (IKernel kernel = new StandardKernel())
            {
                SetDependencies(kernel);

                kernel.Get<IParserSevice<string, Url>>();
            }
        }

        /// <summary>
        /// Sets dependencies using Ninject.
        /// </summary>
        /// <param name="kernel">
        /// Ninject's kernel object.
        /// </param>
        private static void SetDependencies(IKernel kernel)
        {
            kernel.Bind<IDataProvider<string>>()
                  .To<FileDataProvider>();

            kernel.Bind<IDataConsumer<Url>>()
                  .To<XmlDataConsumer>();

            kernel.Bind<IDataParser<string, Url>>()
                  .To<UrlDataParser>();

            var validators = new ISingleDataValidator<string>[] { new UrlSingleValidator() };
            kernel.Bind<IGroupDataValidator<string>>()
                  .To<UrlGroupValidator>()
                  .WithConstructorArgument("validators", validators);

            kernel.Bind<IMapper<string, Url>>()
                  .To<StringToUrlMapper>();

            kernel.Bind<IParserSevice<string, Url>>()
                  .To<ParserService<string, Url>>();

            kernel.Bind<ILogger>()
                  .To<NLogLogger>()
                  .InSingletonScope();
        }
    }
}
