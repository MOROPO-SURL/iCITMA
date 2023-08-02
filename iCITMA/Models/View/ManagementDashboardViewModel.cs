namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class ManagementDashboardViewModel
    {
        public System.Collections.Generic.Dictionary<string, System.Collections.Generic.ICollection<Framework.Guama.Core.Presentation.Web.Backend.Models.View.ManagementDashboardSectionViewModel>> Sections { get; set; }

        public int UserTotalCount { get; set; }
        public int UserDisabledCount { get; set; }
        public int TraceTotalCount { get; set; }
        public int TraceWeekCount { get; set; }
        public int InstitutionCount { get; set; }
        public int PersonCount { get; set; }
        public int ProgramCount { get; set; }
        public int ProjectCount { get; set; }

        public System.Collections.Generic.Dictionary<string, long> UserActivityMap { get; set; }
        
        public System.Collections.Generic.Dictionary<string, int> WeekTracesMap { get; set; }
    }
}
