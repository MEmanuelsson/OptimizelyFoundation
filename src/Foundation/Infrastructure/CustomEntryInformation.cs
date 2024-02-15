using EPiServer.Commerce.Catalog;
using EPiServer.Commerce.Catalog.Linking;

namespace Foundation.Infrastructure
{
    public class CustomEntryInformation : IEntryInformation
    {
        IRelationRepository _relationRepository = ServiceLocator.Current.GetInstance<IRelationRepository>();
        IUrlResolver _urlResolver = ServiceLocator.Current.GetInstance<IUrlResolver>();

        //IEntryInformation _defaultImplementation;
        //public CustomEntryInformation(IEntryInformation defaultImplementation)
        //{
        //    _defaultImplementation = defaultImplementation;
        //}

        public IDictionary<string, string> GetCustomProperties(EntryContentBase entry)
        {
            var myVariant = entry as MyVariant;
            //if (myVariant == null)
            //{
            //    return _defaultImplementation.GetCustomProperties(entry);
            //}

            return new Dictionary<string, string>() {
                { nameof(myVariant.SizeNew), myVariant.SizeNew.ToString() },
                { nameof(myVariant.ColorNew), myVariant.ColorNew } };
        }

        public string GetProductUrl(EntryContentBase entry)
        {
            var productLink = entry is VariationContent ?
                entry.GetParentProducts(_relationRepository).FirstOrDefault() : entry.ContentLink;
            if (productLink == null)
            {
                return string.Empty;
            }

            var urlBuilder = new UrlBuilder(_urlResolver.GetUrl(productLink));
            if (entry.Code != null)
            {
                urlBuilder.QueryCollection.Add("variationCode", entry.Code);
            }

            return urlBuilder.ToString();
        }
    }

    public class MyVariant : VariationContent
    {
        public virtual int SizeNew { get; set; }
        public virtual string ColorNew { get; set; }
        public virtual int IntegrationCodeNew { get; set; }
    }
}
