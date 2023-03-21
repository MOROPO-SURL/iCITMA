using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MOROPO.CITMA.CMG.iCITMA.Helpers.Binding;
using MOROPO.CITMA.CMG.iCITMA.Helpers.Localization;
using MOROPO.CITMA.CMG.iCITMA.Managers;
using MOROPO.CITMA.CMG.iCITMA.Models.View;
using MOROPO.CITMA.CMG.iCITMA.Options;
using MOROPO.CITMA.CMG.iCITMA.Persistence.EF;
using MOROPO.CITMA.CMG.iCITMA.Persistence.EF.Repositories;
using MOROPO.CITMA.CMG.iCITMA.Persistence.Entities;
using MOROPO.SAPRESSC.Core.Persistence.EF.Extensions;
using MOROPO.SAPRESSC.Core.Persistence.Repositories;
using MOROPO.SAPRESSC.Core.Security.Common.Web.Frontend.Extensions;
using MOROPO.SAPRESSC.Middleware.Media.Web.Common.Extensions;
using MOROPO.SAPRESSC.Middleware.Security.Identity.Persistence.EF.Extensions;
using MOROPO.SAPRESSC.Middleware.Security.Identity.Web.Backend.Extensions;
using MOROPO.SAPRESSC.Middleware.Security.Identity.Web.Common.Extensions;
using Serilog;
using System.Linq;

namespace MOROPO.CITMA.CMG.iCITMA
{
    public class Startup
    {
        private readonly IConfiguration configuration;
        private readonly IHostingEnvironment env;

        public Startup(IConfiguration configuration, IHostingEnvironment env)
        {
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();

            this.configuration = configuration;
            this.env = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<MediaThumbnailResizeOptions>(configuration.GetSection("MediaThumbnailResize"));
            services.Configure<SAPRESSC.Middleware.Media.Web.Common.Options.RelativeMediaFileManagementOptions>(configuration.GetSection("FileManagement"));

            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<DbContext, ApplicationDbContext>();

            services.PerformCoreWebSecurityCommonFrontendServiceRegistration();
            services.PerformMiddlewareSecurityIdentityWebCommonServiceRegistration();
            services.PerformMiddlewareSecurityIdentityWebBackendServiceRegistration();
            services.PerformMiddlewareMediaWebCommonRelativePathFileManagementServiceRegistration();

            services.AddScoped<IEntityRepository<ImpactIndicator, System.Guid>, ImpactIndicatorRepository>();
            services.AddScoped<IEntityRepository<ProjectState, System.Guid>, ProjectStateRepository>();
            services.AddScoped<IEntityRepository<ResearchArea, System.Guid>, ResearchAreaRepository>();
            services.AddScoped<IEntityRepository<OutputKind, System.Guid>, OutputKindRepository>();
            services.AddScoped<IEntityRepository<SceneryKind, System.Guid>, SceneryKindRepository>();
            services.AddScoped<IEntityRepository<FundingSource, System.Guid>, FundingSourceRepository>();

            services.AddSingleton<SAPRESSC.Core.Persistence.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade, Persistence.EF.Providers.ApplicationDbSchemaConfigurationProvider>();

            services.AddSingleton<SAPRESSC.Core.Persistence.EF.Helpers.Facade.IDataInitializationHelper, Helpers.ApplicationDataInitializationHelper>();

            services.AddAuthentication(config =>
            {
                config.DefaultScheme = Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddCookie(config =>
            {
                config.AccessDeniedPath = new PathString("/security/error/forbidden");
                config.LoginPath = new PathString("/security/account/login");
            });

            #region Security concreter dependencies configuration
            services.AddSingleton<SAPRESSC.Core.Web.Security.Helpers.Facade.ILicenseValidationHelperFacade, Helpers.WillcardLicenseValidationHelper>();

            services.AddTransient<SAPRESSC.Core.Web.Security.Models.View.Contrat.IUserProfileViewModel, UserProfileViewModel>();

            services.AddSingleton<SAPRESSC.Core.Web.Common.ModelBinding.IConcretModelBindHelper, ConcretModelBindHelper>();

            services.AddScoped<SAPRESSC.Core.Web.Security.Managers.Facade.IUserProfileManagerFacade, UserProfileManager>();
            #endregion

            #region Globalization configuration
            var defaultCulture = new System.Globalization.CultureInfo("es");

            services.AddLocalization(options => options.ResourcesPath = "Resources");

            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture(defaultCulture);
                options.SupportedCultures = new[] { defaultCulture };
                options.SupportedUICultures = new[] { defaultCulture };

                options.RequestCultureProviders = new[] { new SAPRESSC.Core.Web.Common.Localization.UrlRequestCultureProvider() };
            });

            services.AddSingleton<GlobalViewLocalizationHelper>();
            #endregion

            services.Configure<Microsoft.AspNetCore.Routing.RouteOptions>(options => options.LowercaseUrls = true);

            services.AddResponseCaching();
            services.AddMemoryCache();
            services.AddSession();

            services.AddMvc(mvc =>
                mvc.ModelBinderProviders.Insert(0, new SAPRESSC.Core.Web.Common.ModelBinding.AbstractsModelBinderProvider())
            )
            .AddViewLocalization(Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat.Suffix)
            .AddDataAnnotationsLocalization(options =>
                options.DataAnnotationLocalizerProvider = (type, factory) =>
                {
                    return factory.Create(typeof(SharedResources));
                }
            )
            .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_0);

            services.AddDataProtection().PersistKeysToFileSystem(new System.IO.DirectoryInfo(System.IO.Path.Combine(env.ContentRootPath, "dpkeys")));

            services.AddSingleton<Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataProvider, Microsoft.AspNetCore.Mvc.ViewFeatures.CookieTempDataProvider>();
        }

        public void Configure(IApplicationBuilder app, Microsoft.Extensions.Options.IOptions<RequestLocalizationOptions> requestLocalizationOptions, Microsoft.Extensions.Logging.ILoggerFactory loggerFactory, DbContext dbContext)
        {
            loggerFactory.AddSerilog(Log.Logger);

            app.UseRequestLocalization(requestLocalizationOptions.Value);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else if (env.IsStaging())
            {
                dbContext.Database.Migrate();

                app.PerformDatabaseInitialization();

                if (!(dbContext as ApplicationDbContext).Users.Any())
                {
                    var defaultUserId = configuration["DefaultUser:Id"];

                    var k3y = new System.Guid(0x00c44606, 0xa758, 0x4393, 0x87, 0x72, 0xad, 0xa6, 0x7e, 0xe1, 0xbb, 0x3e);

                    var protectedPassword = (dbContext as ApplicationDbContext).CreateSecureUser(k3y, defaultUserId, "system");

                    Log.Logger.Information(string.Format(">>>>>> Protected Password : \"{0}\" => \"{1}\"", defaultUserId, protectedPassword));
                }
            }
            else
            {
                app.UseExceptionHandler("/error");

                app.UseHsts();
            }

            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseSession();

            app.UseMvc(routes =>
            {
                routes.MapRoute("defaultLocalizedAreaRoutes",
                    template: "{culture:regex(^[[a-z]]{{2}}(?:-[[A-Z]]{{2}})?$)}/{area:exists}/{controller=start}/{action=index}/{id?}");

                routes.MapRoute(
                    name: "defaultLocalizedRoutes",
                    template: "{culture:regex(^[[a-z]]{{2}}(?:-[[A-Z]]{{2}})?$)}/{controller=start}/{action=index}/{id?}");

                routes.MapRoute("defaultAreaRoutes",
                    template: "{area:exists}/{controller=start}/{action=index}/{id?}");

                routes.MapRoute(
                    name: "defaultRoutes",
                    template: "{controller=start}/{action=index}/{id?}");
            });
        }
    }
}
