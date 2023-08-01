namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class PostalContactDisplayViewModel
    {       
        public System.Guid Id { get; set; }        
        
        public string Address { get; set; }
        
        public Framework.Guama.Location.Persistence.Entities.Location Location { get; set; }        
        public System.Guid LocationId { get; set; }
        
        public int ZipCode { get; set; }
        
        public decimal Longitude { get; set; }
        public decimal Latitude { get; set; }
    }
}
