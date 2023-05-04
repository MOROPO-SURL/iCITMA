namespace MOROPO.CITMA.CMG.iCITMA.Persistence.Entities
{
    public class Currency : Framework.Guama.Core.Persistence.Entities.Contract.INamedEntity<int>
    {
        [System.ComponentModel.DataAnnotations.Key]
        public int Id { get; set; }

        [System.ComponentModel.DataAnnotations.Required]
        public string Name { get; set; }

        public string Symbol { get; set; }

        public bool IsSpacedSymbol { get; set; }

        public Enumerators.CurrencySymbolPosition Position { get; set; }
    }
}
