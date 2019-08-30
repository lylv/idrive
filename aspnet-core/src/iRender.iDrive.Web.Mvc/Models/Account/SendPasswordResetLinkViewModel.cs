using System.ComponentModel.DataAnnotations;

namespace iRender.iDrive.Web.Models.Account
{
    public class SendPasswordResetLinkViewModel
    {
        [Required]
        public string EmailAddress { get; set; }
    }
}