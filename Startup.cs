using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCoreFromScratch.Data;
using NetCoreFromScratch.Models;

namespace NetCoreFromScratch
{
    public  class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }


        public void ConfigureServices(IServiceCollection serviceCollection)
        {
            
            serviceCollection.AddRouting();
        
            serviceCollection.AddControllers();
            serviceCollection.AddMvc();

            serviceCollection.AddIdentity<Customer ,CustomerRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<CustomerDbContext>();


            // tva tuka mnogo vnimalteno da go zapomnq i da go procheta i opravq https://www.c-sharpcorner.com/article/tutorial-use-entity-framework-core-5-0-in-net-core-3-1-with-mysql-database-by2/ 

            string mySqlConnectionStr = Configuration.GetConnectionString("conS");
            serviceCollection.AddDbContextPool<CustomerDbContext>(options => options.UseMySql(mySqlConnectionStr, ServerVersion.AutoDetect(mySqlConnectionStr)));


            serviceCollection.AddScoped<IRepository, Repository>();
        }


        public void Configure(IApplicationBuilder app , IWebHostEnvironment env)
        {
            /*  app.Use(
                  async (context, next) =>
                  {
                      await context.Response.WriteAsync("Hello from HelL Im Slavi Trifonov and Im bringing the apocaliptic horses with me\n"); // 1
                      await next();
                      await context.Response.WriteAsync("On The way back 1\n"); //5

                  }



            );
              app.Use(
                 async (context, next) =>
                 {
                     await context.Response.WriteAsync("I will fuck you\n"); // 2
                     await next.Invoke();
                     await context.Response.WriteAsync("On The way back 2\n");//4 

                 }


           );



              app.Map("/specialRoute" , app =>
                  {

                     app.Use(
                      async (context, next) =>
                    {
                     await context.Response.WriteAsync("Hi from Special Route\n");
                     await next.Invoke();

                    });
              });


              app.Run(

                  async (context) =>
                  {
                      await context.Response.WriteAsync("From Inside Run\n");
                  }

                  );

              app.Use(
          async (context, next) =>
          {
              await context.Response.WriteAsync("Hardly\n"); // 3 idva do tuk i sa vrushta na obratno


          }



    );*/
            app.UseDeveloperExceptionPage();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseStaticFiles(); // taq tupotiq e primerno da moje da dostupvame nqkvi takvia kato TextFile.txt koito pak e specialna papka koqto traq da napravim koqto daje q razpoznava specialno wwwwroot tashaci

            app.UseEndpoints(configure =>
            {
                configure.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );

            });
        }




    }
}