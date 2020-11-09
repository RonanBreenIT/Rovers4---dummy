using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rovers4.Auth;
using Rovers4.Data;
using Rovers4.Filters;
using Rovers4.Models;
using Rovers4.Services;

namespace Rovers4
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDbContext<ClubContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("ClubContext")));
            //services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //   .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders() // Added this and below DefaultUI to get Register Method to work - https://stackoverflow.com/questions/52089864/unable-to-resolve-service-for-type-iemailsender-while-attempting-to-activate-reg/52090321
                .AddDefaultUI();

            services.AddScoped<ITeamRepository, TeamRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IPlayerStatRepository, PlayerStatRepository>();
            services.AddScoped<IFixtureRepository, FixtureRepository>();

            services.AddTransient<IMailService, SendGridMailService>(); // SendGridMail
            services.AddTransient<IBlobStorageService, BlobStorageService>(); //Azure Storage for Images
            services.AddTransient<IMapsService, MapsService>(); //Google Maps

            // Sets X-Frame Header with value as SameOrigin
            services.AddAntiforgery(options =>
            {
                options.SuppressXFrameOptionsHeader = true;
            });

            services.AddControllersWithViews();
            services.AddRazorPages();

            services.AddMvc
                (
                    config =>
                    {
                        config.Filters.AddService(typeof(TimerActionAttribute));
                        config.CacheProfiles.Add("Default",
                            new CacheProfile()
                            {
                                Duration = 30,
                                Location = ResponseCacheLocation.Any
                            });
                        config.CacheProfiles.Add("None",
                            new CacheProfile()
                            {
                                Location = ResponseCacheLocation.None,
                                NoStore = true
                            });
                    }
                );

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.Cookie.SameSite = SameSiteMode.Strict;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                options.Cookie.IsEssential = true;
            });

            services.AddSession(options =>
            {
                options.Cookie.SameSite = SameSiteMode.Strict;
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
                options.Cookie.IsEssential = true;
            });


            //Claims-based ** Not in use **
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdministratorOnly", policy => policy.RequireRole("SuperAdmin"));
            });

            services.AddMemoryCache();

            //Filters
            services.AddScoped<TimerActionAttribute>();
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

            // The code adds a new header named Header-Name to all responses, and also sets x-Frame headers as Same Origin, and X-Content options to No Sniff.
            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("Header-Name", "Header-Value");
                context.Response.Headers.Add("X-Frame-Options", "SAMEORIGIN");
                context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
                await next();
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCookiePolicy();
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
    }
}
