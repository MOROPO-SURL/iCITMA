namespace MOROPO.CITMA.CMG.iCITMA.Models.View
{
    public class PostalContactDisplayViewModel
    {       
        public System.Guid Id { get; set; }
        
        public string Label { get; set; }
        
        public string Address { get; set; }
        
        public string Municipality { get; set; }

        public string State { get; set; }
        
        public int ZipCode { get; set; }
        
        public decimal Longitude { get; set; }
        
        public decimal Latitude { get; set; }
    }
}
