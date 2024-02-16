using EPiServer.Commerce.Catalog;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using Microsoft.Extensions.DependencyInjection;

namespace Foundation.Infrastructure
{
    [ModuleDependency(typeof(EPiServer.Commerce.Initialization.InitializationModule))]
    public class CustomEntryInformationInitializer : IConfigurableModule
    {
        public void Initialize(InitializationEngine context) {}

        public void Uninitialize(InitializationEngine context) {}

        public void ConfigureContainer(ServiceConfigurationContext context)
        {
            context.Services.Intercept<IEntryInformation>(
                (locator, defaultEntryInformation) => new CustomEntryInformation(defaultEntryInformation));
        }
    }
}
