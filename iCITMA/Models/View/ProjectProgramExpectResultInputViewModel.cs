namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class ProjectProgramExpectResultInputViewModel
    {
        public System.Guid IdProgramExpectResult { get; set; }
        public System.Guid ProjectId { get; set; }
        public System.Guid ProgramId { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DisplayName("Title")]
        public string Title { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        [System.ComponentModel.DisplayName("Description")]
        public string Description { get; set; }   
    
    }
}
