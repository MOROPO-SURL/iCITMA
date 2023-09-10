using Microsoft.EntityFrameworkCore;
using MOROPO.Framework.Guama.Core.Security.Common.Persistence.Entities;
using MOROPO.Framework.Guama.Identity.Persistence.Entities;
using MOROPO.Framework.Guama.Location.Persistence.Entities;
using MOROPO.Framework.Guama.Media.Persistence.Entities;
using MOROPO.Framework.Guama.Security.Personal.Persistence.Entities;

namespace MOROPO.CITMA.CMG.iCITMA.Persistence.EF
{
    public class ApplicationDbContext :
        Framework.Guama.Core.Persistence.ORM.EF.Context.Contract.AbstractTraceableDbContext,
        Framework.Guama.Security.Personal.Persistence.ORM.EF.Contract.IPersistenceDbContext,
        Framework.Guama.Identity.Persistence.ORM.EF.Context.IPersistenceDbContext
    {
        public ApplicationDbContext(System.Collections.Generic.IEnumerable<Framework.Guama.Core.Persistence.ORM.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade> dbSchemaConfigurationProviders, DbContextOptions options) : base(dbSchemaConfigurationProviders, options)
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
        public DbSet<Location> Locations { get; set; }
        public DbSet<StateLocation> StateLocations { get; set; }
        public DbSet<MunicipalityLocation> MunicipalityLocations { get; set; }
        public DbSet<LocalityLocation> LocalityLocations { get; set; }

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
        public DbSet<OrganizationPersonMembershipBridge> OrganizationPersonMembershipBridges { get; set; }
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
        public DbSet<Entities.SpecificObjective> SpecificObjectives { get; set; }
    }
}
