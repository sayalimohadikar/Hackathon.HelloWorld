using Atlas.WebService;

namespace HelloWorld.SimpleWebsite
{
    /// <summary>
    /// Entry point class
    /// </summary>
    public class Program
    {
        /// Entry point method
        public static void Main(string[] args)
        {
            new SimpleWebsiteService().Run(args);
        }
    }
}
