using Atlas.Authentication;
using Atlas.WebService;

namespace HelloWorld.SimpleWebsite
{
    /// <inheritdoc />
    public class SimpleWebsiteService : AtlasService
    {
	    /// <inheritdoc />
        public override string ServiceName { get; } = "SimpleWebsite";
    }
}
