using EPiServer.Commerce.Catalog;

namespace Foundation.Features.Home
{
    public class HomeController : PageController<HomePage>
    {
        private readonly IEntryInformation _entryInformation;

        public HomeController(IEntryInformation entryInformation)
        {
            _entryInformation = entryInformation;
        }

        public ActionResult Index(HomePage currentContent) => View(ContentViewModel.Create<HomePage>(currentContent));
    }
}