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
    }
}
