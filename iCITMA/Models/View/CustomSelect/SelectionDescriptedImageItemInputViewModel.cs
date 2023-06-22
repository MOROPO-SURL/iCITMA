using MOROPO.Framework.Guama.Core.Presentation.Models.View;

namespace MOROPO.CITMA.CMG.iCITMA.Models.View.CustomSelect
{
    public class SelectionDescriptedImageItemInputViewModel<Guid>: SelectionDescriptedItemInputViewModel<System.Guid>
    {
        public System.Guid? ImageId { get; set; }

        public string ImageExtension { get; set; }
        public string LabelDisplay { get; set; }
        public string DescriptionDisplay { get; set; }
    }
}
