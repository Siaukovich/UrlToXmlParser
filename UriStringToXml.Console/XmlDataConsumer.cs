namespace UriStringToXml.Console
{
    using System;
    using System.Collections.Generic;
    using System.Xml.Linq;

    using UrlToXml.Interfaces;

    /// <summary>
    /// Converts passed data to.
    /// </summary>
    public class XmlDataConsumer : IDataConsumer<Url>
    {
        public void Consume(IEnumerable<Url> data, string destination)
        {
            var rootElement = new XElement("urlAddresses");

            foreach (Url url in data)
            {
                XElement hostName = GetHostNameXElement(url);
                XElement uriXElement = GetUriSegmentsXElement(url);
                XElement parametersXElement = GetParametersXElement(url);

                XElement urlAddress = ComposeUrlAddressXElement(hostName, uriXElement, parametersXElement);

                rootElement.Add(urlAddress);
            }

            rootElement.Save(destination);
        }

        private static XElement ComposeUrlAddressXElement(XElement hostName, XElement uriXElement, XElement parametersXElement)
        {
            return new XElement("urlAdress",
                                hostName,
                                uriXElement,
                                parametersXElement);
        }

        private XElement GetHostNameXElement(Url url)
        {
            return new XElement("host", new XAttribute("name", url.Host));
        }

        private static XElement GetUriSegmentsXElement(Url url)
        {
            string[] uriSegements = url.UrlPath.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries);
            var uriXElement = new XElement("uri");
            foreach (string uriSegement in uriSegements)
            {
                uriXElement.Add(new XElement("segment", uriSegement));
            }

            return uriXElement;
        }

        private static XElement GetParametersXElement(Url url)
        {
            var parametersXElement = new XElement("parameters");

            if (url.Parameters.Count == 0)
            {
                return null;
            }

            foreach ((string key, string value) parameterPair in url.Parameters)
            {
                parametersXElement.Add(new XElement("parameter", new XAttribute("key", parameterPair.key),
                    new XAttribute("value", parameterPair.value)));
            }

            return parametersXElement;
        }
    }
}