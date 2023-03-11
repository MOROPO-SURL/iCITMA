namespace MOROPO.CITMA.CMG.iCITMA.Persistence.Entities
{
    public class Institution : SAPRESSC.Core.Persistence.Entities.IEntity<System.Guid>
    {
        public Institution()
        {
            Id = System.Guid.NewGuid();
        }

        [System.ComponentModel.DataAnnotations.Key]
        public System.Guid Id { get; set; }

        public SAPRESSC.Middleware.Identity.Persistence.Entities.OrganizationIdentity Identity { get; set; }
        public System.Guid? IdentityId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("OwnerId")]
        public Institution Owner { get; set; }
        public System.Guid? OwnerId { get; set; }

        [System.ComponentModel.DataAnnotations.Schema.ForeignKey("RepresentativeId")]
        public Person Representative { get; set; }
        [System.ComponentModel.DataAnnotations.Required]
        public System.Guid? RepresentativeId { get; set; }
    }
}
