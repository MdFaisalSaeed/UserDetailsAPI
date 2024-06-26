
namespace UserDetails
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var startup = new Startup();
            startup.ConfigureServices(builder.Services); // calling ConfigureServices method
            var app = builder.Build();
            startup.Configure(app, builder.Environment); // calling Configure method
        }
    }
}
