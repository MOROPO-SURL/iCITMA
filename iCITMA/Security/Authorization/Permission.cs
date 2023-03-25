namespace MOROPO.CITMA.CMG.iCITMA.Security.Authorization
{
    public static class Permission
    {
        public const string TraceViewer = "security-trace-viewer";

        #region ImpactIndicator

        public const string ImpactIndicatorViewer = "impact-indicator-viewer";

        public const string ImpactIndicatorCreator = "impact-indicator-creator";

        public const string ImpactIndicatorEditor = "impact-indicator-editor";

        public const string ImpactIndicatorRemover = "impact-indicator-remover";

        #endregion

        #region ProjectState

        public const string ProjectStateViewer = "project-state-viewer";

        public const string ProjectStateCreator = "project-state-creator";

        public const string ProjectStateEditor = "project-state-editor";

        public const string ProjectStateRemover = "project-state-remover";

        #endregion

        #region ResearchArea

        public const string ResearchAreaViewer = "research-area-viewer";

        public const string ResearchAreaCreator = "research-area-creator";

        public const string ResearchAreaEditor = "research-area-editor";

        public const string ResearchAreaRemover = "research-area-remover";

        #endregion

        #region OutputKind

        public const string OutputKindViewer = "output-kind-viewer";

        public const string OutputKindCreator = "output-kind-creator";

        public const string OutputKindEditor = "output-kind-editor";

        public const string OutputKindRemover = "output-kind-remover";

        #endregion
        
        #region SceneryKind

        public const string SceneryKindViewer = "scenery-kind-viewer";

        public const string SceneryKindCreator = "scenery-kind-creator";

        public const string SceneryKindEditor = "scenery-kind-editor";

        public const string SceneryKindRemover = "scenery-kind-remover";

        #endregion 

        #region FundingSource

        public const string FundingSourceViewer = "funding-source-viewer";

        public const string FundingSourceCreator = "funding-source-creator";

        public const string FundingSourceEditor = "funding-source-editor";

        public const string FundingSourceRemover = "funding-source-remover";

        #endregion

        #region ResearcherCategory

        public const string ResearcherCategoryViewer = "researcher-category-viewer";

        public const string ResearcherCategoryCreator = "researcher-category-creator";

        public const string ResearcherCategoryEditor = "researcher-category-editor";

        public const string ResearcherCategoryRemover = "researcher-category-remover";

        #endregion

        #region TeachingCategory

        public const string TeachingCategoryViewer = "teaching-category-viewer";

        public const string TeachingCategoryCreator = "teaching-category-creator";

        public const string TeachingCategoryEditor = "teaching-category-editor";

        public const string TeachingCategoryRemover = "teaching-category-remover";

        #endregion
    }
}
