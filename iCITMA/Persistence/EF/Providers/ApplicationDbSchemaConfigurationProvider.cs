using MOROPO.SAPRESSC.Core.Persistence.EF.Configurators;

namespace MOROPO.CITMA.CMG.iCITMA.Persistence.EF.Providers
{
    public class ApplicationDbSchemaConfigurationProvider : SAPRESSC.Core.Persistence.EF.Providers.Facade.IDbSchemaConfigurationProviderFacade
    {
        public string DefaultPersistenceSchema => null;

        public System.Collections.Generic.ICollection<IEntityTypeConfigurator> EntityTypeConfigurators
        {
            get
            {
                return new System.Collections.Generic.List<IEntityTypeConfigurator>
                {
                    new Configurators.PersonInstitutionBridgeEntityTypeConfigurator(),
                    new Configurators.PersonResearchAreaDoctorateBridgeEntityTypeConfigurator(),
                    new Configurators.PersonResearchAreaMasteryBridgeEntityTypeConfigurator(),
                    new Configurators.PersonResearchAreaSpecializationBridgeEntityTypeConfigurator(),
                    new Configurators.ProgramDocumentBridgeEntityTypeConfigurator(),
                    new Configurators.ProgramImpactIndicatorBridgeEntityTypeConfigurator(),
                    new Configurators.ProgramKeyWordBridgeEntityTypeConfigurator(),
                    new Configurators.ProgramPersonExpertBridgeEntityTypeConfigurator(),
                    new Configurators.ProjectCurrencyBudgetBridgeEntityTypeConfigurator(),
                    new Configurators.ProjectImpactEntityTypeConfigurator(),
                    new Configurators.ProjectImpactODSIndicatorBridgeEntityTypeConfigurator(),
                    new Configurators.ProjectImpactProgramExpectResultBridgeEntityTypeConfigurator(),
                    new Configurators.ProjectInstitutionClientBridgeEntityTypeConfigurator(),
                    new Configurators.ProjectInstitutionParticipationBridgeEntityTypeConfigurator(),
                    new Configurators.ProjectKeyWordBridgeEntityTypeConfigurator(),
                    new Configurators.ProjectPersonParticipationBridgeEntityTypeConfigurator(),
                    new Configurators.ProjectProgramExpectResultBridgeEntityTypeConfigurator(),
                    new Configurators.ProgramInstitutionResponsibleBridgeEntityTypeConfigurator(),
                    new Configurators.FundingEntityTypeConfigurator(),
                    new Configurators.InstitutionEntityTypeConfigurator(),
                    new Configurators.PersonEntityTypeConfigurator(),
                    new Configurators.ProgramEntityTypeConfigurator(),
                    new Configurators.ProjectEntityTypeConfigurator()
                };
            }
        }
    }
}
