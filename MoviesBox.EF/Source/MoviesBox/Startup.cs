using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.SqlServer;
using MoviesBox.EFModel;
using MoviesBox.SharedLogic.Helpers;

namespace MoviesBox
{
  public class Startup
  {
    public Startup(IConfiguration configuration)
    {
      Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc();
      string connectionString = HelperMethods.GetAppConfigValue("ConnectionStrings");
      services.AddDbContext<DbMovieContext>
        (opt => opt.UseSqlServer(
                                  connectionString,
                                  b => b.MigrationsAssembly("MoviesBox")
                                ));
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseBrowserLink();
        app.UseDeveloperExceptionPage();
      }
      else
      {
        app.UseExceptionHandler("/Home/Error");
      }

      app.UseStaticFiles();

      app.UseMvc(routes =>
      {
        routes.MapRoute(
                  name: "default",
                  template: "{controller=Home}/{action=Index}/{id?}");
      });

      app.UseMvc(routes =>
      {
        routes.MapRoute("MovieDetails", "movie/{imdbIdParam}",
            new { controller = "Movie", action = "Index" });
      });
    }
  }
}
