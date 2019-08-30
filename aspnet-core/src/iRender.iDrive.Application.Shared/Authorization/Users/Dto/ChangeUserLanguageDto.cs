using System.ComponentModel.DataAnnotations;

namespace iRender.iDrive.Authorization.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}
