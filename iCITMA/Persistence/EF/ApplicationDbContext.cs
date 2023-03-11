using Microsoft.EntityFrameworkCore;
using MOROPO.SAPRESSC.Core.Security.Common.Persistence.Entities;
using MOROPO.SAPRESSC.Middleware.Identity.Persistence.Entities;
using MOROPO.SAPRESSC.Middleware.Media.Persistence.Entities;
using MOROPO.SAPRESSC.Middleware.Region.Persistence.Entities;
using MOROPO.SAPRESSC.Middleware.Security.Identity.Persistence.Entities;

namespace MOROPO.CITMA.CMG.iCITMA.Persistence.EF
{
    public class ApplicationDbContext :
        SAPRESSC.Core.Persistence.EF.Context.AbstractTraceableDbContext,
        SAPRESSC.Middleware.Security.Identity.Persistence.EF.Contract.IModulePersistenceDbContext,
        SAPRESSC.Middleware.Identity.Persistence.EF.Context.IIdentityMiddlewarePersistenceDbContext
    {
        public ApplicationDbContext(System.Collections.Generic.IEnumerable<SAPRESSC.Core.Persistence.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade> dbSchemaConfigurationProviders, DbContextOptions options) : base(dbSchemaConfigurationProviders, options)
        {
        }

        //#if DEBUG
        //        public override bool TraceChanges => false;
        //#endif

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<UserRoleBridge> UserRoleBridges { get; set; }
        public DbSet<RolePermissionBridge> RolePermissionBridges { get; set; }

        public DbSet<Thumbnail> Thumbnails { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Video> Videos { get; set; }

        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<Municipality> Municipalities { get; set; }
        public DbSet<Locality> Localities { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<CountryRegion> CountryRegions { get; set; }
        public DbSet<StateRegion> StateRegions { get; set; }
        public DbSet<MunicipalityRegion> MunicipalityRegions { get; set; }
        public DbSet<LocalityRegion> LocalityRegions { get; set; }

        public DbSet<PersonIdentity> PersonIdentities { get; set; }
        public DbSet<OrganizationPostalContactItemBridge> OrganizationPostalContactItemBridges { get; set; }
        public DbSet<OrganizationPhoneContactItemBridge> OrganizationPhoneContactItemBridges { get; set; }
        public DbSet<OrganizationEmailContactItemBridge> OrganizationEmailContactItemBridges { get; set; }
        public DbSet<PersonWebSiteContactItemBridge> PersonWebSiteContactItemBridges { get; set; }
        public DbSet<PersonSocialContactItemBridge> PersonSocialContactItemBridges { get; set; }
        public DbSet<PersonPostalContactItemBridge> PersonPostalContactItemBridges { get; set; }
        public DbSet<PersonPhoneContactItemBridge> PersonPhoneContactItemBridges { get; set; }
        public DbSet<PersonEmailContactItemBridge> PersonEmailContactItemBridges { get; set; }
        public DbSet<PostalContactItem> PostalContactItems { get; set; }
        public DbSet<WebSiteContactItem> WebSiteContactItems { get; set; }
        public DbSet<SocialContactItem> SocialContactItems { get; set; }
        public DbSet<PhoneContactItem> PhoneContactItems { get; set; }
        public DbSet<EmailContactItem> EmailContactItems { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<OrganizationIdentity> OrganizationIdentities { get; set; }
        public DbSet<OrganizationSocialContactItemBridge> OrganizationSocialContactItemBridges { get; set; }
        public DbSet<OrganizationWebSiteContactItemBridge> OrganizationWebSiteContactItemBridges { get; set; }

        public DbSet<Entities.Currency> Currencies { get; set; }
        public DbSet<Entities.Document> Documents { get; set; }
        public DbSet<Entities.Funding> Fundings { get; set; }
        public DbSet<Entities.FundingSource> FundingSources { get; set; }
        public DbSet<Entities.ImpactIndicator> ImpactIndicators { get; set; }
        public DbSet<Entities.Institution> Institutions { get; set; }
        public DbSet<Entities.KeyWord> KeyWords { get; set; }
        public DbSet<Entities.ODSIndicator> ODSIndicators { get; set; }
        public DbSet<Entities.OutputKind> OutputKinds { get; set; }
        public DbSet<Entities.Person> Persons { get; set; }
        public DbSet<Entities.PersonInstitutionBridge> PersonInstitutionBridges { get; set; }
        public DbSet<Entities.PersonResearchAreaDoctorateBridge> PersonResearchAreaDoctorateBridges { get; set; }
        public DbSet<Entities.PersonResearchAreaMasteryBridge> PersonResearchAreaMasteryBridges { get; set; }
        public DbSet<Entities.PersonResearchAreaSpecializationBridge> PersonResearchAreaSpecializationBridges { get; set; }
        public DbSet<Entities.Program> Programs { get; set; }
        public DbSet<Entities.ProgramCategory> ProgramCategories { get; set; }
        public DbSet<Entities.ProgramDocumentBridge> ProgramDocumentBridges { get; set; }
        public DbSet<Entities.ProgramExpectResult> ProgramExpectResults { get; set; }
        public DbSet<Entities.ProgramImpactIndicatorBridge> ProgramImpactIndicatorBridges { get; set; }
        public DbSet<Entities.ProgramKeyWordBridge> ProgramKeyWordBridges { get; set; }
        public DbSet<Entities.ProgramPersonExpertBridge> ProgramPersonExpertBridges { get; set; }
        public DbSet<Entities.Project> Projects { get; set; }
        public DbSet<Entities.ProjectCategory> ProjectCategories { get; set; }
        public DbSet<Entities.ProjectCurrencyBudgetBridge> ProjectCurrencyBudgetBridges { get; set; }
        public DbSet<Entities.ProjectImpact> ProjectImpacts { get; set; }
        public DbSet<Entities.ProjectImpactODSIndicatorBridge> ProjectImpactODSIndicatorBridges { get; set; }
        public DbSet<Entities.ProjectImpactProgramExpectResultBridge> ProjectImpactProgramExpectResultBridges { get; set; }
        public DbSet<Entities.ProjectInstitutionClientBridge> ProjectInstitutionClientBridges { get; set; }
        public DbSet<Entities.ProjectInstitutionParticipationBridge> ProjectInstitutionParticipationBridges { get; set; }
        public DbSet<Entities.ProjectKeyWordBridge> ProjectKeyWordBridges { get; set; }
        public DbSet<Entities.ProjectOutput> ProjectOutputs { get; set; }
        public DbSet<Entities.ProjectPersonParticipationBridge> ProjectPersonParticipationBridges { get; set; }
        public DbSet<Entities.ProjectProgramExpectResultBridge> ProjectProgramExpectResultBridges { get; set; }
        public DbSet<Entities.ProjectSpecificObjective> ProjectSpecificObjectives { get; set; }
        public DbSet<Entities.ProjectState> ProjectStates { get; set; }
        public DbSet<Entities.ProyectSpectResult> ProyectSpectResults { get; set; }
        public DbSet<Entities.ResearchArea> ResearchAreas { get; set; }
        public DbSet<Entities.ResearcherCategory> ResearcherCategories { get; set; }
        public DbSet<Entities.SceneryKind> SceneryKinds { get; set; }
        public DbSet<Entities.TeachingCategory> TeachingCategories { get; set; }
        public DbSet<Entities.ProgramInstitutionResponsibleBridge> ProgramInstitutionResponsibleBridges { get; set; }
    }
}
