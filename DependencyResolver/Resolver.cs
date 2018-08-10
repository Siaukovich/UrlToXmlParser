namespace DependencyResolver
{
    using DataConverter.Base;
    using Logger.Base;
    using Ninject;
    using UriStringToXml;
    using UrlToXml;

    public static class Resolver
    {
        public static void ResolveDependencies(this IKernel kernel)
        {
            kernel.Bind<IDataProvider<string>>()
                  .To<FileDataProvider>();

            kernel.Bind<IDataConsumer<Url>>()
                  .To<XmlDataConsumer>();

            kernel.Bind<IDataParser<string, Url>>()
                  .To<UrlDataParser>();

            ISingleDataValidator<string>[] validators = { new UrlSingleValidator() };
            kernel.Bind<IGroupDataValidator<string>>()
                  .To<UrlGroupValidator>()
                  .WithConstructorArgument("validators", validators);

            kernel.Bind<IMapper<string, Url>>()
                  .To<StringToUrlMapper>();

            kernel.Bind<IParserService<string, Url>>()
                  .To<ParserService<string, Url>>();

            kernel.Bind<ILogger>()
                  .To<NLogLogger>()
                  .InSingletonScope();
        }
    }
}
