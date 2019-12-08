using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System.Net;

namespace QRCode.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateWebHostBuilder(args).Build().Run();
          BuildWebHost(args).Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();

       
        public static IWebHost BuildWebHost(string[] args) =>
           WebHost.CreateDefaultBuilder(args)
               .UseStartup<Startup>()
               //.UseKestrel(options =>
              // {
                    // http://localhost:5000/
                    //options.Listen(IPAddress.Loopback, 6000);
                    // https://localhost:5443/
                   // options.Listen(IPAddress.Loopback, 5443, listenOptions =>
                   //{
                  //     listenOptions.UseHttps("localhost.pfx", "MyPassword");
                   //});
              // })
               .UseUrls("http://localhost:6500")
               .Build();
    }
}

