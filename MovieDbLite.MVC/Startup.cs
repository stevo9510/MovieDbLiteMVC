using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MovieDbLite.MVC.Data;
using MovieDbLite.MVC.Models;
using MovieDbLite.MVC.Profiles;
using NSwag;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDbLite.MVC
{
    public class Startup
    {
        private IWebHostEnvironment HostEnvironment { get; }
        public Startup(IConfiguration configuration, IWebHostEnvironment hostEnvironment)
        {
            Configuration = configuration;
            HostEnvironment = hostEnvironment;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSwaggerDocument(config =>
                {
                    config.PostProcess = document =>
                    {
                        OpenApiInfo info = document.Info;
                        info.Version = "v1";
                        info.Title = "MovieDbLite API";
                        info.TermsOfService = "Not Applicable";
                        info.Contact = new NSwag.OpenApiContact
                        {
                            Name = "Steven Anderson",
                            Url = "https://www.github.com/stevo9510"
                        };
                    };
                });

            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new AwardProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddDbContext<MovieDbLiteContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MovieDbConnection")));
            services.AddControllersWithViews().AddNewtonsoftJson();
            services.AddRazorPages();

            // Allow anonymous to hit endpoints in development mode.
            if (HostEnvironment.IsDevelopment())
            {
                services.AddSingleton<IAuthorizationHandler, AllowAnonymous>();
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseStatusCodePages();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            // Register the Swagger generator and the Swagger UI middlewares
            app.UseOpenApi();
            app.UseSwaggerUi3();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }

        /// <summary>
        /// This authorisation handler will bypass all requirements
        /// </summary>
        private class AllowAnonymous : IAuthorizationHandler
        {
            public Task HandleAsync(AuthorizationHandlerContext context)
            {
                foreach (IAuthorizationRequirement requirement in context.PendingRequirements.ToList())
                {
                    context.Succeed(requirement); //Simply pass all requirements
                }

                return Task.CompletedTask;
            }
        }
    }
}
