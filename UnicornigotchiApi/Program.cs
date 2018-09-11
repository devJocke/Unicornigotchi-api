using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;

namespace EFGetStarted.AspNetCore.NewDb {

     public class Program {

       public static void Main(string[] args) {
            CreateWebHostBuilder(args).Build().Run();
            var host = new WebHostBuilder()
               .UseKestrel()
               .UseContentRoot(Directory.GetCurrentDirectory())
               .UseIISIntegration()
               .UseStartup<Startup>()
               .UseApplicationInsights()
               .Build();

            host.Run();
        }
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) {
            return WebHost.CreateDefaultBuilder(args).UseStartup<Startup>();
        }
     }
 }
