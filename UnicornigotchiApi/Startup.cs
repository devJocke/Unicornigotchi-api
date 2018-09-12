using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore; 
using Microsoft.Extensions.Logging;
using UnicornigotchiApi.Models;

namespace EFGetStarted.AspNetCore.NewDb {
    public class Startup {

        public IConfiguration Configuration { get; }
         

        public Startup(IHostingEnvironment env) {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.Configure<CookiePolicyOptions>(options => {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                //options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddDbContext<mobileRemoteDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("UnicornDb")));

            services.AddMvc().AddXmlDataContractSerializerFormatters();
            services.AddSwaggerGen(c =>
             c.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info { Title = "Unicornigotchi", Version = "v1" }));


            //    services.AddAuthentication(options =>
            //    {
            //        options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            //    })

            //.AddJwtBearer(options =>
            //{
            //    options.Authority = "http://localhost:30940/";
            //    options.Audience = "resource-server";
            //    options.RequireHttpsMetadata = false;
            //}); 
        }

        //The Configure method is used to specify how the app responds to HTTP requests. https://docs.microsoft.com/en-us/aspnet/core/fundamentals/startup?view=aspnetcore-2.1#the-configure-method
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory) {

            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            } else {
                app.UseExceptionHandler(" / Home/Error");
                app.UseHsts();
            }
             
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes => {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=unicorn}/{action=Index}/{id?}");
            });

            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            //app.UseAuthentication();

            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"));

        }
    }
}