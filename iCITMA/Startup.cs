using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
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
using MOROPO.Framework.Guama.Core.Persistence.Repositories;
using MOROPO.Framework.Guama.Core.Security.Common.Presentation.Web.Frontend.Extensions;
using MOROPO.Framework.Guama.Location.Presentation.Web.Common.Extensions;
using MOROPO.Framework.Guama.Media.Presentation.Web.Common.Extensions;
using MOROPO.Framework.Guama.Security.Personal.Persistence.ORM.EF.Extensions;
using MOROPO.Framework.Guama.Security.Personal.Presentation.Web.Backend.Extensions;
using Serilog;
using System.Linq;

namespace MOROPO.CITMA.CMG.iCITMA
{
    public class Startup
    {
        private readonly IConfiguration configuration;
        private readonly IWebHostEnvironment env;

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(configuration).CreateLogger();

            this.configuration = configuration;
            this.env = env;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<MediaThumbnailResizeOptions>(configuration.GetSection("MediaThumbnailResize"));
            services.Configure<Framework.Guama.Media.Presentation.Web.Common.Options.RelativeMediaFileManagementOptions>(configuration.GetSection("FileManagement"));

            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<DbContext, ApplicationDbContext>();

            services.PerformCoreWebSecurityCommonFrontendServiceRegistration();
            services.PerformSecurityPersonalWebBackendServiceRegistration();
            services.PerformMediaWebCommonRelativePathFileManagementServiceRegistration();
            services.PerformLocationWebCommonServiceRegistration();

            services.AddScoped<IEntityRepository<ImpactIndicator, System.Guid>, ImpactIndicatorRepository>();
            services.AddScoped<IEntityRepository<ProjectState, System.Guid>, ProjectStateRepository>();
            services.AddScoped<IEntityRepository<ResearchArea, System.Guid>, ResearchAreaRepository>();
            services.AddScoped<IEntityRepository<OutputKind, System.Guid>, OutputKindRepository>();
            services.AddScoped<IEntityRepository<SceneryKind, System.Guid>, SceneryKindRepository>();
            services.AddScoped<IEntityRepository<FundingSource, System.Guid>, FundingSourceRepository>();
            services.AddScoped<IEntityRepository<ResearcherCategory, System.Guid>, ResearcherCategoryRepository>();
            services.AddScoped<IEntityRepository<TeachingCategory, System.Guid>, TeachingCategoryRepository>();
            services.AddScoped<IEntityRepository<ProjectCategory, System.Guid>, ProjectCategoryRepository>();
            services.AddScoped<IEntityRepository<ProgramCategory, System.Guid>, ProgramCategoryRepository>();
            services.AddScoped<IEntityRepository<KeyWord, System.Guid>, KeyWordRepository>();
            services.AddScoped<IEntityRepository<ODSIndicator, System.Guid>, ODSIndicatorRepository>();
            services.AddScoped<IEntityRepository<Person, System.Guid>, PersonRepository>();

            services.AddSingleton<Framework.Guama.Media.Presentation.Web.Common.Managers.Facade.IImageFileManagerFacade, Managers.RelativeImageFileManager1>();

            services.AddSingleton<Framework.Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade, Persistence.EF.Providers.ApplicationDbSchemaConfigurationProvider>();

            services.AddSingleton<Framework.Guama.Core.Persistence.ORM.EF.Helpers.Facade.IDataInitializationHelper, Helpers.ApplicationDataInitializationHelper>();

            services.AddAuthentication(config =>
            {
                config.DefaultScheme = Microsoft.AspNetCore.Authentication.Cookies.CookieAuthenticationDefaults.AuthenticationScheme;
            })
            .AddCookie(config =>
            {
                config.AccessDeniedPath = new PathString("/error/403");
                config.LoginPath = new PathString("/security/account/login");
                config.ExpireTimeSpan = System.TimeSpan.FromMinutes(5);
                config.SlidingExpiration = true;
            });

            #region Security concreter dependencies configuration
            services.AddSingleton<Framework.Guama.Core.Presentation.Web.Security.Helpers.Facade.ILicenseValidationHelperFacade, Helpers.WillcardLicenseValidationHelper>();

            services.AddTransient<Framework.Guama.Core.Presentation.Web.Security.Models.View.Contrat.IUserProfileViewModel, UserProfileViewModel>();

            services.AddSingleton<Framework.Guama.Core.Presentation.Web.Common.ModelBinding.Contract.IConcretModelBindHelper, ConcretModelBindHelper>();

            services.AddScoped<Framework.Guama.Core.Presentation.Web.Security.Managers.Facade.IUserProfileManagerFacade, UserProfileManager>();
            #endregion

            #region Globalization configuration
            var defaultCulture = new System.Globalization.CultureInfo("es");

            services.AddLocalization(options => options.ResourcesPath = "Resources");

            services.Configure<RequestLocalizationOptions>(options =>
            {
                options.DefaultRequestCulture = new Microsoft.AspNetCore.Localization.RequestCulture(defaultCulture);
                options.SupportedCultures = new[] { defaultCulture };
                options.SupportedUICultures = new[] { defaultCulture };

                options.RequestCultureProviders = new[] { new Framework.Guama.Core.Presentation.Web.Common.Localization.UrlRequestCultureProvider() };
            });

            services.AddSingleton<GlobalViewLocalizationHelper>();
            #endregion

            services.Configure<Microsoft.AspNetCore.Routing.RouteOptions>(options => options.LowercaseUrls = true);

            services.AddResponseCaching();
            services.AddMemoryCache();
            services.AddSession();

            services.AddMvc(mvc =>
            {
                mvc.EnableEndpointRouting = false;
                mvc.ModelBinderProviders.Insert(0, new Framework.Guama.Core.Presentation.Web.Common.ModelBinding.AbstractsModelBinderProvider());
            })
            .AddViewLocalization(Microsoft.AspNetCore.Mvc.Razor.LanguageViewLocationExpanderFormat.Suffix)
            .AddDataAnnotationsLocalization(options =>
                options.DataAnnotationLocalizerProvider = (type, factory) =>
                {
                    return factory.Create(typeof(SharedResources));
                }
            );

            services.AddDataProtection().PersistKeysToFileSystem(new System.IO.DirectoryInfo(System.IO.Path.Combine(env.ContentRootPath, "dpkeys")));

            services.AddSingleton<Microsoft.AspNetCore.Mvc.ViewFeatures.ITempDataProvider, Microsoft.AspNetCore.Mvc.ViewFeatures.CookieTempDataProvider>();
        }

        public void Configure(IApplicationBuilder app, Microsoft.Extensions.Options.IOptions<RequestLocalizationOptions> requestLocalizationOptions, Microsoft.Extensions.Logging.ILoggerFactory loggerFactory, DbContext dbContext)
        {
            System.AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
            System.AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            loggerFactory.AddSerilog(Log.Logger);

            app.UseRequestLocalization(requestLocalizationOptions.Value);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else if (env.IsStaging())
            {
                dbContext.Database.Migrate();

                var dataInitializationHelpers = app.ApplicationServices.GetServices<Framework.Guama.Core.Persistence.ORM.EF.Helpers.Facade.IDataInitializationHelper>();

                using (var serviceScope = app.ApplicationServices.CreateScope())
                {
                    var scopedDbContext = serviceScope.ServiceProvider.GetService<DbContext>();

                    foreach (var dataInitializationHelper in dataInitializationHelpers)
                    {
                        dataInitializationHelper.InitialiseData(scopedDbContext);
                    }
                }

                if (!(dbContext as ApplicationDbContext).Users.Any())
                {
                    var defaultUserId = configuration["DefaultUser:Id"];

                    var k3y = new System.Guid(0x00c44606, 0xa758, 0x4393, 0x87, 0x72, 0xad, 0xa6, 0x7e, 0xe1, 0xbb, 0x3e);

                    var protectedPassword = (dbContext as ApplicationDbContext).CreateSecureUser(k3y, defaultUserId, "system");

                    Log.Logger.Information(string.Format(">>>>>> Protected Password : {0} => {1}", defaultUserId, protectedPassword));
                }
            }
            else
            {
                app.UseExceptionHandler("/error/exception");

                app.UseHsts();
            }

            app.UseStatusCodePagesWithReExecute("/error/{0}");

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
