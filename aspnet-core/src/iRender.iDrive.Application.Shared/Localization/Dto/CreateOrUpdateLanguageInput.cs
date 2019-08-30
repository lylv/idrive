using System.ComponentModel.DataAnnotations;

namespace iRender.iDrive.Localization.Dto
{
    public class CreateOrUpdateLanguageInput
    {
        [Required]
        public ApplicationLanguageEditDto Language { get; set; }
    }
}